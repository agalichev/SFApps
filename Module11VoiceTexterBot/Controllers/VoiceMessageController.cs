using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Module11VoiceTexterBot.Configuration;
using Module11VoiceTexterBot.Services;

namespace Module11VoiceTexterBot.Controllers
{
    internal class VoiceMessageController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        private readonly IFileHandler _audioFileHandler;

        public VoiceMessageController(ITelegramBotClient telegramClient, IFileHandler audioFileHandler, IStorage memoryStorage)
        {
            _telegramClient = telegramClient;
            _audioFileHandler = audioFileHandler;
            _memoryStorage = memoryStorage;
        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            var fileId = message.Voice?.FileId;

            if (fileId == null)
                return;

            await _audioFileHandler.Download(fileId, ct);
            //Console.WriteLine($"Контроллер {GetType().Name} получил голосовое сообщение");
            //await _telegramClient.SendTextMessageAsync(message.Chat.Id, "Голосовое сообщение загружено", cancellationToken: ct);
            string userLanguageCode = _memoryStorage.GetSession(message.Chat.Id).LanguageCode;
            var result = _audioFileHandler.Process(userLanguageCode);
            await _telegramClient.SendTextMessageAsync(message.Chat.Id, result, cancellationToken: ct);
        }
    }
}
