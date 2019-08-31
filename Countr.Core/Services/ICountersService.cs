using System.Collections.Generic;
using System.Threading.Tasks;
using Countr.Core.Models;

namespace Countr.Core.Services
{
    public interface ICountersService
    {
        Task<Counter> AddNewCounter(string account, string password);
        Task<List<Counter>> GetAllCounters();
        Task DeleteCounter(Counter counter);
        Task IncrementCounter(Counter counter);
    }
}