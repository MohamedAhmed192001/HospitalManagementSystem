using HospitalManagementSystem.Domain.Constants;
using HospitalManagementSystem.Domain.Entities;
using HospitalManagementSystem.Domain.Enums;
using HospitalManagementSystem.Domain.ValueObjects;
using HospitalManagementSystem.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;


namespace HospitalManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task InitialiseAsync()
        {
            try
            {
                // See https://jasontaylor.dev/ef-core-database-initialisation-strategies

                await _context.Database.EnsureDeletedAsync();
                await _context.Database.EnsureCreatedAsync();
            
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch(Exception  ex)
            {
                _logger.LogError(ex, "An error occured while seeding the database.");
                throw;
            }
        }



        public async Task TrySeedAsync()
        {
            // Default roles
            var administratorRole = new IdentityRole(Roles.Administrator);

            if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await _roleManager.CreateAsync(administratorRole);
            }

            // default users
            var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if(_userManager.Users.All(u => u.Email != administrator.Email))
            {
                await _userManager.CreateAsync(administrator, "Administrator1!");
            
                if(!string.IsNullOrWhiteSpace(administratorRole.Name))
                {
                    await _userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name});
                }
            }

            // Default data
            // Seed, if necessary

            if(!_context.Doctors.Any())
            {
                _context.Doctors.Add(new Doctor
                {
                    FirstName = "Mohamed",
                    LastName = "Ahmed",
                    Email = "Mohamed@gmail.com",
                    Address = new Address("street 10", "Itsa", "Fayoum", "Egypt", "MO12"),
                    PhoneNumber = "01211252477",
                    Specialization = DoctorSpecialization.Pediatrics,
                });
            }

            if (!_context.Patients.Any())
            {
                _context.Patients.Add(new Patient
                {
                    FirstName = "Mohamed",
                    LastName = "Ahmed",
                    Email = "Mohamed@gmail.com",
                    PhoneNumber = "01211252477",
                    Gender = Gender.Male,
                    DateOfBirth = DateTime.Now,
                });
            }


        }

    }
}
