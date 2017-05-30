using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace Anabot
{
    class Program
    {
        // Convert our sync main to an async main.
        public static void Main(string[] args) =>
            new Program().Start().GetAwaiter().GetResult();

        private DiscordSocketClient _client;
        private CommandHandler _commands;

        public async Task Start()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandHandler();


            await _client.LoginAsync(TokenType.Bot, "MzE5MTMzNTAwNDUwMDEzMTg0.DA9FZg.qnrcEZZzt4166AP9S6e3vOTURtg");
            await _client.StartAsync();

            await _client.SetGameAsync("Chess with Ram");

            _client.Log += Log;

            await _commands.Install(_client);

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}
