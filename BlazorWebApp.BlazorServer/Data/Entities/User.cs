using System.ComponentModel.DataAnnotations;

namespace BlazorWebApp.BlazorServer.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(25)]

        public string FirstName { get;set;}

        [MaxLength(25)]

        public string? LastName { get; set;}

        [Required, MaxLength(100)]
        public string Email { get; set;}

        [Required, MaxLength(30)]
        public string Salt { get; set; }

        [Required, MaxLength(125)]
        public string Hash { get; set; }
    }

}
