using Discord;
using Discord.Commands;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Flora.Modules
{
    //For commands to be available, and have to Contect passed
    //To them, we must inherit ModuleBase
    public class Commands : ModuleBase
    {
        [Command("hello")]
        public async Task HelloCommand()
        {
            //Initialize empty string builder for reply
            var sb = new StringBuilder();

            //Get User info from the Context
            var user = Context.User;

            //Build out the reply
            sb.AppendLine($"You are -> [{user.Username}]");
            sb.AppendLine("I must now say, World!");

            //Send simple string replay
            await ReplyAsync(sb.ToString());
        }

        [Command("8ball")]
        [Alias("ask")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task AskEightBall([Remainder] string args = null)
        {
            //I like using StringBuilder to build out the reply
            var sb = new StringBuilder();

            //Lets use an embed for this one!
            var embed = new EmbedBuilder();

            //Now to create a List of Possible Replies
            var replies = new List<string>();

            //Add possible replies
            replies.Add("yes");
            replies.Add("no");
            replies.Add("maybe");
            replies.Add("hazzzzy.......");

            //Time to add some option to the embed(Like Color & Title)
            embed.WithColor(new Discord.Color(0, 255, 0));
            embed.Title = "Welcome to the 8-Ball!";

            //We can get lots of information from the Context that is passed into the commands
            //Setting up the preface with the user's name and a coma
            sb.AppendLine($"{Context.User.Username},");
            sb.AppendLine();

            //Let's make sure the supplied question isn't null
            if (args == null)
            {
                //If no question is asked (args are null), reply with the below text
                sb.AppendLine("Sorry, can't answer a question you didn't ask!");
            }

            else
            {
                //If we have a question, let's give an answer!
                //Get a random number to index our list with
                //arrays start at zero so we subtract 1 from the count
                var answer = replies[new Random().Next(replies.Count - 1)];

                //Build out our reply with the StringBuilder
                sb.AppendLine($"You asked: **{args}**...");
                sb.AppendLine();
                sb.AppendLine($"...your answer is **{answer}**");

                //Let's switch out the reply & change the color based on it
                switch (answer)
                {
                    case "yes":
                        {
                            embed.WithColor(new Discord.Color(0, 255, 0));
                            break;
                        }
                    case "no":
                        {
                            embed.WithColor(new Discord.Color(255, 0, 0));
                            break;
                        }
                    case "maybe":
                        {
                            embed.WithColor(new Discord.Color(255, 255, 0));
                            break;
                        }
                    case "hazzzzy.......":
                        {
                            embed.WithColor(new Discord.Color(255, 0, 255));
                            break;
                        }
                }
            }

            //Now we can assign the description
            //of the embed to the contents
            //of the StringBuilder we created
            embed.Description = sb.ToString();

            //This will reply with the embed
            await ReplyAsync(null, false, embed.Build());
        }



        [Command("raid")]
        public async Task raidSignUp(string raid, string date, string time, string ampm, string description, string description2 = " ")
        {

            IUserMessage SentEmbed;

            Emote interested = Emote.Parse("<:Interested:721034001724342423>");
            Emote maybe = Emote.Parse("<:Maybe:721034001497718797>");
            Emote nope = Emote.Parse("<:Nope:721034001674010684>");
            Emote reserve = Emote.Parse("<:Reserve:721034001460101182>");

            Emote[] myReactions = { interested, maybe, nope, reserve };

            //Emote myReaction = Emote.Parse("<:Interested:721034001724342423>");

            DateTime dateTime = DateTime.Parse(date);
            string day = dateTime.ToString("ddd");



            if (raid == "gos")
            {
                if (day == "Sun")
                {
                    var filename = "gos_Sun.png";

                    var footer = new EmbedFooterBuilder().WithText("React Below");

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",

                    }.WithFooter(footer).Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);

                }

                if (day == "Mon")
                {
                    var filename = "gos_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //Footer = "React Below",

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "gos_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "gos_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "gos_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "gos_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "gos_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }

            if (raid == "gosdivinity")
            {
                if (day == "Sun")
                {
                    var filename = "gos_Sun.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Mon")
                {
                    var filename = "gos_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "gos_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "gos_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "gos_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "gos_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "gos_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Garden of Salvation - Divinty Run",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}",
                        //FooterText = "React Below"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }

            if (raid == "dsc")
            {
                if (day == "Sun")
                {
                    var filename = "dsc_Sun.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Mon")
                {
                    var filename = "dsc_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "dsc_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "dsc_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "dsc_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "dsc_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "dsc_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Deep Stone Crypt",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }

            if (raid == "lw")
            {
                if (day == "Sun")
                {
                    var filename = "lw_Sun.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Mon")
                {
                    var filename = "lw_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "lw_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "lw_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "lw_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "lw_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "lw_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }

            if (raid == "lwriven")
            {
                if (day == "Sun")
                {
                    var filename = "lw_Sun.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Mon")
                {
                    var filename = "lw_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "lw_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "lw_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "lw_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "lw_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "lw_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Last Wish - Queens Walk",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }

            if (raid == "vog")
            {
                if (day == "Sun")
                {
                    var filename = "vog_Sun.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Mon")
                {
                    var filename = "vog_Mon.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Tue")
                {
                    var filename = "vog_Tue.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Wed")
                {
                    var filename = "vog_Wed.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Thu")
                {
                    var filename = "vog_Thur.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Fri")
                {
                    var filename = "vog_Fri.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }

                if (day == "Sat")
                {
                    var filename = "vog_Sat.png";

                    var embed = new EmbedBuilder()
                    {
                        Title = "Vault of Glass",
                        Description = "```" + day + ", " + date + " @ " + time + " " + ampm + " " + "\n" + description + "```" + description2,
                        ImageUrl = $"attachment://{filename}"

                    }.Build();

                    SentEmbed = await Context.Channel.SendFileAsync(filename, embed: embed);

                    await SentEmbed.AddReactionsAsync(myReactions);
                }
            }
        }

    }
}

    

