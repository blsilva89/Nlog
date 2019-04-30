using NLog;
using NLog.LayoutRenderers;
using System.Collections.Generic;
using System.Text;

namespace NlogConsole.Common.LayoutsRenderer
{
    [LayoutRenderer("controlm-information-level")]
    public class ControlmInformationLevelLayoutRenderer : LayoutRenderer
    {
        private readonly Dictionary<LogLevel, string> informationLevels = new Dictionary<LogLevel, string>()
        {
            { LogLevel.Error, "E" },
            { LogLevel.Info, "I" },
            { LogLevel.Warn, "W" }
        };

        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
            builder.Append(informationLevels[logEvent.Level]);
        }
    }
}
