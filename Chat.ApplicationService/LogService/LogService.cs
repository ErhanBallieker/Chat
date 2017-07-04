using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chat.Data.Domain;
using Chat.Data.Repository;

namespace Chat.ApplicationService.LogService
{
    public class LogService : ILogService
    {
        private readonly IRepository<Log> _logRepository;

        public LogService(IRepository<Log> logRepository)
        {
            _logRepository = logRepository;
        }

        public void CreateApiLog(Log log)
        {
            var result = _logRepository.Insert(log);
        }
    }
}
