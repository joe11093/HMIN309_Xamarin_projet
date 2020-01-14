using System;
using System.Collections.Generic;
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

        public Task<List<Message>> GetMessagesAsync()
        {
            return restService.RefreshDataAsync();
        }
    }


}
