import { Inject, Injectable } from '@angular/core';
import {
  Router,
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
} from '@angular/router';

import { AuthenticationService } from '@app/shared/services/authentication.service';

@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
  constructor(
    private router: Router,
    @Inject(AuthenticationService)
    private authenticationService: AuthenticationService
  ) {}

  canActivate(_route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const currentUser = this.authenticationService.currentUserValue;
    if (currentUser) {
      return true;
    }

    this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
