using System;
using System.IO;

namespace TelegramBot
{
    static class Logger
    {
        private static bool _logToConsole = true;

        private static bool _logToFile = false;

        private static string _logsPath = @"Logs";

        /// <summary>
        /// Инициализирует систему логирования.
        /// </summary>
        /// <param name="logToConsole">Флаг, указывающий, нужно ли вести логи в консоли.</param>
        /// <param name="logToFile">Флаг, указывающи, нужно ли сохранять логи в файл.</param>
        /// <param name="logsDir">Путь к директории для логирования.</param>
        public static void Init(bool logToConsole = true, bool logToFile = false, string logsDir = @"Logs")
        {
            _logToConsole = logToConsole;
            _logToFile = logToFile;
            _logsPath = logsDir;
            if (!Directory.Exists(logsDir))
            {
                Directory.CreateDirectory(logsDir);
            }
        }

        /// <summary>
        /// Логирует текстовое обычное сообщение.
        /// </summary>
        /// <param name="data">Данные для логирования.</param>
        public static void LogMessage(object data)
        {
            Log(data, LogMessageType.Message);
        }

        /// <summary>
        /// Логирует предупреждение.
        /// </summary>
        /// <param name="data">Данные для логирования.</param>
        public static void LogWarning(object data)
        {
            Log(data, LogMessageType.Warning);
        }

        /// <summary>
        /// Логирует ошибку.
        /// </summary>
        /// <param name="data">Данные для логирования.</param>
        public static void LogError(object data)
        {
            Log(data, LogMessageType.Error);
        }

        /// <summary>
        /// Логирует критическую ошибку, из-за которой дальнейшее выполнение программы становится невозможным.
        /// </summary>
        /// <param name="data">Данные для логирования.</param>
        public static void LogFatal(object data)
        {
            Log(data, LogMessageType.Fatal);
        }

        private static void Log(object obj, LogMessageType type)
        {
            string msgType = String.Empty;
            string fileName = String.Empty;
            switch (type)
            {
                case LogMessageType.Message:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    msgType = "Message:";
                    fileName = "Log_" + DateTime.Now.ToShortDateString();
                    break;
                case LogMessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    msgType = "Warning:";
                    fileName = "Log_" + DateTime.Now.ToShortDateString();
                    break;
                case LogMessageType.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    msgType = "Error:";
                    fileName = "Errors_" + DateTime.Now.ToShortDateString();
                    break;
                case LogMessageType.Fatal:
                    Console.ForegroundColor = ConsoleColor.Red;
                    msgType = "Fatal error:";
                    fileName = "Errors_" + DateTime.Now.ToShortDateString();
                    break;
            }

            var msg = $"[{DateTime.Now.ToString(@"dd\\.MM\\.yy HH\\:mm\\:ss\")} {msgType}{Environment.NewLine}{obj}{Environment.NewLine}";
            if (_logToConsole)
            {
                Console.Write(msg);
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            if (_logToFile)
            {
                File.AppendAllText(Path.Combine(_logsPath, fileName + ".log"), msg);
            }
        }

        enum LogMessageType
        {
            Message,
            Warning,
            Error,
            Fatal
        }
    }
}
