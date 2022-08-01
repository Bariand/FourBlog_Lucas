using FourBlog_Lucas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FourBlog_Lucas.Areas.Identity.Data;

public class FourBlog_LucasContext : IdentityDbContext<Usuario>
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Postagem> Postagens { get; set; }
    public DbSet<Comentario> Comentarios { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public FourBlog_LucasContext(DbContextOptions<FourBlog_LucasContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //modelBuilder.Entity<Comentario>().HasKey(c => new { c.UsuarioId, c.PostagemId, c.DataHora });

        base.OnModelCreating(builder);

        //Configurar o relacionamento da associativa com o Usuario
        builder.Entity<Comentario>()
            .HasOne(c => c.Usuario)
            .WithMany(u => u.Comentarios)
            .HasForeignKey(c => c.UsuarioId);

        //Configura o relacionamento da associativa com a Postagem
        builder.Entity<Comentario>()
            .HasOne(c => c.Postagem)
            .WithMany(p => p.Comentarios)
            .HasForeignKey(c => c.PostagemId);
    }
}
