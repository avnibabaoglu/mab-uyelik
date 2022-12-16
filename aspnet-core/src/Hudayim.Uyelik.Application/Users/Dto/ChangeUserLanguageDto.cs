using System.ComponentModel.DataAnnotations;

namespace Hudayim.Uyelik.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}