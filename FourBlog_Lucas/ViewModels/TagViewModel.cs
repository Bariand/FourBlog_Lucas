using FourBlog_Lucas.Models;
using System.ComponentModel.DataAnnotations;

namespace FourBlog_Lucas.ViewModels
{
    public class TagViewModel
    {
        public ICollection<Tag> Tags { get; set; }
        public Tag Tag { get; set; }
        [Required(ErrorMessage = "A Tag necessita de um nome.")]
        public string Nome { get; set; }
    }
}
