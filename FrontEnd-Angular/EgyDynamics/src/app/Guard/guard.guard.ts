import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const guardGuard: CanActivateFn = (route, state) => {
  let t = localStorage.getItem("token")
  if(t != null){
    const router = inject(Router);
    router.navigateByUrl('/clients');
    return false;
  }
  return true;
};
