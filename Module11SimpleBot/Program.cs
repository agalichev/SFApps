using Telegram.Bot;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Module11SimpleBot
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder().ConfigureServices((hostContext, services) => ConfigureServices(services)).UseConsoleLifetime().Build();

            Console.WriteLine("Сервис запущен");
            await host.RunAsync();
            Console.WriteLine("Сервис остановлен");
            Console.ReadLine();
        }

        static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient("5628045407:AAFfWFHhchMjnnb_JQtKp5YTusk_BhDW5pI"));
            services.AddHostedService<Bot>();
        }
    }
}