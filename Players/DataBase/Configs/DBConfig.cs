using System.ComponentModel;

namespace WebIntegrationPlayers.DataBase.Configs
{
    /// <summary>
    /// The DataBase Configs To Go Into The Config File
    /// </summary>
    public sealed class DBConfig
    {
        /// <summary>
        /// The Host IP For The MySql Server
        /// </summary>
        [Description("The Host IP For The MySql Server")]
        public string DBHost { get; set; } = "127.0.0.1";

        /// <summary>
        /// The Host Port For The MySql Server
        /// </summary>
        [Description("The Host Port For The MySql Server")]
        public string DBPort { get; set; } = "3306";

        /// <summary>
        /// The Username For The MySql Server
        /// </summary>
        [Description("The Username For The MySql Server")]
        public string DBUser { get; set; } = "root";

        /// <summary>
        /// The Password For The MySql Server
        /// </summary>
        [Description("The Password For The MySql Server")]
        public string DBPass { get; set; } = "";

        /// <summary>
        /// The Database Name For The MySql Server
        /// </summary>
        [Description("The Database Name You Created In The MySql Server")]
        public string DBName { get; set; } = "wi_players";

        /// <summary>
        /// The Table Name Inside The MySql Server
        /// </summary>
        [Description("The Table Name Inside The Database In The MySql Server")]
        public string TableName { get; set; } = "wi_players";

        /// <summary>
        /// The User Id Col Inside Table
        /// </summary>
        [Description("The User ID Column Name Inside The Table")]
        public string TableIDCol { get; set; } = "userid";

        /// <summary>
        /// User Name Col Inside Table
        /// </summary>
        [Description("The Username Column Name Inside The Table")]
        public string TableUNCol { get; set; } = "username";

        /// <summary>
        /// User Rank Col Inside Table
        /// </summary>
        [Description("The User Rank Column Name Inside The Table")]
        public string TableURCol { get; set; } = "userrank";
    }
}
