using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using CloverBot.Boot;

namespace CloverBot {
    internal class CloverBot {
        public DiscordSocketClient m_client { get; set; }
        public static CommandService m_commands { get; set; }
        public static IServiceProvider m_services { get; set; }

        public async Task BotAsync() {
            m_client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = LogSeverity.Info });
            m_client.Log += Log;
            m_commands = new CommandService();
            m_services = new ServiceCollection().BuildServiceProvider();
            m_client.MessageReceived += CommandRecieved;

            await m_commands.AddModulesAsync(Assembly.GetEntryAssembly(), m_services);
            await m_client.LoginAsync(TokenType.Bot, BotConfigManager.token);
            await m_client.StartAsync();

            await Task.Delay(-1);
        }

        public async Task CommandRecieved(SocketMessage _message) {
            try {
                var message = _message as SocketUserMessage;
                if (message == null || message.Author.IsBot) return;

                int argPos = 0;
                var context = new CommandContext(m_client, message);
                // コマンドかどうか判定
                if (message.HasCharPrefix('/', ref argPos)) {
                    try {
                        var result = await m_commands.ExecuteAsync(context, argPos, m_services);
                        if (!result.IsSuccess) await context.Channel.SendMessageAsync(result.ErrorReason);
                    } catch (Exception _e) {
                        Console.WriteLine(_e);
                    }
                } else { return; }
            } catch (Exception _e) {
                Console.WriteLine(_e);
            }
        }

        private Task Log(LogMessage _message) {
            Console.WriteLine(_message.ToString());
            return Task.CompletedTask;
        }
    }
}