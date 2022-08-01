namespace FourBlog_Lucas.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private Areas.Identity.Data.FourBlog_LucasContext _context;

        public UsuarioRepository(Areas.Identity.Data.FourBlog_LucasContext context)
        {
            _context = context;
        }
    }
}
