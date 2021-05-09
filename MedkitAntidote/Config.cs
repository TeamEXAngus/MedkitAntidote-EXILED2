using System.ComponentModel;
using System.Collections.Generic;
using Exiled.API.Interfaces;

namespace MedkitAntidote
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not the plugin should send debug messages in console.")]
        public bool DebugEnabled { get; set; } = false;

        [Description("List of status effects which medkits should remove from the player.")]
        public List<string> MedkitEffectsToRemove { get; set; } = new List<string> { "Poisoned" };

        [Description("List of status effects which pills should remove from the player.")]
        public List<string> PillsEffectsToRemove { get; set; } = new List<string> { "Concussed" };

        [Description("List of status effects which adrenaline should remove from the player.")]
        public List<string> AdrenalineEffectsToRemove { get; set; } = new List<string> { "Panic" };

    }
}
