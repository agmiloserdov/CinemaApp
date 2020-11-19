using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Cinema.Models
{
    public class FilmViewModel
    {

        [Required(ErrorMessage = "Поле название обязательно для заполнения")]
        [MinLength(10, ErrorMessage = "Минимальная длина описания 10 символов")]
        [Display(Name = "Название фильма")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле описание обязательно для заполнения")]
        [MinLength(10, ErrorMessage = "Минимальная длина описания 10 символов")]
        [Display(Name = "Описание")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Загрузка фото обязательна")]
        [DataType(DataType.Upload)]
        [Display(Name = "Постер фильма")]
        public IFormFile File { get; set; }
        
        [Display(Name = "Название фильма")]
        public int PublishYear { get; set; }
    }
}