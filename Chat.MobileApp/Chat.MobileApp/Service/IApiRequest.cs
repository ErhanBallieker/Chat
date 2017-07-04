using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.MobileApp.Service
{
    public interface IApiRequest<T>
    {
        T Speculative { get; }
        T UserInitiated { get; }
        T Background { get; }
    }
}
