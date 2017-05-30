using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Anabot.Moduel.CommandModuel
{
    class PublicModule : ModuleBase
    {
        [Command("DontGet")]
        [Alias("dontget")]
        [Summary("Use in case you don't get something")]
        public async Task dontget()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=2aegP8j5al0");
        }

        [Command("Favorite")]
        [Alias("favorite")]
        [Summary("Use in case someting is not your favorite")]
        public async Task favorite()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=hHP4JtsBnUQ");
        }

        [Command("LoadedQuestion")]
        [Alias("loadedquestion")]
        [Summary("Use in case the question is too much")]
        public async Task loadedquestion()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=bL2fNnllrAw");
        }
    }
}
