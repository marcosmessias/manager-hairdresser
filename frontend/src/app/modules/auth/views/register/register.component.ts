import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { CustomValidators } from '@app/shared/validators/customValidators';
import { RegisterModel } from '../register/register.model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.createForm(new RegisterModel());
  }

  createForm(registerModel: RegisterModel) {
    this.form = this.formBuilder.group(
      {
        name: new FormControl(registerModel.name, [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(255),
        ]),
        nameSalon: new FormControl(registerModel.nameSalon, [
          Validators.required,
          Validators.minLength(3),
          Validators.maxLength(255),
        ]),
        email: new FormControl(registerModel.email, [
          Validators.required,
          Validators.email,
          Validators.pattern(
            /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
          ),
        ]),
        password: new FormControl(registerModel.password, [
          Validators.required,
          Validators.minLength(6),
          Validators.maxLength(20),
          Validators.pattern('^[a-zA-Z0-9]+$'),
        ]),
        passwordConfirmation: new FormControl(
          registerModel.passwordConfirmation,
          [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(20),
            Validators.pattern('^[a-zA-Z0-9]+$'),
          ]
        ),
      },
      {
        validator: CustomValidators.mustMatch(
          'password',
          'passwordConfirmation'
        ),
      }
    );
  }

  onSubmit() {
    console.log(this.form.value);
    this.form.reset(new RegisterModel());
  }
}
