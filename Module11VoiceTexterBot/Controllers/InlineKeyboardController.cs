using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Module11VoiceTexterBot.Services;

namespace Module11VoiceTexterBot.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;

        public InlineKeyboardController(ITelegramBotClient telegramClient, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            _memoryStorage.GetSession(callbackQuery.From.Id).LanguageCode = callbackQuery.Data;

            string languageText = callbackQuery.Data switch
            {
                "ru" => "Русский",
                "en" => "Английский",
                _ => String.Empty
            };

            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"<b>Язык аудио - {languageText}.{Environment.NewLine}</b>" + 
                $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);

            Console.WriteLine($"Контроллер {GetType().Name} обнаружил нажатие на кнопку");
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id, $"Обнаружено нажатие на кнопку {callbackQuery.Data}", cancellationToken: ct);
        }
    }
}
