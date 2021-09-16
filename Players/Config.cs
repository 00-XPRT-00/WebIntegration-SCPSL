using Exiled.API.Interfaces;
using System.ComponentModel;
using WebIntegrationPlayers.DataBase.Configs;

namespace WebIntegrationPlayers
{
    /// <summary>
    /// Plugin Configuration Settings
    /// </summary>
    public sealed class Config : IConfig
    {
        /// <summary>
        /// If The Plugin Is Enabled Bool
        /// </summary>
        [Description("Wether or not the plugin is active")]
        public bool IsEnabled { get; set; } = true;
        
        [Description("The message sent when the server is waiting for players to join")]
        public string WaitingForPlayers { get; set; } = "Server Is Waiting For Players.";

        [Description("The message sent when someone joins the server (default will show: 'Player [2] Administrator: Admin Joined The Game.' Variables = {userid}, {username}, {userrank})")]
        public string PlayerJoin { get; set; } = "Player [{userid}] {username}: {userrank} Joined The Game.";

        [Description("The message sent when someone leaves the server (default will show: 'Player [2] Administrator Left The Game.' Variables = {userid}, {username}")]
        public string PlayerLeave { get; set; } = "Player [{userid}] {username} Joined The Game.";

        [Description("The rank that will show in the console join message and on the player list for a user with no ranks")]
        public string DefaultRank { get; set; } = "player";

        /// <summary>
        /// The webserver url hosting the scp-server folder
        /// </summary>
        [Description("The webserver domain / ip containing the scp-server folder")]
        public string WebserverUrl { get; set; } = "127.0.0.1";

        /// <summary>
        /// Adds The Database Configs To Config File
        /// </summary>
        [Description("Database related configs")]
        public DBConfig db { get; private set; } = new DBConfig();
    }
}
