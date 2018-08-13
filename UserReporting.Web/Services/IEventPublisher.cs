using System.Threading.Tasks;
using UserReporting.Shared.Events;

namespace UserReporting.Web.Services
{
    public interface IEventPublisher
    {
        Task Publish(IEvent @event);
    }
}
