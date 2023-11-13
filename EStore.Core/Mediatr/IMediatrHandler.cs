using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStore.Core.Messages;

namespace EStore.Core.Mediatr
{
    public interface IMediatrHandler
    {
        Task PublishEvent<T>(T ev) where T : Event;
    }
}
