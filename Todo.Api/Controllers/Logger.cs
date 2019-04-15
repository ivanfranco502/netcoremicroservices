namespace Todo.Api.Controllers
{
    using log4net;

    public class Logger : ILogger
    {
        private ILog _log;

        public Logger(ILog log)
        {
            _log = log;
        }

        public void Log(string text)
        {
            _log.Info(text);
        }
    }
}
