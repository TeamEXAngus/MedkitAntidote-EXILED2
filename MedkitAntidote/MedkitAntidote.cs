using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Player = Exiled.Events.Handlers.Player;

namespace MedkitAntidote
{
    public class MedkitAntidote : Plugin<Config>
    {
        public override string Name => "Medkit Antidote";
        public override string Author => "TeamEXAngus";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 4);

        //Event handler for player events
        private EventHandler eventHandler;

        //Run startup code when plugin is enabled
        public override void OnEnabled()
        {
            RegisterEvents();
            base.OnEnabled();
        }

        //Run shutdown code when plugin is disabled
        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        //Plugin startup code
        public void RegisterEvents()
        {
            eventHandler = new EventHandler(this);

            Player.UsingItem += eventHandler.OnUsedItem;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            Player.UsingItem -= eventHandler.OnUsedItem;

            eventHandler = null;
        }
    }
}