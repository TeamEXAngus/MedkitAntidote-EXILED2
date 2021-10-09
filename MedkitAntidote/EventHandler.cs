using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;

namespace MedkitAntidote
{
    internal sealed class EventHandler
    {
        public MedkitAntidote plugin;
        public EventHandler(MedkitAntidote plugin) => this.plugin = plugin;

        public void OnUsedItem(UsedItemEventArgs ev)
        {
            Log.Debug($"{ev.Player.Nickname} used an {ev.Item}.",plugin.Config.DebugEnabled);

            //Store the appropriate list from the config file to a temporary variable
            List<EffectType> effectList = new List<EffectType> { };
            switch (ev.Item.Type)
            {
                case ItemType.Medkit:
                    effectList = plugin.Config.MedkitEffectsToRemove;
                    break;

                case ItemType.Adrenaline:
                    effectList = plugin.Config.AdrenalineEffectsToRemove;
                    break;

                case ItemType.Painkillers:
                    effectList = plugin.Config.PillsEffectsToRemove;
                    break;
            }

            //Loop through the list from the config file and remove chosen effects from a player after they've used a medical item
            if (effectList.Count > 0)
            {
                foreach (EffectType effectName in effectList)
                {
                    //Debug message
                    Log.Debug($"Trying to remove {effectName} from {ev.Player.Nickname}", plugin.Config.DebugEnabled);

                    ev.Player.DisableEffect(effectName);
                }
            }
        }
    }
}
