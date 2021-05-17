using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Player = Exiled.Events.Handlers.Player;

namespace MedkitAntidote
{
    public class MedkitAntidote : Plugin<Config>
    {
        private static MedkitAntidote singleton = new MedkitAntidote();
        public static MedkitAntidote Instance => singleton;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public override Version RequiredExiledVersion { get; } = new Version(2, 10, 0);
        public override Version Version { get; } = new Version(1, 0, 1);

        //Event handler for player events
        private Handlers.Player player;

        //Copied from tutorial
        private MedkitAntidote()
        {
        }

        //Run startup code when plugin is enabled
        public override void OnEnabled()
        {
            RegisterEvents();
        }

        //Run shutdown code when plugin is disabled
        public override void OnDisabled()
        {
            UnregisterEvents();
        }

        //Plugin startup code
        public void RegisterEvents()
        {
            player = new Handlers.Player();

            Player.MedicalItemUsed += player.OnMedicalItemUsed;
        }

        //Plugin shutdown code
        public void UnregisterEvents()
        {
            Player.MedicalItemUsed -= player.OnMedicalItemUsed;

            player = null;
        }
    }
}