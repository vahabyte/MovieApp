using Microsoft.AspNetCore.Mvc;
using MovieApp.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
       
        [Required]
        [StringLength(40,ErrorMessage ="Kullanıcı adı 3-40 karakter arasında olmalıdır"),MinLength(3)]
        [Remote(action:"VerifyUserName",controller:"User")]
        public string UserName { get; set; }
       
        [Required]
        [StringLength(50, ErrorMessage = "{0} {2}-{1} karakter arasında olmalıdır"), MinLength(3)]
       
        public string Name { get; set; }
       
        [Required]
        [EmailAddress]
        [EmailProviders]
        public string Email { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
       
        public string Password { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Parola bilgileri aynı olmalıdır!")]
        public string RePassword { get; set; }
        
        [Url]        
        
        public string Url { get; set; }

        //[Range(1900,2010)]
        //public int BirthYear { get; set; }
        [BirthDate(ErrorMessage ="Doğum tarihiniz bugün veya bugünden sonra olamaz!")]
        public DateTime BirthDate { get; set; }

    }
}
