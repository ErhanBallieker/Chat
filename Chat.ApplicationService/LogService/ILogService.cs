using Chat.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.ApplicationService.LogService
{
    public interface ILogService
    {
        void CreateApiLog(Log log);
    }
}
