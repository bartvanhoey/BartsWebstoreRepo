using System.ComponentModel.DataAnnotations;

namespace BartsWebstore.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}