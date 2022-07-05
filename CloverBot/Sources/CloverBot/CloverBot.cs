using System;
using System.Reflection;
using System.Threading.Tasks;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using CloverBot.Boot;

namespace CloverBot {
    class CloverBot {
        private DiscordSocketClient client { get; }
        private CommandService commands { get; }
        private IServiceProvider services { get; }
        
        public CloverBot() {
            client = new DiscordSocketClient(new DiscordSocketConfig { LogLevel = Discord.LogSeverity.Info });
            client.Log += Log;
            commands = new CommandService();
            services = new ServiceCollection().BuildServiceProvider();

            Initialize();
        }
        private async void Initialize() {
            await commands.AddModulesAsync(Assembly.GetExecutingAssembly(), services);
            await client.LoginAsync(Discord.TokenType.Bot, BotConfigManager.token);
            await client.StartAsync();
            await RefreshInUpdateDate();

            Console.WriteLine("CloverBot Initialized");
        }

        private async Task RefreshInUpdateDate() {
            DateTime nowDateTime;
            TimeSpan nowTime;
            TimeSpan updateTimeSpan;

            nowDateTime = DateTime.UtcNow;
        }

        private Task Log(Discord.LogMessage _message) { return Task.CompletedTask; }

        private async Task SendMessage(SocketMessage _messageParam, String _message) {
            var message = _messageParam as SocketUserMessage;
            var content = new CommandContext(client, message);

            if (message == null || message.Author.IsBot) return;

            await message.Channel.SendMessageAsync(_message);
        }
    }
}