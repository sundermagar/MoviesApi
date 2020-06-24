using SunderTest.Application.Common.Exceptions;
using SunderTest.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using SunderTest.Application.Genres.Commands.DeleteGenres;
using Microsoft.Azure.Documents.SystemFunctions;

namespace SunderTest.Application.IntegrationTests.Genres.Commands
{
    using static Testing;

    public class DeleteGenresTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteGenresCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

    }
}
