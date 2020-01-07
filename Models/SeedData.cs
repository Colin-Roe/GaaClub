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
                // Look for any FeeTypes.
                if (context.FeeTypes.Any())
                {
                    return;
                }

                var feeTypes = new FeeType[]
                {
                    new FeeType
                    {
                        Type = "Full",
                        Description = "Full Membership",
                        FeeCost = 40
                    },
                    new FeeType
                    {
                        Type = "Student",
                        Description = "Full Membership",
                        FeeCost = 20
                    }
                };

                foreach (FeeType f in feeTypes)
                {
                    context.FeeTypes.Add(f);
                }
                context.SaveChanges();

                // Look for any movies.
                if (context.Members.Any())
                {
                    return;   // DB has been seeded
                }

                context.Members.AddRange(
                    new Member
                    {
                        FirstName = "Colin",
                        LastName = "Roe",
                        UserId = 100000,
                        DateOfBirth = DateTime.Parse("1989-5-10"),
                        Gender = GenderType.Male,
                        Email = "secretary.stuttgart.europe@gaa.ie",
                        Registered = 1,
                        // See The member entity has a foreign key property FeeId which points to the related FeeType entity and it has a FeeType navigation property.
                        FeeID = feeTypes.Single(f => f.Type == "Full").FeeID
                    },

                    new Member
                    {
                        FirstName = "Dave",
                        LastName = "Jones",
                        UserId = 100001,
                        DateOfBirth = DateTime.Parse("1992-5-10"),
                        Gender = GenderType.Male,
                        Registered = 1,
                        FeeID = feeTypes.Single(f => f.Type == "Full").FeeID
                    },

                    new Member
                    {
                        FirstName = "Alana",
                        LastName = "Henderson",
                        UserId = 100002,
                        DateOfBirth = DateTime.Parse("1994-5-10"),
                        Gender = GenderType.Female,
                        Registered = 1,
                        FeeID = feeTypes.Single(f => f.Type == "Student").FeeID
                    },

                    new Member
                    {
                        FirstName = "Felix",
                        LastName = "Green",
                        UserId = 100003,
                        DateOfBirth = DateTime.Parse("1991-6-21"),
                        Gender = GenderType.None,
                        Email = "chairperson.stuttgart.europe@gaa.ie",
                        Registered = 0
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
