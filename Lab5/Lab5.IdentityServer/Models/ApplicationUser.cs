using Microsoft.AspNetCore.Identity;

namespace Lab5.IdentityServer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}

// Lab5.IdentityServer/Data/ApplicationDbContext.cs
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Lab5.IdentityServer.Models;

namespace Lab5.IdentityServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}