using Microsoft.Extensions.DependencyInjection;

using MyBlog.Application.Interfaces;
using MyBlog.Application.Users.Commands.AddUser;
using MyBlog.Application.Users.Commands.DeleteUser;
using MyBlog.Application.Users.Queries.GetUser;
using MyBlog.Application.Users.Queries.GetUsers;
using MyBlog.Application.Users.Queries.GetUserSocialLinks;

using System.Collections.Generic;

namespace MyBlog.API.Extensions
{
    public static class UserDependencyExtensions
    {
        public static IServiceCollection RegisterUserDependencies(this IServiceCollection services)
        {
            //Queries
            services.AddScoped<IRequestHandler<GetUsersQuery, List<UserListViewModel>>, GetUsersQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserQuery, UserDetailViewModel>, GetUserQueryHandler>();
            services.AddScoped<IRequestHandler<GetUserSocialLinksQuery, UserSocialLinksViewModel>, GetUserSocialLinksQueryHandler>();

            //Commands
            services.AddScoped<ICommandHandler<DeleteUserCommand>, DeleteUserCommandHandler>();
            services.AddScoped<ICommandHandler<AddUserCommand, int>, AddUserCommandHandler>();

            return services;
        }
    }
}
