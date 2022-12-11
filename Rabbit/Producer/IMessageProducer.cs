using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabbit.Producer
{
    public interface IMessageProducer
    {
        void sendMessage<T>(T message);
    }
}
