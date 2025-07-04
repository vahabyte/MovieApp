using System.ComponentModel.DataAnnotations;

namespace MovieApp.Validators
{
    public class EmailProvidersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = "";
            if (value != null)
            {
                email = value.ToString();
            }

            if (email.EndsWith("@hotmail.com") || email.EndsWith("@gmail.com") || email.EndsWith("@outlook.com"))
            {
                 return ValidationResult.Success;
            }          
            return new ValidationResult("Girilen e-posta sunucuları kabul edilmiyor.");
        }
    }
}
