using Domain.Entities;
using Domain.Enums;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence.Context;

namespace WebAPI.Controllers
{
    public class SeedController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly DataContext _dataContext;

        public SeedController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, DataContext dataContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dataContext = dataContext;
        }

        [HttpPost("SeedRoles")]
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

            var user3 = new AppUser()
            {
                UserName = "yp@gmail.com",
                FirstName = "Yurii",
                LastName = "Pasternak",
                Email = "yp@gmail.com",
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

            var result3 = await _userManager.CreateAsync(user3, "11111111_Aa");
            if (result3.Succeeded)
            {
                //add this to add role to user
                await _userManager.AddToRoleAsync(user3, "Client");
            }

            return Ok();
        }

        [HttpPost("SeedLocation")]
        public async Task<IActionResult> SeedLocation(CancellationToken cancellationToken)
        {
            var region = new Location()
            {
                Id = Guid.Parse("f29d1388-85b1-4bfa-8b83-14241e6700b2"),
                Name = "Lviv",
                LocationTypeId = LocationTypeEnum.Region
            };

            var district = new Location()
            {
                Id = Guid.Parse("87a4fff2-3416-467a-ab38-3c8cd496ca2f"),
                RegionId = region.Id,
                Name = "Lviv",
                LocationTypeId = LocationTypeEnum.District
            };

            var city = new Location()
            {
                Id = Guid.Parse("5ace7baf-4610-40f3-8e81-e459ae01bd49"),
                RegionId = region.Id,
                DistrictId = district.Id,
                Name = "Lviv",
                LocationTypeId = LocationTypeEnum.City
            };

            var cityArea = new Location()
            {
                Id = Guid.Parse("4b929af1-8eae-43ab-ab2b-a629641840e2"),
                RegionId = region.Id,
                DistrictId = district.Id,
                CityId = city.Id,
                Name = "Lychakivskiy",
                LocationTypeId = LocationTypeEnum.CityArea
            };

            var street = new Location()
            {
                Id = Guid.Parse("9ca39891-c82b-400b-bca1-8ea70b5e2c82"),
                RegionId = region.Id,
                DistrictId = district.Id,
                CityId = city.Id,
                CityAreaId = cityArea.Id,
                Name = "Kravchuka",
                LocationTypeId = LocationTypeEnum.Street
            };

            _dataContext.AddRange(region, district, city, cityArea, street);
            await _dataContext.SaveChangesAsync(cancellationToken);

            return Ok();
        } 
    }
}
