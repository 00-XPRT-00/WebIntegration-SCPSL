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
