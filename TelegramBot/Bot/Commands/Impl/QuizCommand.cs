using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelegramBot.Bot.Args;
using TelegramBot.Bot.Replies;
using TelegramBot.Util;

namespace TelegramBot.Bot.Commands
{
    class QuizCommand : StatefulCommand
    {
        protected override ICommandState CurrentState { get; set; }

        public QuizCommand()
        {
            CurrentState = new BeginGameState(this);
        }

        class Question
        {
            public string Text { get; set; }
            public string Answer { get; set; }
        }

        class BeginGameState : ICommandState
        {
            private QuizCommand _command;

            public BeginGameState(QuizCommand command)
            {
                _command = command;
            }

            public bool ShouldInvoke(TelegramMessageEventArgs input)
            {
                return MessageEquals(input, "викторина");
            }

            public Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input)
            {
                var gs = new GameState(_command);
                _command.CurrentState = gs;
                return gs.BeginGame();
            }
        }

        class GameState : ICommandState
        {
            private QuizCommand _command;

            private RecordsTable _records = new RecordsTable();

            public GameState(QuizCommand command)
            {
                _command = command;
                _questions = Resources.Quiz.Questions.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(q => q.Split('|'))
                    .Select(q => new Question
                    {
                        Text = q[0],
                        Answer = q[1]
                    })
                    .ToList();
            }

            public bool ShouldInvoke(TelegramMessageEventArgs input)
            {
                return true;
            }

            private const int PointsPerCorrectAnswer = 5;

            public Task<IEnumerable<IReply>> Invoke(TelegramMessageEventArgs input)
            {
                if (MessageEquals(input, "всё", "все", "конец", "завершить", "end"))
                {
                    _command.CurrentState = new BeginGameState(_command);
                    return FromResult(new TextReply("Викторина завершена"));
                }

                if (MessageEquals(input, "не знаю"))
                {
                    string answer = _currentQuestion.Answer;
                    _currentQuestion = _questions.PickRandom();
                    return Task.FromResult((IEnumerable<IReply>)new IReply[]
                    {
                        new TextReply($"Правильный ответ: {answer}"),
                        new TextReply($"Следующий вопрос: {_currentQuestion.Text}")
                    });

                }

                if (MessageEquals(input, "счет", "счёт", "score"))
                {
                    int score = _records.GetPoints(input.From);
                   return Task.FromResult((IEnumerable<IReply>)new IReply[]
                    {
                        new TextReply($"Счет игрока {input.From.Username}: {score}"),
                    });
                }

                if (MessageEquals(input, "топ"))
                {
                    int count = 10;

                    string top = _records.Data.OrderByDescending(t => t.Value)
                        .Select((t, i) => $"{i+1}. {t.Key.FirstName} {t.Key.LastName} - {t.Value}")
                        .Take(count)
                        .StringJoin("\r\n");

                    return Task.FromResult((IEnumerable<IReply>)new IReply[]
                    {
                        new TextReply($"Топ-{count} игроков:\r\n\r\n"+top),
                    });
                }

                if (MessageEquals(input, _currentQuestion.Answer))
                {
                    string answer = _currentQuestion.Answer;
                    _currentQuestion = _questions.PickRandom();
                    _records.AddPoints(input.From, PointsPerCorrectAnswer);
                    return Task.FromResult((IEnumerable<IReply>)new IReply[]
                    {
                        new TextReply($"Правильно, {input.From.FirstName} ты получаешь {PointsPerCorrectAnswer} очков! Это {answer}"),
                        new TextReply($"Следующий вопрос: {_currentQuestion.Text}")
                    });
                }

                return Task.FromResult(Nothing);
            }

            public Task<IEnumerable<IReply>> BeginGame()
            {
                _currentQuestion = _questions.PickRandom();
                return Task.FromResult((IEnumerable<IReply>)new IReply[]
                {
                    new TextReply($"Викторина начинается!"),
                    new TextReply($"Первый вопрос: {_currentQuestion.Text}")
                });
            }

            private Question _currentQuestion;
            private IList<Question> _questions;
        }
    }
}
