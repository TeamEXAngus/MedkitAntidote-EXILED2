using System.Collections.Generic;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace MedkitAntidote.Handlers
{
    internal class Player
    {
        public void OnMedicalItemUsed(UsedMedicalItemEventArgs ev)
        {
            //Debug message
            if (MedkitAntidote.Instance.Config.DebugEnabled) { Log.Debug($"{ev.Player.Nickname} used an {ev.Item}."); }

            //Store the appropriate list from the config file to a temporary variable
            List<EffectType> effectList = new List<EffectType> { };
            switch (ev.Item)
            {
                case ItemType.Medkit:
                    effectList = MedkitAntidote.Instance.Config.MedkitEffectsToRemove;
                    break;

                case ItemType.Adrenaline:
                    effectList = MedkitAntidote.Instance.Config.AdrenalineEffectsToRemove;
                    break;

                case ItemType.Painkillers:
                    effectList = MedkitAntidote.Instance.Config.PillsEffectsToRemove;
                    break;
            }

            //Loop through the list from the config file and remove chosen effects from a player after they've used a medical item
            if (effectList.Count > 0)
            {
                foreach (EffectType effectName in effectList)
                {
                    //Debug message
                    if (MedkitAntidote.Instance.Config.DebugEnabled) { Log.Debug($"Trying to remove {effectName} from {ev.Player.Nickname}."); }

                    ev.Player.DisableEffect(effectName);
                }
            }
        }
    }
}