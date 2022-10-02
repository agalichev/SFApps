using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Module11VoiceTexterBot.Configuration;
using Module11VoiceTexterBot.Utilities;

namespace Module11VoiceTexterBot.Services
{
    public class AudioFileHandler : IFileHandler
    {
        private readonly AppSettings _appSettings;
        private readonly ITelegramBotClient _telegramBotClient;

        public AudioFileHandler(AppSettings appSettings, ITelegramBotClient telegramBotClient)
        {
            _appSettings = appSettings;
            _telegramBotClient = telegramBotClient;
        }

        public async Task Download(string fileId, CancellationToken ct)
        {
            string inputAudioFilePath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");

            using (FileStream destinnationStream = File.Create(inputAudioFilePath))
            {
                var file = await _telegramBotClient.GetFileAsync(fileId, ct);
                if (file.FilePath == null)
                    return;

                await _telegramBotClient.DownloadFileAsync(file.FilePath, destinnationStream, ct);   
            }
        }

        public string Process(string languageCode)
        {
            string inputAudioPath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.InputAudioFormat}");
            string outputAudioPath = Path.Combine(_appSettings.DownloadsFolder, $"{_appSettings.AudioFileName}.{_appSettings.OutputAudioFormat}");

            Console.WriteLine("Начинаем конвертацию...");
            AudioConverter.TryConvert(inputAudioPath, outputAudioPath);
            Console.WriteLine("Файл конвертирован");

            Console.WriteLine("Начинаем распознавание...");
            var speechText = SpeechDetector.DetectSpeech(outputAudioPath, _appSettings.InputAudioBitrate, languageCode);
            Console.WriteLine("Файл распознан");

            return speechText;
        }

    }
}
