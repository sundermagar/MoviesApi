using SunderTest.Domain.Entities;
using SunderTest.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Configuration;
using System.Text;
using System.Net.Http.Headers;

namespace SunderTest.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static IConfiguration configuration;
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUser = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

            if (userManager.Users.All(u => u.UserName != defaultUser.UserName))
            {
                await userManager.CreateAsync(defaultUser, "Administrator1!");
            }
        }


    }
}
