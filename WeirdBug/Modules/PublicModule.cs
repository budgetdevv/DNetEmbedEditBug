using Discord;
using Discord.Commands;
using System.IO;
using System.Threading.Tasks;
using TextCommandFramework.Services;

namespace TextCommandFramework.Modules
{
    // Modules must be public and inherit from an IModuleBase
    public class PublicModule: ModuleBase<SocketCommandContext>
    {
        [Command("test")]
        public async Task Test()
        {
            var EM = new EmbedBuilder();

            const string Test = "Test";
            
            EM.Title = Test;

            EM.Description = Test;
            
            EM.AddField(Test, Test);

            var Channel = Context.Channel;

            var Msg = await Channel.SendMessageAsync(embed: EM.Build());

            Channel.ModifyMessageAsync(Msg.Id, x =>
            {
                var EMBuilder = x.Embed.Value.ToEmbedBuilder();

                EMBuilder.Fields[0].Value = "LOL";

                x.Embed = EMBuilder.Build();
            });
        }
    }
}
