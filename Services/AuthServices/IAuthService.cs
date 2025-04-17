
using DemoApplication.Data;
using DemoApplication.Server.Models;

namespace DemoApplication.Services.AuthServices
{
    public interface IAuthService
    {
        Task EnsureRolesExistAsync();
        Task<List<Admin>> GetAllAdmin();

        Task<List<UserWithRoles>> GetUsersWithRolesAsync();
        Task<UserWithRoles> GetUsersWithRolesByUserAsync(ApplicationUser user);
        Task<bool> SaveUserRoles(UserWithRoles user);

        Task<bool>AddnewEvent(EventModel events);
        Task<List<EventModel>>GetEvent();

        Task<EventModel> GetEventById(int eventId);

    }
}