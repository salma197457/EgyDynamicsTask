import { Component } from '@angular/core';
import { ClientComponent } from '../client/client.component';
import { Router } from '@angular/router';
import { ClientService } from '../../Services/client.service';
import { ClientAdd } from '../../Models/client-add';
import { Client } from '../../Models/client';
import { FormsModule } from '@angular/forms';
import { AccountLogInService } from '../../Services/account-log-in.service';

@Component({
  selector: 'app-client-edit',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './client-edit.component.html',
  styleUrl: './client-edit.component.css'
})
export class ClientEditComponent {
  Eclient:Client= new Client(0,"","","","","","",null,null,"","","","","","","","","");;

  constructor(private router:Router , private clientService:ClientService,private acc:AccountLogInService){
    const nav = this.router.getCurrentNavigation();
    if(nav?.extras?.state){
      this.Eclient=nav.extras.state['client']
    }
  }
  SaveClient(){
    this.Eclient['اخرتعديلفي']=new Date();
    this.Eclient['اخرتعديل']=+this.acc.r.id;
    this.clientService.GetClientById(this.Eclient['كودالعميل']).subscribe({
      next:(d)=>{
        this.Eclient['ادخالبواسطة']=d['ادخالبواسطة'];
        this.clientService.EditClient(this.Eclient).subscribe({
          next:(d)=> this.router.navigateByUrl("/clients")
        })
      }
      })
    // console.log(this.Eclient)
    }
    
  BackToTable(){
    this.router.navigateByUrl('/clients')
  }

  
}
