using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Taxi.Domain.Models;

namespace Taxi.API.Data
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Users
            
            var hasher = new PasswordHasher<ApplicationUser>();
            var user1 = new ApplicationUser()
            {
                Id = "31588e97-5c6b-48dd-89a1-edd92deb3bcb"
            };
            var user2 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000001"
            };
            var user3 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000002"
            };
            var user4 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000003"
            };
            var user5 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000004"
            };
            var user6 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000010"
            };
            var user7 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000020"
            };
            var user8 = new ApplicationUser()
            {
                Id = "00000000-0000-0000-0000-000000000021"
            };
            var passwordHash = hasher.HashPassword(user1, "TaxiTest1?");
            var passwordHash2 = hasher.HashPassword(user2, "TaxiTest2?");
            var passwordHash3 = hasher.HashPassword(user3, "TaxiTest3?");
            var passwordHash4 = hasher.HashPassword(user4, "TaxiTest4?");
            var passwordHash5 = hasher.HashPassword(user5, "TaxiTest5?");
            var passwordHash6 = hasher.HashPassword(user6, "TaxiTest6?");
            var passwordHash7 = hasher.HashPassword(user7, "TaxiTest7?");
            var passwordHash8 = hasher.HashPassword(user8, "TaxiTest8?");

            #endregion

            #region Customers

            var customer1 = new Customer()
            {
                Id = user1.Id,
                FirstName = "Robbe",
                LastName = "Durnez",
                UserType = UserType.Customer
            };
            var customer2 = new Customer()
            {
                Id = user2.Id,
                FirstName = "Anthony",
                LastName = "Durnez",
                UserType = UserType.Customer
            };
            var customer7 = new Customer()
            {
                Id = user7.Id,
                FirstName = "User7",
                LastName = "Taxi",
                UserType = UserType.Customer
            };
            var customer8 = new Customer()
            {
                Id = user8.Id,
                FirstName = "User8",
                LastName = "Taxi",
                UserType = UserType.Customer
            };

            #endregion
            
            #region Companies

            var company1 = new Company()
            {
                Id = user5.Id,
                UserType = UserType.Company,
                Name = "Maxi Tarco",
                StartPrice = 5m,
                PricePerKm = 2m
            };
            
            var company2 = new Company()
            {
                Id = user6.Id,
                UserType = UserType.Company,
                Name = "Company 2",
                StartPrice = 10m,
                PricePerKm = 1.5m
            };

            #endregion

            #region Drivers

            var driver1 = new Driver()
            {
                Id = user3.Id,
                FirstName = "Taxi",
                LastName = "Driver1",
                Latitude = 51.0862,
                Longitude = 2.9764,
                IsActive = true,
                IsAvailable = true,
                CompanyId = user5.Id,
                UserType = UserType.Driver
            };
            
            var driver2 = new Driver()
            {
                Id = user4.Id,
                FirstName = "Taxi",
                LastName = "Driver200",
                Latitude = 51.0918,
                Longitude = 2.9746,
                IsActive = true,
                IsAvailable = false,
                CompanyId = user5.Id,
                UserType = UserType.Driver
            };

            #endregion
            
            #region Addresses

            var address1Id = "31588e97-5c6b-48dd-89a1-edd92deb3bbb";
            var address2Id = "31588e97-5c6b-48dd-89a1-edd92deb3ccc";
            var address3Id = Guid.NewGuid().ToString();

            #endregion

            #region Orders

            var order1 = new Order()
            {
                Id = "00000000-0000-0000-0000-000000000100",
                DriverId = driver1.Id,
                UserId = user1.Id,
                FromId = address1Id,
                ToId = address2Id,
                State = OrderState.Requested,
                CompanyId = company1.Id,
                TotalPrice = 25m
            };
            
            var order2 = new Order()
            {
                Id = "00000000-0000-0000-0000-000000000200",
                DriverId = driver1.Id,
                UserId = user1.Id,
                CompanyId = company1.Id,
                FromId = address1Id,
                ToId = address2Id,
                State = OrderState.Handled,
                TotalPrice = 20.38m
            };
            
            var order3 = new Order()
            {
                Id = "00000000-0000-0000-0000-000000000300",
                DriverId = driver1.Id,
                CompanyId = company1.Id,
                UserId = user1.Id,
                FromId = address1Id,
                ToId = address2Id,
                State = OrderState.Handled,
                TotalPrice = 21.45m
            };
            
            var order4 = new Order()
            {
                Id = "00000000-0000-0000-0000-000000000400",
                DriverId = driver1.Id,
                CompanyId = company1.Id,
                UserId = user1.Id,
                FromId = address1Id,
                ToId = address2Id,
                State = OrderState.Requested,
                TotalPrice = 19.04m
            };

            var order5 = new Order()
            {
                Id = "00000000-0000-0000-0000-000000000500",
                DriverId = driver1.Id,
                CompanyId = company1.Id,
                UserId = user1.Id,
                FromId = address1Id,
                ToId = address2Id,
                State = OrderState.Finalized,
                TotalPrice = 22m
            };
            
            #endregion

            #region Roles

            var adminRole = new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };
            var driverRole = new IdentityRole()
            {
                Name = "Driver",
                NormalizedName = "DRIVER"
            };
            var companyRole = new IdentityRole()
            {
                Name = "Company",
                NormalizedName = "COMPANY"
            };
            var customerRole = new IdentityRole()
            {
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            };
            var roles = new List<IdentityRole>()
            {
                adminRole,
                driverRole,
                companyRole,
                customerRole
            };

            #endregion

            #region Seeding
            
            modelBuilder.Entity<ApplicationUser>().HasData(
                new
                {
                    Id = user1.Id,
                    FirstName = customer1.FirstName,
                    LastName = customer1.LastName,
                    Email = "durnez.robbe@hotmail.com",
                    NormalizedEmail = "DURNEZ.ROBBE@HOTMAIL.COM",
                    UserName = "durnez.robbe@hotmail.com",
                    NormalizedUserName = "DURNEZ.ROBBE@HOTMAIL.COM",
                    PhoneNumber = "+32497635255",
                    PasswordHash = passwordHash,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new
                {
                    Id = user2.Id,
                    FirstName = customer2.FirstName,
                    LastName = customer2.LastName,
                    Email = "durnez.anthony@gmail.com",
                    NormalizedEmail = "DURNEZ.ANTHONY@GMAIL.COM",
                    UserName = "durnez.anthony@GMAIL.com",
                    NormalizedUserName = "DURNEZ.ANTHONY@gmail.COM",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash2,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new
                {
                    Id = user3.Id,
                    FirstName = driver1.FirstName,
                    LastName = driver1.LastName,
                    Email = "driver1@taxi.com",
                    NormalizedEmail = "DRIVER1@TAXI.COM",
                    UserName = "driver1@taxi.com",
                    NormalizedUserName = "DRIVER1@TAXI.COM",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash3,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new
                {
                    Id = user4.Id,
                    FirstName = driver2.FirstName,
                    LastName = driver2.LastName,
                    Email = "driver2@taxi.com",
                    NormalizedEmail = "DRIVER2@TAXI.COM",
                    UserName = "driver2@taxi.com",
                    NormalizedUserName = "DRIVER2@TAXI.COM",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash4,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new
                {
                    Id = user5.Id,
                    Email = "company1@taxi.com",
                    NormalizedEmail = "COMPANY1@TAXI.COM",
                    UserName = "Company1",
                    NormalizedUserName = "COMPANY1",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash5,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },
                new
                {
                    Id = user6.Id,
                    Email = "company2@taxi.com",
                    NormalizedEmail = "COMPANY2@TAXI.COM",
                    UserName = "Company2",
                    NormalizedUserName = "COMPANY2",
                    PhoneNumber = "+32497643255",
                    PasswordHash = passwordHash6,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },new
                {
                    Id = user7.Id,
                    Email = "customer7@taxi.com",
                    NormalizedEmail = "CUSTOMER7@TAXI.COM",
                    UserName = "customer7@taxi.com",
                    NormalizedUserName = "CUSTOMER7@TAXI.COM",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash7,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                },new
                {
                    Id = user8.Id,
                    Email = "customer8@taxi.com",
                    NormalizedEmail = "CUSTOMER8@TAXI.COM",
                    UserName = "customer8@taxi.com",
                    NormalizedUserName = "CUSTOMER8@TAXI.COM",
                    PhoneNumber = "+32497645255",
                    PasswordHash = passwordHash8,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    AccessFailedCount = 0,
                    EmailConfirmed = false,
                    LockoutEnabled = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                });

            modelBuilder.Entity<Customer>().HasData(
                customer1,
                customer2,
                customer7,
                customer8);

            modelBuilder.Entity<Company>().HasData(
                company1,
                company2);

            modelBuilder.Entity<Driver>().HasData(
                driver1,
                driver2);
            
            modelBuilder.Entity<Address>().HasData(
                new
                {
                    Id = address1Id,
                    AddressLine1 = "Provinciebaan 28",
                    AddressLine2 = "",
                    PostalCode = "8680",
                    City = "Koekelare",
                    UserId = user1.Id,
                    Latitude = 51.073039,
                    Longitude = 2.975749
                },
                new
                {
                    Id = address2Id,
                    AddressLine1 = "Kleine stationsstraat 12",
                    AddressLine2 = "",
                    PostalCode = "8680",
                    City = "Koekelare",
                    UserId = user1.Id,
                    Latitude = 51.091223,
                    Longitude = 2.974626
                },
                new
                {
                    Id = address3Id,
                    AddressLine1 = "Ringlaan 33",
                    AddressLine2 = "",
                    PostalCode = "8680",
                    City = "Koekelare",
                    UserId = user5.Id,
                    Latitude = 51.091837,
                    Longitude = 2.977001
                }
                );

            modelBuilder.Entity<Order>()
                .HasData(
                    order1,
                    order2, 
                    order3, 
                    order4,
                    order5);
            
            modelBuilder.Entity<IdentityRole>()
                .HasData(roles);

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                    new IdentityUserRole<string>()
                    {
                        RoleId = customerRole.Id,
                        UserId = user1.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = customerRole.Id,
                        UserId = user2.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = driverRole.Id,
                        UserId = user3.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = driverRole.Id,
                        UserId = user4.Id
                    },
                    new IdentityUserRole<string>()
                    {
                        RoleId = companyRole.Id,
                        UserId = user5.Id
                    });
            
            #endregion
        }
    }
}
