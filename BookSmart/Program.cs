using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Synthesis;
using Mutagen.Bethesda.Skyrim;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using System.Text.RegularExpressions;
using Noggog;

namespace BookSmart
{
    // Sorry, I don't really know what I'm doing. Stop judging me.
    public class Program
    {

        static Lazy<Settings> LazySettings = new Lazy<Settings>();
        static Settings settings => LazySettings.Value;

        public static async Task<int> Main(string[] args)
        {
            return await SynthesisPipeline.Instance
                .AddPatch<ISkyrimMod, ISkyrimModGetter>(RunPatch)
                .SetAutogeneratedSettings(
                    nickname: "Settings",
                    path: "settings.json",
                    out LazySettings
                )
                .SetTypicalOpen(GameRelease.SkyrimSE, "WeightlessThings.esp")
                .Run(args);
        }

        public static void RunPatch(IPatcherState<ISkyrimMod, ISkyrimModGetter> state)
        {
            state.LoadOrder.PriorityOrder.OnlyEnabled().Book().WinningOverrides().ForEach(book =>
            {
                if (book.Teaches is IBookSkillGetter skillTeach)
                {
                    // variables for use in this section
                    string newName = "Unknown";
                    string? skillName = "Unknown";
                    string open = "";
                    string close = "";

                    // set the open and close characters that go around the skill name
                    switch (settings.encapsulatingCharacters)
                    {
                        case Settings.EncapsulatingCharacters.Chevrons: { open = "<"; close = ">"; break; }
                        case Settings.EncapsulatingCharacters.Curly_Brackets: { open = "{"; close = "}"; break; }
                        case Settings.EncapsulatingCharacters.Parenthesis: { open = "("; close = ")"; break; }
                        case Settings.EncapsulatingCharacters.Square_Brackets: { open = "["; close = "]"; break; }
                        case Settings.EncapsulatingCharacters.Stars: { open = "*"; close = "*"; break; }
                        default: throw new NotImplementedException("Somehow you set Encapsulating Characters to something that isn't supported.");
                    }

                    // Label Format: Long
                    if (settings.labelFormat == Settings.LabelFormat.Long)
                    {
                        skillName = skillTeach.Skill switch
                        {
                            Skill.HeavyArmor => "Heavy Armor",
                            Skill.LightArmor => "Light Armor",
                            Skill.OneHanded => "One Handed",
                            Skill.TwoHanded => "Two Handed",
                            _ => skillTeach.Skill.ToString()
                        };

                        newName = $"{open}{skillName}{close} {book.Name}";
                    }
                    // Label Format: Short
                    else if (settings.labelFormat == Settings.LabelFormat.Short)
                    {
                        skillName = skillTeach.Skill switch
                        {
                            Skill.Alchemy => "Alch",
                            Skill.Alteration => "Altr",
                            Skill.Archery => "Arch",
                            Skill.Block => "Blck",
                            Skill.Conjuration => "Conj",
                            Skill.Destruction => "Dest",
                            Skill.Enchanting => "Ench",
                            Skill.HeavyArmor => "H.Arm",
                            Skill.Illusion => "Illu",
                            Skill.LightArmor => "L.Arm",
                            Skill.Lockpicking => "Lock",
                            Skill.OneHanded => "1H",
                            Skill.Pickpocket => "Pick",
                            Skill.Restoration => "Resto",
                            Skill.Smithing => "Smith",
                            Skill.Sneak => "Snk",
                            Skill.Speech => "Spch",
                            Skill.TwoHanded => "2H",
                            _ => skillTeach.Skill.ToString()
                        };

                        newName = $"{open}{skillName}{close} {book.Name}";
                    }
                    // Label Format: Star
                    else if (settings.labelFormat == Settings.LabelFormat.Star)
                    {
                        newName = $"*{book.Name}";
                    }
                    else
                    {
                        throw new NotImplementedException("Somehow you set labelFormat to something that isn't supported.");
                    }

                    // Actually create the override record
                    var bookOverride = state.PatchMod.Books.GetOrAddAsOverride(book);
                    bookOverride.Name = newName;

                    // Console output
                    Console.WriteLine($"{book.FormKey}: '{book.Name}' -> '{bookOverride.Name}'");
                }
            });
        }
    }
}
