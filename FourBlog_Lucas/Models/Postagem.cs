using FourBlog_Lucas.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourBlog_Lucas.Models
{
    [Table("Tbl_Postagem")]
    public class Postagem
    {
        [Column("Id"), Required]
        public int PostagemId { get; set; }
        [Required(ErrorMessage = "Sua história necessita de um título.")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "É preciso escrever um texto para postar.")]
        public string Texto { get; set; }
        public DateTime? DataCriacao { get; set; }


        //Relacionamento N : 1
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }


        //Relacionamento N : 1
        public int TagId { get; set; }
        public Tag Tag { get; set; }


        //Relacionamento 1 : N
        public ICollection<Comentario>? Comentarios { get; set; }


        public Postagem()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
