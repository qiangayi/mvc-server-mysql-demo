using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HGD.Framework.Util
{
    public class Logger
    {
        private static bool cfgDone = false;
        private static readonly ILog log = LogManager.GetLogger("MeePolice");
        private static void checkCfg()
        {
            if (!cfgDone)
            {
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                string cfgFile = Path.Combine(rootPath, "Config/log4net.config");
                if (!File.Exists(cfgFile))
                    cfgFile = Path.Combine(rootPath, "bin/Config/log4net.config");
                XmlConfigurator.Configure(new System.IO.FileInfo(cfgFile));
            }
        }

        public static void Info(string message)
        {
            checkCfg();

            log.Info(message);
        }

        public static void Debug(string message)
        {
            checkCfg();

            log.Debug(message);
        }

        public static void DebugFormat(string message, params object[] args)
        {
            checkCfg();

            log.DebugFormat(message, args);
        }

        public static void Warn(string message)
        {
            checkCfg();

            log.Warn(message);
        }

        public static void WarnFormat(string message, params object[] args)
        {
            checkCfg();

            log.WarnFormat(message, args);
        }

        public static void Error(string message)
        {
            checkCfg();

            log.Error(message);
        }

        public static void ErrorFormat(string message, params object[] args)
        {
            checkCfg();

            log.ErrorFormat(message, args);
        }
    }
}
