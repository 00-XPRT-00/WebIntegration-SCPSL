using System.Collections.Generic;
using System.Net.Http;

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
        public string Host { get; } = WebIntegrationPlayers.Instance.Config.db.DBHost;
        /// <summary>
        /// The Host Port MySql Server
        /// </summary>
        public string Port { get; } = WebIntegrationPlayers.Instance.Config.db.DBPort;
        /// <summary>
        /// The MySql Server Username To Login With
        /// </summary>
        public string User { get; } = WebIntegrationPlayers.Instance.Config.db.DBUser;
        /// <summary>
        /// The MySql Server Password
        /// </summary>
        public string Pass { get; } = WebIntegrationPlayers.Instance.Config.db.DBPass;

        /// <summary>
        /// The MySql Server Database Name
        /// </summary>
        public string DBName { get; } = WebIntegrationPlayers.Instance.Config.db.DBName;

        /// <summary>
        /// The MySql Server Table Name
        /// </summary>
        public string TableName { get; } = WebIntegrationPlayers.Instance.Config.db.Table_Name;

        /// <summary>
        /// The Name For The User ID Column In The Table
        /// </summary>
        public string IDCol { get; } = WebIntegrationPlayers.Instance.Config.db.Table_id_col;

        /// <summary>
        /// The Name For The Username Column In The Table
        /// </summary>
        public string UsernameCol { get; } = WebIntegrationPlayers.Instance.Config.db.Table_un_col;

        /// <summary>
        /// The Name For The User Rank Column In The Table
        /// </summary>
        public string UserRankCol { get; } = WebIntegrationPlayers.Instance.Config.db.Table_ur_col;

        private static readonly HttpClient client = new HttpClient();
        public async void insplr(int id, string username, string rank)
        {
            var values = new Dictionary<string, string>
            {
                { "o", "ins" },
                { "id", $"{id}" },
                { "username", $"{username}" },
                { "rank", $"{rank}" },
                { "dbhost", $"{Host}" },
                { "dbport", $"{Port}" },
                { "dbuser", $"{User}" },
                { "dbpass", $"{Pass}" },
                { "dbname", $"{DBName}" },
                { "dbtable", $"{TableName}" },
                { "idcol", $"{IDCol}" },
                { "usercol", $"{UsernameCol}" },
                { "rankcol", $"{UserRankCol}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://109.154.0.65/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async void delplr(string username)
        {
            var values = new Dictionary<string, string>
            {
                { "o", "del" },
                { "username", $"{username}" },
                { "dbhost", $"{Host}" },
                { "dbport", $"{Port}" },
                { "dbuser", $"{User}" },
                { "dbpass", $"{Pass}" },
                { "dbname", $"{DBName}" },
                { "dbtable", $"{TableName}" },
                { "idcol", $"{IDCol}" },
                { "usercol", $"{UsernameCol}" },
                { "rankcol", $"{UserRankCol}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://109.154.0.65/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        public async void clearall()
        {
            var values = new Dictionary<string, string>
            {
                { "o", "clear" },
                { "dbhost", $"{Host}" },
                { "dbport", $"{Port}"},
                { "dbuser", $"{User}" },
                { "dbpass", $"{Pass}" },
                { "dbname", $"{DBName}" },
                { "dbtable", $"{TableName}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://109.154.0.65/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        
    }
}
