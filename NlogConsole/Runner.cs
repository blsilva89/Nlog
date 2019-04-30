using Microsoft.Extensions.Logging;
using NlogConsole.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NlogConsole
{
    internal class Runner
    {
        private readonly ILog _logger;

        public Runner(ILog logger)
        {
            _logger = logger;
        }

        public void DoAction(string name)
        {
            _logger.Information($"Doing hard work! {name}");
        }
    }
}
