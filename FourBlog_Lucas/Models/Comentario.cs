using FourBlog_Lucas.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FourBlog_Lucas.Models
{
    [Table("Tbl_Comentario")]
    public class Comentario
    {
        [Column("Id"), Required]
        public int ComentarioId { get; set; }
        [Required(ErrorMessage = "Você não pode postar um comentário vazio.")]
        public string Texto { get; set; }
        public DateTime? DataHora { get; set; }


        //Relacionamento N : 1
        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }


        //Relacionamento N : 1
        public int? PostagemId { get; set; }
        public Postagem? Postagem { get; set; }


        public Comentario()
        {
            DataHora = DateTime.Now;
        }
    }
}