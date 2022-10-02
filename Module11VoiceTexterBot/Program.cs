using Telegram.Bot;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module11VoiceTexterBot.Controllers;
using Module11VoiceTexterBot.Services;
using Module11VoiceTexterBot.Configuration;

namespace Module11VoiceTexterBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var botClient = new TelegramBotClient("5657675997:AAFgXhRCq4eUKLzMBCqbcEfR5ETisfBI8UE");

            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder().ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервис запущен");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            AppSettings appSettings = BuildAppSettings();
            services.AddSingleton(appSettings);

            services.AddSingleton<IFileHandler, AudioFileHandler>();

            services.AddTransient<DefaultMessageController>();
            services.AddTransient<VoiceMessageController>();
            services.AddTransient<TextMessageController>();
            services.AddTransient<InlineKeyboardController>();

            services.AddSingleton<IStorage, MemoryStorage>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(appSettings.BotToken));
            services.AddHostedService<Bot>();
        }

        static AppSettings BuildAppSettings()
        {
            return new AppSettings()
            {
                DownloadsFolder = "C:\\Users\\lexga\\Downloads",
                BotToken = "5657675997:AAFgXhRCq4eUKLzMBCqbcEfR5ETisfBI8UE",
                AudioFileName = "audio",
                InputAudioFormat = "ogg",
                OutputAudioFormat = "wav",
                InputAudioBitrate = 16000,
            };
        }
    }
}