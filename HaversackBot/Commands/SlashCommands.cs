using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using static HaversackLibrary.Enums;

namespace HaversackBot.Commands
{
    public class SlashCommands : ApplicationCommandModule, IModule
    {
        //[SlashCommand("test", "A slash command made to test the DSharpPlusSlashCommands library!")]
        //public async Task TestCommand(InteractionContext ctx)
        //{
        //    await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        //    //Some time consuming task like a database call or a complex operation

        //    await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent("Thanks for waiting!"));
        //}

        //[SlashCommandGroup("train", "Automated dice rolls for training skills and attributes.")]
        //public class Train : ApplicationCommandModule
        //{
        //    [SlashCommand("skill", "Roll the training for a skill.")]
        //    public async Task Skill(InteractionContext ctx,
        //        Skills skill)
        //    { }

        //    [SlashCommand("attribute", "Roll the training for an attribute")]
        //    public async Task Attribute(InteractionContext ctx) { }
        //}

        ////Attribute choices
        //[SlashCommand("ban", "Bans a user")]
        //public async Task Ban(InteractionContext ctx, [Option("user", "User to ban")] DiscordUser user,
        //    [Choice("None", 0)]
        //    [Choice("1 Day", 1)]
        //    [Choice("1 Week", 7)]
        //    [Option("deletedays", "Number of days of message history to delete")] long deleteDays = 0)
        //{
        //    await ctx.Guild.BanMemberAsync(user.Id, (int)deleteDays);
        //    await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent($"Banned {user.Username}"));
        //}

        ////Enum choices
        //public enum MyEnum
        //{
        //    [ChoiceName("Option 1")]
        //    option1,
        //    [ChoiceName("Option 2")]
        //    option2,
        //    [ChoiceName("Option 3")]
        //    option3
        //}

        //[SlashCommand("enum", "Test enum")]
        //public async Task EnumCommand(InteractionContext ctx, [Option("enum", "enum option")] MyEnum myEnum = MyEnum.option1)
        //{
        //    await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(myEnum.GetName()));
        //}

        ////ChoiceProvider choices
        //public class TestChoiceProvider : IChoiceProvider
        //{
        //    public async Task<IEnumerable<DiscordApplicationCommandOptionChoice>> Provider()
        //    {
        //        return new DiscordApplicationCommandOptionChoice[]
        //        {
        //    //You would normally use a database call here
        //    new DiscordApplicationCommandOptionChoice("testing", "testing"),
        //    new DiscordApplicationCommandOptionChoice("testing2", "test option 2")
        //        };
        //    }
        //}

        //[SlashCommand("choiceprovider", "test")]
        //public async Task ChoiceProviderCommand(InteractionContext ctx,
        //    [ChoiceProvider(typeof(TestChoiceProvider))]
        //    [Option("option", "option")] string option)
        //{
        //    await ctx.CreateResponseAsync(InteractionResponseType.ChannelMessageWithSource, new DiscordInteractionResponseBuilder().WithContent(option));
        //}
    }
}
