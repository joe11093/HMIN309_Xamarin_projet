using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Xamarin_projet
{
    public class MessageManager
    {
        IRestService restService;

        public MessageManager(IRestService restService)
        {
            this.restService = restService;
        }

        public Task<ObservableCollection<Message>> GetMessagesAsync()
        {
            return restService.RefreshDataAsync();
        }
    }


}
