using DevMarket.Interfaces;
using DevMarket.Models;
using Microsoft.AspNetCore.Identity;

namespace DevMarket.Repositories
{
    public class ServiceUserRoleRepository : IServiceUserRoleRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ServiceUserRoleRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = role.Name.ToUpper();
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Cliente").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Cliente";
                role.NormalizedName = role.Name.ToUpper();
                IdentityResult result = _roleManager.CreateAsync(role).Result;
            }
        }

        public void SeedUsers()
        {
            if (_userManager.FindByNameAsync("Euclides").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Euclides";
                user.NormalizedUserName = user.UserName.ToUpper();
                user.Email = "euclides.marques@devmarket.com.br";
                user.NormalizedEmail = user.Email.ToUpper();
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.UsuarioId = Guid.NewGuid();

                IdentityResult result = _userManager.CreateAsync(user, "DevMarket@2025").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "admin").Wait();
                }
            }
        }
    }
}
