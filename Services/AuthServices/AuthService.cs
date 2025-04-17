

using DemoApplication.Data;
using DemoApplication.Server.Data;
using DemoApplication.Server.Models;
using DemoApplication.Services.AuthServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DemoApplication.Server.AuthService
{
    public class AuthService:IAuthService
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AuthService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task EnsureRolesExistAsync()
        {
            foreach (var role in AuthenticationInitalData.AppRoles)
            {
                if (!await _roleManager.RoleExistsAsync(role.Name))
                {
                    await _roleManager.CreateAsync(role);
                }
            }
        }
        public async Task<bool> SaveUserRoles(UserWithRoles user)
        {
            var userToUpdate = await _userManager.FindByIdAsync(user.UserId);
            if (userToUpdate != null)
            {
                var userWithOldRoles = await GetUsersWithRolesByUserAsync(userToUpdate);
                if (!string.IsNullOrEmpty(userWithOldRoles.RoleName))
                {
                    await _userManager.RemoveFromRoleAsync(userToUpdate, userWithOldRoles.RoleName);
                }

                if (!string.IsNullOrEmpty(user.RoleName)) {
                    await _userManager.AddToRoleAsync(userToUpdate, user.RoleName);
                }
                return true;
            }
            return false;
        }
        public async Task<List<UserWithRoles>> GetUsersWithRolesAsync()
        {
            var users = _userManager.Users.ToList();
            var userWithRolesList = new List<UserWithRoles>();

            foreach (var user in users)
            {
                var userWithRoles = new UserWithRoles
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };
                var roles = await _userManager.GetRolesAsync(user);
                if(roles.Count > 0)
                {
                    userWithRoles.RoleName = roles.FirstOrDefault();
                }
                userWithRolesList.Add(userWithRoles);
            }

            return userWithRolesList;
        }
        public async Task<UserWithRoles> GetUsersWithRolesByUserAsync(ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            return new UserWithRoles
            {
                UserId = user.Id,
                UserName = user.UserName,
                RoleName = roles.FirstOrDefault()
            };
        }


        public async Task<bool> AddnewEvent(EventModel events) 
        {
            _context.Events.Add(events);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        public async Task<List<EventModel>> GetEvent()
        {
            try
            {
                return await _context.Events.ToListAsync();
            }
            catch (Exception ex) {
            return new List<EventModel>();
            }
        }

        public async Task<List<Admin>> GetAllAdmin()
        {
            try
            {
                var Admin = _userManager.Users.ToList();
                var AdminList = new List<Admin>();

                foreach (var user in Admin)
                {
                    var admin = new Admin
                    {
                        AdminID = user.Id,
                        Email = user.UserName,
                        Name = user.FullName,
                        Phone = user.PhoneNumber,
                        Password = user.PasswordHash,
                        createdOn = user.createdOn,
                        Status = user.status,
                    };
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Count > 0)
                    {
                        admin.Role = roles.FirstOrDefault();
                    }
                    AdminList.Add(admin);
                }
                return AdminList;
            }
            catch (Exception ex)
            {
                throw;
            }

        }


        public async Task<EventModel> GetEventById(int eventId)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
        }


    }
}
