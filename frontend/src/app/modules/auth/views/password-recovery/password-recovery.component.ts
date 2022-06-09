import { Component, OnInit } from '@angular/core';
import {
  FormGroup,
  FormBuilder,
  FormControl,
  Validators,
} from '@angular/forms';
import { PasswordRecoveryModel } from './recovery-password.model';

@Component({
  selector: 'app-password-recovery',
  templateUrl: './password-recovery.component.html',
  styleUrls: ['./password-recovery.component.scss'],
})
export class PasswordRecoveryComponent implements OnInit {
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.createForm(new PasswordRecoveryModel());
  }

  createForm(loginModel: PasswordRecoveryModel) {
    this.form = this.formBuilder.group({
      email: new FormControl(loginModel.email, [
        Validators.required,
        Validators.email,
        Validators.pattern(
          /^[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/
        ),
      ]),
    });
  }

  onSubmit() {
    console.log(this.form.value);
    this.form.reset(new PasswordRecoveryModel());
  }
}
