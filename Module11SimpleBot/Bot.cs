using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Hosting;

namespace Module11SimpleBot
{
    internal class Bot : BackgroundService
    {
        private ITelegramBotClient _telegramClient;

        public Bot(ITelegramBotClient telegramClient)
        {
            _telegramClient = telegramClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stopingToken)
        {
            _telegramClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                new ReceiverOptions() { AllowedUpdates = { } },
                cancellationToken: stopingToken);

            Console.WriteLine("Бот запущен");
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                await _telegramClient.SendTextMessageAsync(update.CallbackQuery.From.Id,
                    $"Данный тип сообщений не поддерживается. Отправьте текст",
                    cancellationToken: cancellationToken);
                return;
            }

            if (update.Type == UpdateType.Message)
            {
                switch (update.Message!.Type)
                {
                    case MessageType.Text:
                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id,
                                           $"Длина сообщения: {update.Message.Text.Length} знаков",
                                           cancellationToken: cancellationToken);
                        return;

                    default:
                        await _telegramClient.SendTextMessageAsync(update.Message.Chat.Id,
                            $"Данный тип сообщений не поддерживается. Отправьте текст",
                            cancellationToken: cancellationToken);
                        return;
                }
            }
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var errorMessage = exception switch
            {
                ApiRequestException apiRequestException =>
                $"Telegram API error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(errorMessage);

            Console.WriteLine("Задержка перед повторным подключением.");
            Thread.Sleep(10000);

            return Task.CompletedTask;
        }
    }
}
