import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { LoginModel } from './login.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.createForm(new LoginModel());
  }

  createForm(loginModel: LoginModel) {
    this.form = this.formBuilder.group({
      email: new FormControl(loginModel.email, [
        Validators.required,
        Validators.email,
        Validators.pattern(
          /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        ),
      ]),
      password: new FormControl(loginModel.password, [
        Validators.required,
        Validators.minLength(6),
        Validators.maxLength(20),
        Validators.pattern('^[a-zA-Z0-9]+$'),
      ]),
    });
  }

  onSubmit() {
    console.log(this.form.value);
    this.form.reset(new LoginModel());
  }
}
