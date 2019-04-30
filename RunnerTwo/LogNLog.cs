using NLog;
using NLog.LayoutRenderers;
using System;
using System.IO;

namespace NlogConsole.Common
{
    public class LogNLog : ILog, IDisposable
    {
        private readonly ILogger logger;

        public LogNLog()
        {
            logger = LogManager.GetCurrentClassLogger();

            LayoutRenderer.Register("controlm-eventId", (logEventInfo) =>
            {
                if (logEventInfo == null)
                {
                    throw new ArgumentNullException(nameof(logEventInfo));
                }

                return logEventInfo.Parameters?.Length > 0 ? logEventInfo.Parameters[0] : string.Empty;
            });

            LayoutRenderer.Register<LayoutsRenderer.ControlmInformationLevelLayoutRenderer>("controlm-information-level");
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Dispose()
        {
            logger.Info("Shutting off logging", 999);
            LogManager.Shutdown();
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger.Info(message, 200);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
