﻿using System;
using FluentValidation;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patients.Domain.Validations
{
    public class PatientValidation : AbstractValidator<Patient>
    {
        public PatientValidation()
        {
            ValidateBirthDate();
            ValidateCpf();
            ValidateEmail();
            ValidateCpfLength();
            ValidateId();
            ValidatePhone();
            ValidateFullName();
        }

        private void ValidateBirthDate()
        {
            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Please fill patient's birthdate.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Please add valid birthdate.");
        }

        private void ValidateCpf()
        {
            RuleFor(p => p.Cpf)
                .Must(cpf => new CPF(cpf).IsValid()).WithMessage("Please insert a valid CPF.");
        }

        private void ValidateCpfLength()
        {
            RuleFor(p => p.Cpf)
                .Length(11).WithMessage("CPF must be 11 characters long.");
        }

        private void ValidateEmail()
        {
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("Please insert a valid email.")
                .MaximumLength(100).WithMessage("Email can't have more than 100 characters.");
        }

        private void ValidateFullName()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("Please ensure you have entered the full name")
                .Length(2, 150).WithMessage("Patient name must have between 2 and 150 characters");
        }

        private void ValidateId()
        {
            RuleFor(p => p.Id)
                .NotEqual(Guid.Empty);
        }

        private void ValidatePhone()
        {
            RuleFor(p => p.Phone)
                .MaximumLength(20).WithMessage("Phone number can't have more than 20 characters.")
                .NotEmpty().WithMessage("Please add a phone number.")
                .NotNull().WithMessage("Please add a phone number.");
        }
    }
}