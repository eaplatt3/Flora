using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flora.Modules
{
    class GiveAway : ModuleBase
    {
        public List<GiveAwayValues> initValues { get; private set; }

        static GiveAway()
        {
            initValues = new List<GiveAwayValues>();
        }

        private Flora.Interfaces.IDiscordClient _discordClient;
        private GiveAwayFunctions _functions;
    }
}
