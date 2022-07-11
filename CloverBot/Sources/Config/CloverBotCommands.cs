using System;
using System.Collections.Generic;

namespace CloverBot.Commands {
    internal class CloverBotCommands {
        public enum Commands {
            SETUP,
            ADD_MEMBER,
            PHYSICAL_ATTACK,
            MAGIC_ATTACK,
            CARRY_OVER,
            HELP,
        }

        private static Dictionary<String, Commands> dicCommands = new Dictionary<String, Commands>() {
            { "setup", Commands.SETUP },
            { "add_member", Commands.ADD_MEMBER },
            { "physical_attack", Commands.PHYSICAL_ATTACK },
            { "magic_attack", Commands.MAGIC_ATTACK },
            { "carry_over", Commands.CARRY_OVER },
            { "help", Commands.HELP }
        };
        private int GetCommandsValue(string _str) {
            int value = -1;
            foreach (var c in dicCommands) {
                if (string.Equals(_str, c.Key)) value = (int)c.Value;
            }
            return value;
        }
    }
}
