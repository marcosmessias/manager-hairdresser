import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthLayoutComponent } from './shared/layouts/auth-layout/auth-layout.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { SharedModule } from '@app/shared/shared.module';
import { PasswordRecoveryComponent } from './views/password-recovery/password-recovery.component';

@NgModule({
  declarations: [LoginComponent, RegisterComponent, AuthLayoutComponent, PasswordRecoveryComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    BrowserModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  exports: [AuthRoutingModule],
})
export class AuthModule {}
