using System.Collections.Generic;
using Exiled.Events.EventArgs;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace MedkitAntidote.Handlers
{
    class Player
    {

        public void OnMedicalItemUsed(UsedMedicalItemEventArgs ev)
        {
            //Debug message
            if (MedkitAntidote.Instance.Config.DebugEnabled) { Log.Debug($"{ev.Player.Nickname} used an {ev.Item}."); }

            //Store the appropriate list from the config file to a temporary variable
            List<string> effectList = new List<string> { };
            switch (ev.Item)
            {   case ItemType.Medkit:
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
            foreach (string effectName in effectList)
            {
                //Debug message
                if (MedkitAntidote.Instance.Config.DebugEnabled) { Log.Debug($"Trying to remove {effectName} from {ev.Player.Nickname}."); }

                //Actually removes the effect (if it is a valid effect)
                if (EffectType.TryParse(effectName, true, out EffectType thisEffect))
                {
                    ev.Player.DisableEffect(thisEffect);

                } else //Complain if chosen effect is not valid
                {
                    Log.Warn($"Tried to remove {effectName} from {ev.Player.Nickname}; {effectName} is not a valid effect name!");
                }
            }

        }

    }
}
