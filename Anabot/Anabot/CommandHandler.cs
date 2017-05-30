using System.Threading.Tasks;
using System.Reflection;
using Discord.Commands;
using Discord.WebSocket;
using System.Linq;

namespace Anabot
{
    class CommandHandler
    {
        private CommandService _cmds;
        private DiscordSocketClient _client;

        public async Task Install(DiscordSocketClient c)
        {
            _client = c;
            _cmds = new CommandService();

            await _cmds.AddModulesAsync(Assembly.GetEntryAssembly());

            _client.MessageReceived += HandleCommand;

        }
        public async Task HandleCommand(SocketMessage s)
        {
            var msg = s as SocketUserMessage;
            if (msg == null) return;

            var context = new CommandContext(_client, msg);

            int argPos = 0;
            if (msg.HasStringPrefix("~", ref argPos) || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _cmds.ExecuteAsync(context, argPos);

                if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ToString());
            }
        }
        public async Task UserJoinedServer(SocketGuildUser user)
        {
            var channel = user.Guild.DefaultChannel;
            await channel.SendMessageAsync("Everyone, please give a warm welcome to " + user.Mention + "!");
        }
    }
}
