using System;
using System.Collections.Generic;
using System.Text;
using GaaClub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GaaClub.ViewModels;
using GaaClub.Auth;

namespace GaaClub.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }

        public DbSet<AddUserViewModel> AddUserViewModel { get; set; }
    }
}
