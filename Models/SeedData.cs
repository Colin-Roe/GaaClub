using GaaClub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaaClub.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Member.Any())
                {
                    return;   // DB has been seeded
                }

                context.Member.AddRange(
                    new Member
                    {
                        FirstName = "Colin",
                        LastName = "Roe",
                        DateOfBirth = DateTime.Parse("1989-5-10"),
                        Gender = 1,
                        Email = "secretary.stuttgart.europe@gaa.ie"
                    },

                    new Member
                    {
                        FirstName = "Dave",
                        LastName = "Jones",
                        DateOfBirth = DateTime.Parse("1992-5-10"),
                        Gender = 1
                    },

                    new Member
                    {
                        FirstName = "Alana",
                        LastName = "Henderson",
                        DateOfBirth = DateTime.Parse("1994-5-10"),
                        Gender = 0
                    },

                    new Member
                    {
                        FirstName = "Felix",
                        LastName = "Green",
                        DateOfBirth = DateTime.Parse("1991-6-21"),
                        Gender = 1,
                        Email = "chairperson.stuttgart.europe@gaa.ie"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
