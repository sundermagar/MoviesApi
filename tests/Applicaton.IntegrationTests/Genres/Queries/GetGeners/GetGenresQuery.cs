using AutoMapper;
using AutoMapper.QueryableExtensions;
using SunderTest.Application.Common.Exceptions;
using SunderTest.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using SunderTest.Application.Genres.Commands.CreateGenres;
using Microsoft.Azure.Documents.SystemFunctions;
using SunderTest.Application.Genres.Queries.GetGenres;

namespace SunderTest.Application.IntegrationTests.Genres.Query
{
    using static Testing;
    public class GetGenresTests : TestBase
    {
        [Test]
        public async Task getQuery()
        {
            var command =await SendAsync( new GetGenresQuery());
           command.Should();
        }
    }

    
}
