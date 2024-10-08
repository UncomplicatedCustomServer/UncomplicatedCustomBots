﻿using CommandSystem;
using Exiled.API.Features;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UncomplicatedCustomBots.Commands
{
    public abstract class PlayerCommandBase : ICommand
    {
        public abstract string Command { get; }

        public abstract string[] Aliases { get; }

        public abstract string Description { get; }

        public abstract bool Execute(ArraySegment<string> arguments, Player player, out string response);

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var player = Player.Get(sender);

            if (player is null)
            {
                response = "You must be in the game!";
                return false;
            }

            return Execute(arguments, player, out response);
        }
    }
}
