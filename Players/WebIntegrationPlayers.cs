using Exiled.API.Enums;
using Exiled.API.Features;

using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace WebIntegrationPlayers
{
    /// <summary>
    /// Links A PHP Web Server With MySql And SCP:SL Players List
    /// </summary>
    public class WebIntegrationPlayers : Plugin<Config>
    {
        private static readonly WebIntegrationPlayers InstanceValue = new WebIntegrationPlayers();
        /// <summary>
        /// Gets the <see cref="WebIntegrationPlayers"/> instance.
        /// </summary>
        public static WebIntegrationPlayers Instance => InstanceValue;

        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        private Events.PlayerEvents player;
        private Events.ServerEvents server;

        private WebIntegrationPlayers()
        {

        }

        public override void OnEnabled()
        {
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            player = new Events.PlayerEvents();
            server = new Events.ServerEvents();

            Player.Left += player.OnLeft;
            Player.Joined += player.OnJoin;
            Server.EndingRound += server.RoundEnd;
        }
    }
}
