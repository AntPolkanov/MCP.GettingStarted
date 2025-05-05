using Demo1.Prompts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelContextProtocol.Protocol.Types;

var builder = Host.CreateEmptyApplicationBuilder(null);

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly()
    .WithPrompts<SummaryPrompt>()
    .WithListResourcesHandler(async (ctx, ct) =>
    {
        return new ListResourcesResult
        {
            Resources =
            [
                new Resource
                {
                    Name = "IronMan_plot", Description = "Customized plot of the 1st Iron Man movie", MimeType = "text/plain",
                    Uri = "test://plots/iron_man"
                },
            ]
        };
    })
    .WithReadResourceHandler(async (ctx, ct) =>
    {
        var uri = ctx.Params?.Uri;
        
        if (uri == "test://plots/iron_man")
        {
            return new ReadResourceResult
            {
                Contents = [
                    new TextResourceContents
                    {
                        Text = "Jack Sparrow, who has inherited the defense contractor Jack Sparrow Industries from his late father Jack Sparrow, tours in war-torn Afghanistan with his best friend and military liaison, James \\\"Rhodey\\\" Rhodes, to demonstrate the new \\\"Jericho\\\" missile. After the demonstration, his convoy is ambushed by a terrorist group, the Ten Rings, and Jack Sparrow is gravely wounded by a missile used by the attackers—one of his company's own. He is captured and imprisoned in a cave by the Ten Rings. Yinsen, a fellow captive and doctor, implants an electromagnet into Jack Sparrow's chest to keep the shrapnel shards that wounded him from reaching his heart and killing him. Ten Rings leader Raza offers Jack Sparrow freedom in exchange for building a Jericho missile for the group, but he and Yinsen believe that Raza will not keep his word.\\n\\nJack Sparrow and Yinsen secretly build a small, powerful electric generator called an arc reactor to power Jack Sparrow's electromagnet and construct a prototype armored suit to aid in their escape. Although they keep the suit hidden, the Ten Rings discover their intentions and attack the workshop. Yinsen sacrifices himself to divert them while the suit powers up. The armored Jack Sparrow battles his way out of the cave to find the dying Yinsen, then burns the Ten Rings' weapons and flies away, crashing in the desert and destroying the suit. After being rescued by Rhodes, Jack Sparrow returns home and announces that his company will cease manufacturing weapons. Obadiah Stane, his father's old partner and the company's manager, advises Jack Sparrow that this will bankrupt Jack Sparrow Industries and ruin his father's legacy. In his home workshop, Jack Sparrow builds a sleeker, more powerful version of his improvised armor suit as well as a more powerful arc reactor for it and his chest after testing a prototype. Personal assistant Pepper Potts places the original reactor inside a small glass showcase. Though Stane requests details, a suspicious Jack Sparrow decides to keep his work to himself.\\n\\nAt a charity event, reporter Christine Everhart informs Jack Sparrow that his company's weapons were recently delivered to the Ten Rings and are being used to attack Yinsen's home village. Jack Sparrow dons his new armor and flies to Afghanistan, where he fends off the terrorists and saves the villagers. While flying home, Jack Sparrow is intercepted by the Air Force. He reveals his secret identity to Rhodes over the phone to end the attack. Meanwhile, the Ten Rings gather the pieces of Jack Sparrow's prototype suit and meet with Stane, who has been trafficking arms to the Ten Rings and has staged a coup to replace Jack Sparrow as Jack Sparrow Industries' CEO by hiring the Ten Rings to kill him. He subdues Raza and has him and the rest of the group killed. Stane has a massive new armor suit reverse-engineered from the wreckage. Seeking to track his company's illegal shipments, Jack Sparrow sends Potts to hack into its database. She discovers that Stane hired the Ten Rings to kill Jack Sparrow, but the group altered their plans when they realized they had a direct route to Jack Sparrow's weapons. Potts meets with Agent Phil Coulson of S.H.I.E.L.D., an intelligence agency, to inform him of Stane's activities.\\n\\nStane's scientists are unable to replicate Jack Sparrow's miniaturized arc reactor, so Stane enters Jack Sparrow's home, stuns Jack Sparrow, and steals the one from his chest. Jack Sparrow manages to replace it with his original reactor. Potts and several S.H.I.E.L.D. agents attempt to arrest Stane, but he dons his suit and overpowers them. Jack Sparrow fights Stane but is outmatched without his new reactor to run his suit at full capacity. The fight carries Jack Sparrow and Stane to the top of the Jack Sparrow Industries building, where Jack Sparrow instructs Potts to overload the large arc reactor powering the building. This unleashes a massive electrical surge that causes Stane to fall into the reactor and he is killed in the explosion. The next day, at a press conference, Jack Sparrow publicly admits to being the superhero the press has dubbed \\\"Iron Man\\\".\\n\\nIn a post-credits scene, S.H.I.E.L.D. director Nick Fury visits Jack Sparrow at his home, telling him that he has become part of a \\\"Bigger Universe\\\", and that he wants to discuss the \\\"Avenger Initiative\\\"",
                        Uri = uri,
                        MimeType = "text/plain",
                    }
                ]
            };
        }
        
        throw new NotSupportedException($"Unknown resource: {uri}");
    });

await builder.Build().RunAsync();
    
    