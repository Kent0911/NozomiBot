using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Discord.Commands;

namespace CloverBot.Commands {
    public enum Commands {
        SETUP,
        RESET,
        ADDMEMBER,
        CLEAR,
        RESERVE,
        PHYSICALATTACK,
        MAGICATTACK,
        CARRYOVER,
        UNDO,
        FINISH,
        HELP,
        MAX
    }

    public class BotCommands : ModuleBase {
        private static Dictionary<string, Commands> dicCommands = new Dictionary<string, Commands>() {
            { "setup", Commands.SETUP },
            { "reset", Commands.RESET },
            { "add_member", Commands.ADDMEMBER },
            {"clear", Commands.CLEAR },
            { "reserve", Commands.RESERVE },
            { "physical_attack", Commands.PHYSICALATTACK },
            { "magic_attack", Commands.MAGICATTACK },
            { "carry_over", Commands.CARRYOVER },
            { "undo", Commands.UNDO },
            { "finish", Commands.FINISH },
            { "help", Commands.HELP }
        };

        [Command("setup")]
        public async Task SetUp() {

        }

        [Command("reset")]
        public async Task Reset() {

        }

        [Command("add_member")]
        public async Task AddMember() {

        }

        [Command("reserve")]
        public async Task Reserve() {

        }

        [Command("clear")]
        public async Task Clear() {

        }

        [Command("physical_attack")]
        public async Task PhysicalAttack() {

        }

        [Command("magic_attack")]
        public async Task MagicAttack() {

        }

        [Command("carry_over")]
        public async Task CarryOver() {

        }

        [Command("undo")]
        public async Task Undo() {

        }

        [Command("finish")]
        public async Task Finish() {

        }

        [Command("help_clover")]
        public async Task Help() {
            await ReplyAsync("help!");
        }

        private static int GetCommandsValue(string _str) {
            int value = -1;
            foreach (var c in dicCommands) {
                if (string.Equals(_str, c.Key, StringComparison.Ordinal)) value = (int)c.Value;
            }
            return value;
        }
    }
}
