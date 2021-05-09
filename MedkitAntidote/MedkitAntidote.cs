using System;
using Exiled.API.Enums;
using Exiled.API.Features;

using Player = Exiled.Events.Handlers.Player;

namespace MedkitAntidote 
{
    public class MedkitAntidote : Plugin<Config>
    {

        //Plugin set-up stuff which I copied from a tutorial
        private static readonly Lazy<MedkitAntidote> LazyInstance = new Lazy<MedkitAntidote>(valueFactory: () => new MedkitAntidote());
        public static MedkitAntidote Instance => LazyInstance.Value;

        //Plugin priority determines when during startup the plugin gets loaded
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

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
