using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Xamarin_projet
{
    public interface IRestService
    {
        Task<List<Message>> RefreshDataAsync();
    }
}
