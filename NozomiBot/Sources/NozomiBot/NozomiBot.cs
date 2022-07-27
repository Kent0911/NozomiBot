using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using NozomiBot.Boot;

namespace NozomiBot {
   internal class NozomiBot {
        public static DiscordSocketClient m_client { get; set; }
        public static CommandService m_commands { get; set; }
        public static IServiceProvider m_services { get; set; }
        public static SocketUserMessage m_message { get; set; }

        public async Task BotAsync() {
            m_client = new DiscordSocketClient( new DiscordSocketConfig { LogLevel = LogSeverity.Info });
            m_client.Log += Log;
            m_commands = new CommandService();
            m_services = new ServiceCollection().BuildServiceProvider();
            m_client.MessageReceived += CommandRecieved;

            await m_commands.AddModulesAsync( Assembly.GetEntryAssembly(), m_services );
            await m_client.LoginAsync( TokenType.Bot, BotConfigManager.token );
            await m_client.StartAsync();

            await Task.Delay( Timeout.Infinite );
        }

        private async Task CommandRecieved( SocketMessage _message ) {
            try {
                m_message = _message as SocketUserMessage;
                if ( m_message == null || m_message.Author.IsBot ) { return; }

                int argPos = 0;
                // コマンドかどうか判定
                if ( m_message.HasCharPrefix( '/', ref argPos ) || m_message.HasMentionPrefix( m_client.CurrentUser, ref argPos )) {
                    try {
                        var context = new SocketCommandContext( m_client, m_message );
                        var result = await m_commands.ExecuteAsync( context, argPos, m_services );
                        if ( !result.IsSuccess ) await context.Channel.SendMessageAsync( result.ErrorReason );
                    } catch ( Exception _e ) {
                        Console.WriteLine( _e );
                    }
                } else { return; }
            } catch ( Exception _e ) {
                Console.WriteLine( _e );
            }
        }

        private Task Log( LogMessage _log ) {
            Console.WriteLine( _log.ToString() );
            return Task.CompletedTask;
        }
    }
}