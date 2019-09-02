using System.Threading.Tasks;
using Countr.Core.Models;
using Countr.Core.Services;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace Countr.Core.ViewModels
{
    public class CounterViewModel : MvxViewModel<Counter>
    {
        Counter counter;
        readonly ICountersService service;
        readonly IMvxNavigationService navigationService;

        public CounterViewModel(ICountersService service, IMvxNavigationService navigationService)
        {
            this.service = service;
            this.navigationService = navigationService;
            DeleteCommand = new MvxAsyncCommand(DeleteAccount);
            CancelCommand = new MvxAsyncCommand(Cancel);
            SaveCommand = new MvxAsyncCommand(Save);
        }

        public IMvxAsyncCommand DeleteCommand { get; }

        async Task DeleteAccount()
        {
            await service.DeleteAccount(counter);
        }

        public override void Prepare(Counter counter)
        {
            this.counter = counter;
        }

        public string Name
        {
            get { return counter.Name; }
            set
            {
                if (Name == value) return;
                counter.Name = value;
                RaisePropertyChanged();
            }
        }

		public string Account
		{
			get { return counter.Account; }
			set
			{
				if (Account == value) return;
				counter.Account = value;
				RaisePropertyChanged();
			}
		}

		public string Password
		{
			get { return counter.Password; }
			set
			{
				if (Password == value) return;
				counter.Password = value;
				RaisePropertyChanged();
			}
		}

		public int Count => counter.Count;

        public IMvxAsyncCommand CancelCommand { get; }
        public IMvxAsyncCommand SaveCommand { get; }

        async Task Cancel()
        {
            await navigationService.Close(this);                            
        }

        async Task Save()
        {
            await service.AddNewCounter(counter.Account, counter.Password);                      
            await navigationService.Close(this);                            
        }
    }
}