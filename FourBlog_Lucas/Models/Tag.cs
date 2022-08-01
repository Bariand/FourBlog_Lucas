using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourBlog_Lucas.Models
{
    [Table("Tbl_Tag")]
    public class Tag
    {
        [Column("Id"), Required]
        public int TagId { get; set; }
        [Required(ErrorMessage = "A Tag necessita de um nome.")]
        public string Nome { get; set; }

        //Relacionamento 1 : N
        public ICollection<Postagem>? Postagens { get; set; }
    }
}