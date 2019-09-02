using System.Collections.Generic;
using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Repositories;
using MvvmCross.Plugins.Messenger;

namespace Countr.Core.Services
{
    public class CountersService : ICountersService
    {
        readonly ICountersRepository repository;
        readonly IMvxMessenger messenger;

        public CountersService(ICountersRepository repository,
                               IMvxMessenger messenger)
        {
            this.messenger = messenger;
            this.repository = repository;
        }

        public async Task<Counter> AddNewCounter(string account, string password)
        {
            var counter = new Counter { Account = account, Password = password };
            await repository.Save(counter).ConfigureAwait(false);
            messenger.Publish(new CountersChangedMessage(this));
            return counter;
        }

        public Task<List<Counter>> GetAllCounters()
        {
            return repository.GetAll();
        }

        public async Task DeleteAccount(Counter counter)
        {
            await repository.Delete(counter).ConfigureAwait(false);
            messenger.Publish(new CountersChangedMessage(this));
        }
    }
}