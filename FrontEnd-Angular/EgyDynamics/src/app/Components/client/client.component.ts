import { Component, OnInit } from '@angular/core';
import { ClientService } from '../../Services/client.service';
import { Client } from '../../Models/client';
import { CommonModule } from '@angular/common';
import * as XLSX from 'xlsx';
import { Router, RouterLink } from '@angular/router';
import { ClientAdd } from '../../Models/client-add';
import { AccountLogInService } from '../../Services/account-log-in.service';


@Component({
  selector: 'app-client',
  standalone: true,
  imports: [CommonModule,RouterLink],
  templateUrl: './client.component.html',
  styleUrl: './client.component.css'
})
export class ClientComponent implements OnInit{
  constructor(public clientservice:ClientService, public router:Router,private acc:AccountLogInService){}
  Clients:Client[]=[];
  pageNumber: number = 1;
  pageSize: number = 4;
  totalPages: number = 0;

ngOnInit(): void {
  this.clients();
  }

  clients(){
    this.clientservice.getClients(this.pageNumber, this.pageSize).subscribe({
      next:(d)=>{
        this.Clients=d.data,
        this.totalPages = d.totalItems;
        }
    })
  }
  nextPage(): void {
    if (this.pageNumber < this.totalPages) {
      this.pageNumber++;
      this.clients();
    }
  }

  prevPage(): void {
    if (this.pageNumber > 1) {
      this.pageNumber--;
      this.clients();
    }
  }
  get totalitems(): number {
    return Math.ceil(this.totalPages / this.pageSize);
  }


  deleteClient(id:number){
    this.clientservice.DeleteClient(id).subscribe({
      next:(d) => {
        this.reload();
      }
    })
  }
  reload(){
    this.clients();
  }

  exportexcel(): void
  {
    let element = document.getElementById('excel-table');
    const ws: XLSX.WorkSheet =XLSX.utils.table_to_sheet(element);
    const wb: XLSX.WorkBook = XLSX.utils.book_new();
    XLSX.utils.book_append_sheet(wb, ws, 'Sheet1');
    XLSX.writeFile(wb, "ExcelSheet.xlsx");
  }

  PrintTable(){
    window.print();
  }

  editclient(Eclient:Client){
    this.router.navigateByUrl('/clientedit',{state:{client:Eclient}});
  }
}
