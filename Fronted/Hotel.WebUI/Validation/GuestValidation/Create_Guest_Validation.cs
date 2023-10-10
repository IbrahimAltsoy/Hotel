using FluentValidation;
using Hotel.WebUI.Dtos.GuestDto;

namespace Hotel.WebUI.Validation.GuestValidation
{
    public class Create_Guest_Validation : AbstractValidator<CreateGuestDto>
    {
        public Create_Guest_Validation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanını boş geçmeyiniz")
                .MinimumLength(2).WithMessage("En az iki karakter giriniz")
                .MaximumLength(25).WithMessage("En fazla 25 karakter girebilirsiniz");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanını boş geçmeyiniz")
                .MinimumLength(2).WithMessage("En az iki karakter giriniz")
                .MaximumLength(25).WithMessage("En fazla 25 karakter girebilirsiniz");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyad alanını boş geçmeyiniz")
                .MinimumLength(2).WithMessage("En az iki karakter giriniz")
                .MaximumLength(18).WithMessage("En fazla 25 karakter girebilirsiniz");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Soyad alanını boş geçmeyiniz")
                .MinimumLength(10).WithMessage("En az 10 karakter giriniz")
                .MaximumLength(11).WithMessage("En fazla 11 karakter girebilirsiniz");
            


        }
    }
}
