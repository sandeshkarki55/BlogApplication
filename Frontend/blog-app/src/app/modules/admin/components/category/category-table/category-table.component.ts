import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import * as $ from 'jquery';
import 'datatables.net';
import 'datatables.net-bs4';
import { environment } from 'src/environments/environment';
import { CategoryService } from 'src/app/services/category/category.service';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.sass']
})
export class CategoryTableComponent implements OnInit {

  constructor(private categoryService: CategoryService,
    private cdRef: ChangeDetectorRef) { }

  ngOnInit() {
    let baseUrl = environment.backendUri;
    let token = localStorage.getItem('token');
    $("#category-table").DataTable(
      {
        "pageLength": 10,
        "serverSide": true,
        "processing": true,
        "ordering": true,
        "deferRender": true,
        "ajax": {
          "type": "POST",
          "url": baseUrl + "api/Category/DtResult",
          "contentType": "application/json; charset=utf-8",
          "data": function (data: any) {
            return JSON.stringify(data);
          },
          beforeSend: function (xhr) {
            xhr.setRequestHeader('Authorization', `Bearer ${token}`);
          }
        },
        "columnDefs": [
          {
            "searchable": false,
            "orderable": false,
            "targets": [0]
          }
        ],
        "columns": [
          { "data": "SN" },
          { "data": "Name", "render": $.fn.dataTable.render.text() },
          {
            "data": "Id", "name": "Action", "render": this.actionButton,
            "searchable": false,
            "orderable": false,
            "visible": true
          }
        ],
        "order": [1, "desc"]
      });
    this.cdRef.detectChanges();
  }

  actionButton(data: any, type: any, full: any, meta: any) {
    let actions = "<div>";
    actions += `<a href='/admin/category/${data}' class='btn btn-sm btn-outline-success'><i class="fas fa-edit"></i> Edit</a>`;

    actions += `<button (click)="deleteCategory('${data}')" type="button" class="btn ml-2 btn-sm btn-outline-danger" data-toggle="modal" data-target="#deteleModal"><i class="fas fa-trash-alt"></i> Delete</button>`;
    actions += "</div>"
    return actions;
  }

  async deletCategory(id: string) {
    await this.categoryService.deleteCategory(id);
  }
}
