using DemoApplication.Services.AuthServices;

namespace DemoApplication.Services.HostedServices
{
    public class StartupRoleHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public StartupRoleHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var roleService = scope.ServiceProvider.GetRequiredService<IAuthService>();
                await roleService.EnsureRolesExistAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
