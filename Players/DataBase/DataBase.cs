namespace WebIntegrationPlayers.DataBase
{
    /// <summary>
    /// Links The MySql Database With The Plugin
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// The Host IP For The MySql Database
        /// </summary>
        public string Host { get; } = WebIntegrationPlayers.Instance.Config.DB.DBHost;
        /// <summary>
        /// The Host Port MySql Server
        /// </summary>
        public string Port { get; } = WebIntegrationPlayers.Instance.Config.DB.DBPort;
        /// <summary>
        /// The MySql Server Username To Login With
        /// </summary>
        public string User { get; } = WebIntegrationPlayers.Instance.Config.DB.DBUser;
        /// <summary>
        /// The MySql Server Password
        /// </summary>
        public string Pass { get; } = WebIntegrationPlayers.Instance.Config.DB.DBPass;

        /// <summary>
        /// The MySql Server Database Name
        /// </summary>
        public string DBName { get; } = WebIntegrationPlayers.Instance.Config.DB.DBName;

        /// <summary>
        /// The MySql Server Table Name
        /// </summary>
        public string TableName { get; } = WebIntegrationPlayers.Instance.Config.DB.TableName;

        public void insplr(int id, string username, string rank)
        {

        }

        public void delplr(string username)
        {

        }

        public void clearall()
        {
            string sql = "DELETE * FROM `" + TableName + "`";
        }
        
    }
}
