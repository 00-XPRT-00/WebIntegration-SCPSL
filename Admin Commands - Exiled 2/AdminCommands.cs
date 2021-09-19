using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;
using System;
using Exiled.API.Enums;

namespace WebIntegration
{
    /// <summary>
    /// Links A PHP Web Server With MySql And SCP:SL Players List
    /// </summary>
    public class WI : Plugin<Config>
    {
        /// <summary>
        /// Set The InstanceValue
        /// </summary>
        internal static WI Instance;

        public override string Author => "00-XPRT-00";
        public override string Name => "WebIntegrationPlayers";
        public override Version Version => new Version(2, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        /// <summary>
        /// The Load Piority
        /// </summary>
        public override PluginPriority Priority => PluginPriority.Medium;

        private Events.PlayerEvents player;
        private Events.ServerEvents server;

        private WebIntegrationPlayers()
        {

        }

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            Log.Info("Plugin Loaded");
        }

        public override void OnDisabled()
        {
            unRegisterEvents();
        }

        /// <summary>
        /// Registering The Plugins Events
        /// </summary>
        public void RegisterEvents()
        {
            player = new Events.PlayerEvents();
            server = new Events.ServerEvents();

            Player.Left += player.OnLeft;
            Player.Verified += player.OnJoin;
            Server.WaitingForPlayers += server.OnWaitingForPlayers;
        }

        /// <summary>
        /// Unregistering The Events
        /// </summary>
        public void unRegisterEvents()
        {
            player = new Events.PlayerEvents();
            server = new Events.ServerEvents();

            Player.Left -= player.OnLeft;
            Player.Verified -= player.OnJoin;
            Server.WaitingForPlayers -= server.OnWaitingForPlayers;

            player = null;
            server = null;
        }
    }
}
