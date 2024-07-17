using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NetCareer.Models;
using NetCareer.Utilities;

namespace NetCareer.Data.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IDbContextFactory<ApplicationDbContext> contextFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<DbInitializer> logger;

        public DbInitializer(
            IDbContextFactory<ApplicationDbContext> contextFactory,
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            ILogger<DbInitializer> logger)
        {
            this.contextFactory = contextFactory;
            _userManager = userManager;
            _roleManager = roleManager;
            this.logger = logger;
        }
        public void Initialize()
        {
            //migrations if they are not applied
            MigrationApplier();

            //create roles if they are not created
            InitializeRoles();
            InitializeAdmin();
        }

        private void MigrationApplier()
        {
            try
            {
                using var _db = this.contextFactory.CreateDbContext();
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Log the exception details
                logger.LogError(ex, "An error occurred while applying migrations at {Time}", DateTime.Now);
                throw;
            }
        }

        private void InitializeRoles()
        {
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_JobSeeker)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(SD.Role_Recruiter)).GetAwaiter().GetResult();
            }
        }        
        
        private void InitializeAdmin()
        {
            var adminTotal = _userManager.GetUsersInRoleAsync(SD.Role_Admin).GetAwaiter().GetResult();

            if (adminTotal.Count > 0) return;

            ApplicationUser admin = new ApplicationUser()
            {
                UserName = "admin@admin",
                Email = "admin@admin"
            };

            var result = _userManager.CreateAsync(admin, "Admin121!").GetAwaiter().GetResult();

            if (!result.Succeeded)
            {
                foreach(var err in result.Errors)
                {
                    logger.LogError($"An error occurred while creating Admin account - {err.Code}: {err.Description}");
                }
                return;
            }

            logger.LogInformation("Admin account was created Successfully");

            _userManager.AddToRoleAsync(admin, SD.Role_Admin).GetAwaiter().GetResult();
        }
    }
}
