using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class SeedController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public SeedController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }

        [HttpPost]
        public async Task<ActionResult> SeedRoles()
        {
            if (!_roleManager.RoleExistsAsync("Client").Result)
            {
                var role = new AppRole();
                role.Name = "Client";
                await _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new AppRole();
                role.Name = "Administrator";
                await _roleManager.CreateAsync(role);
            }

            if (!_roleManager.RoleExistsAsync("Superuser").Result)
            {
                var role = new AppRole();
                role.Name = "Superuser";
                await _roleManager.CreateAsync(role);
            }

            return Ok();
        }

        [HttpPost("SeedUsers")]
        public async Task<ActionResult> SeedUsers()
        {
            var user1 = new AppUser()
            {
                UserName = "ao@gmail.com",
                FirstName = "Olga",
                LastName = "Aleksandrovych",
                Email = "ao@gmail.com",
                EmailConfirmed = true
            };

            var user2 = new AppUser()
            {
                UserName = "su@gmail.com",
                FirstName = "Superuser",
                LastName = "Superuser",
                Email = "su@gmail.com",
                EmailConfirmed = true
            };

            var result1 = await _userManager.CreateAsync(user1, "11111111_Aa");
            if (result1.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user1, "Administrator");
            }

            var result2 = await _userManager.CreateAsync(user2, "11111111_Aa");
            if (result2.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user2, "Superuser");
            }

            return Ok();
        }
    }
}
