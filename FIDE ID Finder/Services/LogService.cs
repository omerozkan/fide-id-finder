using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIDE_ID_Finder.Services
{
    public class LogService
    {
        public event EventHandler<string>? LogSubmitted;
        private readonly IList<string> _logs = new List<string>();
        private static readonly LogService Instance = new LogService();
        private LogService()
        {

        }

        public static LogService Get()
        {
            return Instance;
        }

        public void Log(string log)
        {
            _logs.Add(log);
            LogSubmitted?.Invoke(this, log);
        }

        public IList<string> GetLogs()
        {
            return _logs.ToList();
        }
    }
}
