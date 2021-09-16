using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using System;

namespace WebIntegrationPlayers
{
    /// <summary>
    /// Links A PHP Web Server With MySql And SCP:SL Players List
    /// </summary>
    public class WebIntegrationPlayers : Plugin<Config>
    {
        private static readonly Lazy<WebIntegrationPlayers> InstanceValue = new Lazy<WebIntegrationPlayers>(() => new WebIntegrationPlayers());
        /// <summary>
        /// Gets the <see cref="WebIntegrationPlayers"/> instance.
        /// </summary>
        public static WebIntegrationPlayers Instance => InstanceValue.Value;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Events.PlayerEvents player;
        private Events.ServerEvents server;

        private WebIntegrationPlayers()
        {

        }

        public override void OnEnabled()
        {
            RegisterEvents();
            Log.Info("Plugin Loaded");
        }

        public override void OnDisabled()
        {
            unRegisterEvents();   
        }

        public void RegisterEvents()
        {
            player = new Events.PlayerEvents();
            server = new Events.ServerEvents();

            Player.Left += player.OnLeft;
            Player.Verified += player.OnJoin;
            Server.EndingRound += server.RoundEnd;
        }

        public void unRegisterEvents()
        {
            player = new Events.PlayerEvents();
            server = new Events.ServerEvents();

            Player.Left -= player.OnLeft;
            Player.Verified -= player.OnJoin;
            Server.EndingRound -= server.RoundEnd;

            player = null;
            server = null;
        }
    }
}
