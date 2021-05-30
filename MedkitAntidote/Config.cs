using System.ComponentModel;
using System.Collections.Generic;
using Exiled.API.Interfaces;
using Exiled.API.Enums;

namespace MedkitAntidote
{
    public sealed class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled on this server.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Whether or not the plugin should send debug messages in console.")]
        public bool DebugEnabled { get; set; } = false;

        [Description("List of status effects which medkits should remove from the player.")]
        public List<EffectType> MedkitEffectsToRemove { get; set; } = new List<EffectType> { EffectType.Poisoned };

        [Description("List of status effects which pills should remove from the player.")]
        public List<EffectType> PillsEffectsToRemove { get; set; } = new List<EffectType> { EffectType.Concussed };

        [Description("List of status effects which adrenaline should remove from the player.")]
        public List<EffectType> AdrenalineEffectsToRemove { get; set; } = new List<EffectType> { EffectType.Panic };
    }
}