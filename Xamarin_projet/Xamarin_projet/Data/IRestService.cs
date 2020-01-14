using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Xamarin_projet
{
    public interface IRestService
    {
        Task<ObservableCollection<Message>> RefreshDataAsync();
    }
}
