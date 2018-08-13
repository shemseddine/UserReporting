using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using Newtonsoft.Json;
using System.Threading.Tasks;
using UserReporting.Shared.Events;

namespace UserReporting.Web.Services
{
    public class EventPublisher : IEventPublisher
    {
        private readonly CloudQueue _queue;

        public EventPublisher(string connectionString)
        {
            var storageAccount = CloudStorageAccount.Parse(connectionString);

            var queueClient = storageAccount.CreateCloudQueueClient();

            _queue = queueClient.GetQueueReference("eventqueue");
        }
        public async Task Publish(IEvent @event)
        {
            await _queue.CreateIfNotExistsAsync();
            var message = new CloudQueueMessage(JsonConvert.SerializeObject(@event));
            await _queue.AddMessageAsync(message);

        }
    }
}
