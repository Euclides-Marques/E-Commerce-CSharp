using Microsoft.AspNetCore.Identity;

namespace DevMarket.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid UsuarioId { get; set; }
    }
}
