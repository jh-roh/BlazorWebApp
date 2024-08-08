using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.BlazorServer.Models
{
    public class LoginModel
    {
        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required, MinLength(5)]
        public string Password { get; set; }
    }

    public class BlogSaveModel
    {

    }
}
