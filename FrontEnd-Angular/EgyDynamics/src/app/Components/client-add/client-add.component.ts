import { Component } from '@angular/core';
import { ClientComponent } from '../client/client.component';
import { Client } from '../../Models/client';
import { ClientService } from '../../Services/client.service';
import { FormsModule } from '@angular/forms';
import { ClientAdd } from '../../Models/client-add';
import { Router } from '@angular/router';

@Component({
  selector: 'app-client-add',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './client-add.component.html',
  styleUrl: './client-add.component.css'
})
export class ClientAddComponent {
  constructor(private clientService:ClientService,private router:Router){}
  newClient: ClientAdd = new ClientAdd("", "", "", "", null, null, null, null, "", "", "", "", "", "", "", "", "");
  SaveClient(){
    this.newClient['تاريخالادخال']= new Date();
    this.newClient['ادخالبواسطة']= 1;
    console.log(this.newClient)
    this.clientService.Addclient(this.newClient).subscribe({
      next:(d)=>  this.BackToTable()
    })
    
  }
  BackToTable(){
    this.router.navigateByUrl('/clients');
  }
}
