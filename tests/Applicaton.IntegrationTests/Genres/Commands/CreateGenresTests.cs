using SunderTest.Application.Common.Exceptions;
using SunderTest.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SunderTest.Application.Genres.Commands.CreateGenres;
using Microsoft.Azure.Documents.SystemFunctions;

namespace SunderTest.Application.IntegrationTests.Genres.Commands
{
    using static Testing;

    public class CreateGenresTests : TestBase
    {
        
        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var command = new CreateGenresCommand
            {
                Name = "New List",
                Description = "Tasks"
            };

            var itemId = await SendAsync(command);
            itemId.Should();
        }
    }
}
