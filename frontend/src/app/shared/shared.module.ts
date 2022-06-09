import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LocalStorageService } from './services/local-storage.service';
import { ErrorTailorModule } from '@ngneat/error-tailor';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    ErrorTailorModule.forRoot({
      errors: {
        useValue: {
          required: 'Este campo é obrigatório',
          minlength: ({ requiredLength }) =>
            `O campo deve conter no mínimo ${requiredLength} caracteres.`,
          maxlength: ({ requiredLength }) =>
            `O campo deve conter no máximo ${requiredLength} caracteres.`,
          email: 'E-mail inválido',
          pattern: 'Este campo não é válido',
          mustMatch: 'Os campos não são iguais',
        },
      },
    }),
  ],
  exports: [ErrorTailorModule],
  providers: [LocalStorageService],
})
export class SharedModule {}
