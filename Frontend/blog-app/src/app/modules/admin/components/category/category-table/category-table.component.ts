import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import 'datatables.net';
import 'datatables.net-bs4';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-category-table',
  templateUrl: './category-table.component.html',
  styleUrls: ['./category-table.component.sass']
})
export class CategoryTableComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    let baseUrl = environment.backendUri;
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
  }

  actionButton(data, type, full, meta) {
    let actions = "<div>";
    actions += `<a href='/admin/category/${data}' class='btn btn-sm btn-outline-success'><i class="fas fa-edit"></i> Edit</a>`;
    actions += `<a href='/admin/category/${data}' class='btn ml-2 btn-sm btn-outline-danger'><i class="fas fa-trash-alt"></i> Delete</a>`;
    actions += "</div>"
    return actions;
  }
}
