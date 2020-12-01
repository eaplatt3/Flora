using System;
using Discord;
using Discord.Net;
using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Flora.Services;


/// <summary>
/// Earl Platt III
/// RaidBotBeta v.0.5
/// Discord Bot to Schedule Raids 
/// </summary>

namespace RaidBotBeta
{
    class Program
    {
        //Setup our fields we assign later
        private DiscordSocketClient _client;
        private readonly IConfiguration _config;

        static void Main(string[] args)
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public Program()
        {

            //create the configuration
            var _builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: "config.json");

            //Build the configuration and assign to _config
            _config = _builder.Build();
        }

        public async Task MainAsync()
        {
            //Call ConfigurationServices to create the ServiceCollection/Provider for passing around the services
            using (var services = ConfigureServices())
            {
                //Get the client and assign to client
                //You get the services via GetRequiredService<T>
                var client = services.GetRequiredService<DiscordSocketClient>();
                _client = client;

                //Setup Loggin and the ready event
                client.Log += LogAsync;
                client.Ready += ReadyAsync;
                services.GetRequiredService<CommandService>().Log += LogAsync;

                //This is where we get the token value from the configuration file
                await client.LoginAsync(TokenType.Bot, _config["Token"]);
                await client.StartAsync();

                //We get the CommandHnadler class here and call the InitializeAsync
                //Method to start things up for the CommandHandler service
                await services.GetRequiredService<CommandHandler>().InitializeAysnc();

                //Block the Program until its is Closed
                await Task.Delay(-1);
            }
        }

        //Method to Print Log Data to the console
        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }

        private Task ReadyAsync()
        {
            Console.WriteLine($"Connected as -> {_client.CurrentUser} :)");
            return Task.CompletedTask;
        }

        //This Method handles the ServiceCollection creation/configuration 
        //Builds out the service provider we can call on later
        private ServiceProvider ConfigureServices()
        {
            //This returns a ServiceProvider that is used later to call for those services
            //We can add types we have access to here, hence adding the new using statement:
            //using RaidBotBeta.Services;
            //The config we build is also added, which comes in handy for setting the command prefix!
            return new ServiceCollection()
                .AddSingleton(_config)
                .AddSingleton<DiscordSocketClient>()
                .AddSingleton<CommandService>()
                .AddSingleton<CommandHandler>()
                .BuildServiceProvider();
        }
    }
}
