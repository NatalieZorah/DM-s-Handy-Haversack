using System;
using System.Linq;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using DSharpPlus.Interactivity.Extensions;
using HaversackBot.Commands;
using DSharpPlus.Entities;
using HaversackLibrary.Model_Logging;
using Newtonsoft.Json;

internal class Program
{
    /* This is the cancellation token we'll use to end the bot if needed(used for most async stuff). */
    private CancellationTokenSource _cts { get; set; }

    /* We'll load the app config into this when we create it a little later. */
    private IConfigurationRoot _config;

    /* These are the discord library's main classes */
    private DiscordClient _discord;

    /* Use the async main to create an instance of the class and await it(async main is only available in C# 7.1 onwards). */
    static async Task Main(string[] args) => await new Program().InitBot(args);

    async Task InitBot(string[] args)
    {
        try
        {
            Console.WriteLine("[info] Welcome to my bot!");
            _cts = new CancellationTokenSource();

            // Load the config file(we'll create this shortly)
            Console.WriteLine("[info] Loading config file..");
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false, reloadOnChange: true)
                .Build();

            // Create the DSharpPlus client
            Console.WriteLine("[info] Creating discord client..");
            _discord = new DiscordClient(new DiscordConfiguration
            {
                Token = _config.GetValue<string>("discord:token"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });

            _discord.MessageCreated += async (s, e) =>
            {
                Console.WriteLine($"Author: {e.Author.Id} | Message: {e.Message}");
            };


            // Build dependancies and then create the commands module.
            var _commands = _discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "hs!" }//_config.GetValue<IEnumerable<string>>("discord:CommandPrefix") // Load the command prefix(what comes before the command, eg "!" or "/") from our config file
            });

            _commands.RegisterCommands<BasicCommands>();

            CharacterModelLogging.BuildTestCharacter();

            RunAsync(args).Wait();
        }
        catch (Exception ex)
        {
            // This will catch any exceptions that occur during the operation/setup of your bot.

            // Feel free to replace this with what ever logging solution you'd like to use.
            // I may do a guide later on the basic logger I implemented in my most recent bot.
            Console.Error.WriteLine(ex.ToString());
        }
    }

    async Task RunAsync(string[] args)
    {
        // Connect to discord's service
        Console.WriteLine("Connecting..");
        await _discord.ConnectAsync();
        Console.WriteLine("Connected!");

        // Keep the bot running until the cancellation token requests we stop
        while (!_cts.IsCancellationRequested)
            await Task.Delay(TimeSpan.FromMinutes(1));
    }

    private Task Log(DiscordAuditLogMessageEntry msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }
}
