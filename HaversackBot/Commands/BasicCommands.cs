using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using HaversackBot.Commands;
using System;
using System.Threading.Tasks;

/* Create our class and extend from IModule */
public class BasicCommands : BaseCommandModule, IModule
{
    /* Commands in DSharpPlus.CommandsNext are identified by supplying a Command attribute to a method in any class you've loaded into it. */
    /* The description is just a string supplied when you use the help command included in CommandsNext. */
    [Command("alive")]
    [Description("Simple command to test if the bot is running!")]
    public async Task Alive(CommandContext ctx)
    {
        /* Send the message "I'm Alive!" to the channel the message was recieved from */
        await SendMessageResponse(ctx, "I'm alive!");
    }

    [Command("greet")]
    public async Task GreetCommand(CommandContext ctx)
    {
        await ctx.RespondAsync("Greetings! Thank you for executing me!");
    }

    private async Task SendMessageResponse(CommandContext ctx, string msg)
    {
        /* sends the "Typing..." message in the channel the command was received */
        await ctx.TriggerTypingAsync();

        /* sends the message to the channel */
        await ctx.RespondAsync(msg);
    }

}
