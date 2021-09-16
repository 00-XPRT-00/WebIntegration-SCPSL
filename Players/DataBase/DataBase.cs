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
        public string Host { get; } = WebIntegrationPlayers.Instance.Config.db.dbHost;
        /// <summary>
        /// The Host Port MySql Server
        /// </summary>
        public string Port { get; } = WebIntegrationPlayers.Instance.Config.db.dbPort;
        /// <summary>
        /// The MySql Server Username To Login With
        /// </summary>
        public string User { get; } = WebIntegrationPlayers.Instance.Config.db.dbUser;
        /// <summary>
        /// The MySql Server Password
        /// </summary>
        public string Pass { get; } = WebIntegrationPlayers.Instance.Config.db.dbPass;

        /// <summary>
        /// The MySql Server Database Name
        /// </summary>
        public string DBName { get; } = WebIntegrationPlayers.Instance.Config.db.dbName;

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
        /// <summary>
        /// Insert A Player Into The Database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="username"></param>
        /// <param name="rank"></param>
        public async void insplr(int id, string username, string rank, string tbl)
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
                { "dbtable", $"{tbl}" },
                { "idcol", $"{IDCol}" },
                { "usercol", $"{UsernameCol}" },
                { "rankcol", $"{UserRankCol}" },
                { "maindbtbl", $"{WebIntegrationPlayers.Instance.Config.db.TableName}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://"+ WebIntegrationPlayers.Instance.Config.WebserverUrl +"/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        /// <summary>
        /// Delete A Specific User From The Database
        /// </summary>
        /// <param name="username"></param>
        public async void delplr(string username, string tbl)
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
                { "dbtable", $"{tbl}" },
                { "idcol", $"{IDCol}" },
                { "usercol", $"{UsernameCol}" },
                { "rankcol", $"{UserRankCol}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://" + WebIntegrationPlayers.Instance.Config.WebserverUrl + "/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Clear All Players From The Server Database List
        /// </summary>
        public async void clearall(string tbl)
        {
            var values = new Dictionary<string, string>
            {
                { "o", "clear" },
                { "dbhost", $"{Host}" },
                { "dbport", $"{Port}"},
                { "dbuser", $"{User}" },
                { "dbpass", $"{Pass}" },
                { "dbname", $"{DBName}" },
                { "dbtable", $"{tbl}" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://" + WebIntegrationPlayers.Instance.Config.WebserverUrl + "/scp-server/database", content);

            var responseString = await response.Content.ReadAsStringAsync();
        }
        
    }
}
