using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using Xamarin_projet;

namespace Xamarin_projet
{
    public class MessageDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public MessageDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(Message).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(Message)).ConfigureAwait(false);
                    initialized = true;
                }
            }
        }

        public Task<List<Message>> GetMessagesAsync()
        {
            return Database.Table<Message>().ToListAsync();
        }

        public Task<Message> GetMessageAsync(int id)
        {
            return Database.Table<Message>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Message item)
        {
            return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Message item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
