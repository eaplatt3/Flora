using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

namespace Flora.Services
{
    class CommandHandler
    {
        //Setup Field to be set later in the constructor
        private readonly IConfiguration _config;
        private readonly CommandService _commands;
        private readonly DiscordSocketClient _client;
        private readonly IServiceProvider _services;

        public CommandHandler(IServiceProvider services)
        {
            //Juice up the fields with these services
            //Since we passed the servicesin, we can use GetRequiredService
            //To pass them into the fields set earlier

            _config = services.GetRequiredService<IConfiguration>();
            _commands = services.GetRequiredService<CommandService>();
            _client = services.GetRequiredService<DiscordSocketClient>();
            _services = services;

            //Take action when we excute a command
            _commands.CommandExecuted += CommandExecuteAsync;

            //Take action when we receive a message (so we can process it, and see if it is a vaild command)
            _client.MessageReceived += MessageReceivedAsync;
        }

        public async Task InitializeAysnc()
        {
            //Register modules that are public and inherit ModuleBase<T>
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        //This method is where the magic happens, and takes actions upon receiving messages
        public async Task MessageReceivedAsync(SocketMessage rawMessage)
        {
            //Ensure we dont't process system/other bot messages
            if (!(rawMessage is SocketUserMessage message))
            {
                return;
            }

            if (message.Source != MessageSource.User)
            {
                return;
            }

            //Sets the argument position away from the prefix we set
            var argPos = 0;

            //Gets the prefix from the config file
            char prefix = Char.Parse(_config["Prefix"]);

            //Determine if the message has a vaild prefix, and adjust argPos based on prefix
            if (!(message.HasMentionPrefix(_client.CurrentUser, ref argPos) || message.HasCharPrefix(prefix, ref argPos)))
            {
                return;
            }

            var context = new SocketCommandContext(_client, message);

            //Excute command if one is found that matches
            await _commands.ExecuteAsync(context, argPos, _services);

            //Deletes Command After Processed
             await message.DeleteAsync();
        }

        public async Task CommandExecuteAsync(Optional<CommandInfo> command, ICommandContext context, IResult result)
        {
            var user = context.User;

            //If a command isn't found, log that info to the console and exit this method
            if (!command.IsSpecified)
            {
                System.Console.WriteLine($"Command failed to execute for [{user.Username}]!");
                return;
            }

            //Log success to the console and exit this method
            if (result.IsSuccess)
            {
                System.Console.WriteLine($"Command excuted for -> [{user.Username}]");
                return;
            }

            //Failure scenario, let's let the user know
            await context.Channel.SendMessageAsync($"Sorry, ... Something went wrong!");
        }


    }
}

    

