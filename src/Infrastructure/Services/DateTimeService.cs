using SunderTest.Application.Common.Interfaces;
using System;

namespace SunderTest.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
