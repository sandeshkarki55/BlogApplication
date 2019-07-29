using MediatR;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using MyBlog.Application.Exceptions;
using MyBlog.Application.Interfaces;
using MyBlog.Domain.Entities;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBlog.Application.Accounts.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMyBlogDbContext _myBlogDbContext;

        public LoginCommandHandler(UserManager<AppUser> userManager,
            IConfiguration configuration,
            IMyBlogDbContext myBlogDbContext)
        {
            _userManager = userManager;
            _configuration = configuration;
            _myBlogDbContext = myBlogDbContext;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                throw new InvalidCredentialsException();
            }

            var isValidUser = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!isValidUser)
            {
                throw new InvalidCredentialsException();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var signingKeyString = _configuration.GetValue<string>("Jwt:Key");
            var key = Encoding.UTF8.GetBytes(signingKeyString);

            var userClaims = await _userManager.GetClaimsAsync(user);
            var userDetail = await _myBlogDbContext.UserDetails.FirstOrDefaultAsync(x => x.UserName.Equals(user.UserName));

            userClaims.Add(new Claim("UserDetailId", userDetail.Id.ToString()));
            userClaims.Add(new Claim("Address", userDetail.Address));
            userClaims.Add(new Claim("FullName", userDetail.Name.FullName));

            var tokenDescripter = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescripter);
            return tokenHandler.WriteToken(token);
        }
    }
}
