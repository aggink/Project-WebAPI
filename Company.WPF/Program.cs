using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Company.WPF;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var app = new App();
        app.InitializeComponent();
        app.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] Args) =>
        Host.CreateDefaultBuilder(Args)
            .ConfigureAppConfiguration((host, cfg) => cfg
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
            .ConfigureServices(App.ConfigureServices);

}