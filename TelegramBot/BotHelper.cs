/*
 * В этом классе будем писать все вспомогательные методы для функционирования
 * уже готовых ботов. Например: проверка времени, прошедшего с прошлого сообщения;
 * проверка сообщения на наличие команды; извлечение параметров из команды; etc...
 */


using System;
using System.Collections.Generic;

namespace TelegramBot
{
    public class BotHelper
    {
        readonly string botName;

        Dictionary<int, DateTime> lastMessageTime;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:TelegramBot.BotHelper"/> class.
        /// </summary>
        /// <param name="botName">Короткое имя бота @testBot</param>
        public BotHelper(string botName)
        {
            this.botName = (botName.StartsWith("@", StringComparison.Ordinal) && botName.Length > 1) ?
                botName.Substring(1) : botName;
            lastMessageTime = new Dictionary<int, DateTime>();
        }

        /// <summary>
        /// Проверяет время, прошедшее с момента прошлого обращения к боту.
        /// </summary>
        /// <returns><c>true</c>, если команда разрашена, <c>false</c> если команда запрещена.</returns>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <param name="timeInSecs">Время в секундах.</param>
        public bool CheckTime(int userId, int timeInSecs = 10)
        {
            if (!lastMessageTime.ContainsKey(userId))
            {
                lastMessageTime.Add(userId, DateTime.Now);
                return true;
            }

            var updateTime = DateTime.Now;
            if ((updateTime - lastMessageTime[userId]).TotalSeconds >= timeInSecs)
            {
                lastMessageTime[userId] = updateTime;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверяет сообщения от пользователя на наличие команд.
        /// </summary>
        /// <returns><c>true</c>, если команды найдены, <c>false</c> если команды не найдены.</returns>
        /// <param name="text">Текст сообщения.</param>
        /// <param name="args">Команды.</param>
        public bool CheckCommand(string text, params string[] args)
        {
            var cmdText = text;

            if (cmdText.Contains(" "))
            {
                var split = cmdText.Split(' ');
                cmdText = split[0] ?? "";
            }

            if (cmdText.Contains("@"))
            {
                var split = cmdText.Split('@');
                if (!String.Equals(split[1] ?? "", botName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
                cmdText = split[0] ?? "";
            }

            foreach (var s in args)
            {
                if (String.Equals(s, cmdText, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Получает список параметров, которые передали в команде.
        /// </summary>
        /// <returns>Список параметров команды.</returns>
        /// <param name="text">Текст с командой.</param>
        public string[] GetCommandArgs(string text)
        {
            if (!text.Contains(" "))
            {
                return new string[0];
            }

            var split = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new string[split.Length - 1];
            Array.Copy(split, 1, result, 0, result.Length);

            return result;
        }
    }
}
