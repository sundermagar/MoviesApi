using SunderTest.Application.Common.Exceptions;
using SunderTest.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;
using SunderTest.Application.Genres.Commands.UpdateGenres;

namespace SunderTest.Application.IntegrationTests.Genres.Commands
{
    using static Testing;

    public class UpdateGenresTests : TestBase
    {
        [Test]
        public async Task UpdateGenres()
        {
            var command = new UpdateGenresCommand
            {
                Id = 1,
                Name = "New Title",
                Description = "New Title"

            };
            FluentActions.Invoking(() =>
                    SendAsync(command)).Should().Throw<NotFoundException>();
        }

        
    }
}
