using log4net;
using log4net.Config;

namespace VisualTAF.Utils
{
    /// <summary>
    /// class for log
    /// </summary>
    public class Logger
    {
        private readonly ILog _log;
        private static Logger _instance;

        private Logger()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger("Console");
        }

        public static Logger Instance => _instance ?? (_instance = new Logger());

        public void Info(string message)
        {
            _log.Info(message);
        }


        public void Debug(string message)
        {
            _log.Debug(message);
        }

        public void Warn(string message)
        {
            _log.Warn(message);
        }

    }
}
