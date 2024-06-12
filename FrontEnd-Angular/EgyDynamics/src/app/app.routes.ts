import { Routes } from '@angular/router';
import { ClientComponent } from './Components/client/client.component';
import { ClientAddComponent } from './Components/client-add/client-add.component';
import { ClientEditComponent } from './Components/client-edit/client-edit.component';
import { LoginComponent } from './Components/login/login.component';
import { guardGuard } from './Guard/guard.guard';
import { guard2Guard } from './Guard/guard2.guard';

export const routes: Routes = [
    {path:"clientadd",component:ClientAddComponent, title:"Add",canActivate: [guard2Guard]},
    {path:"clientedit",component:ClientEditComponent, title:"Edit",canActivate: [guard2Guard]},
    {path:"clients",component:ClientComponent,title:"Clients",canActivate: [guard2Guard]},
    {path:"",component:LoginComponent, title:"EgyDynamics",canActivate: [guardGuard]}
];
