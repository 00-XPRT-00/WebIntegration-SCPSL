using Exiled.API.Features;

namespace WebIntegrationPlayers.Events
{
    class ServerEvents
    {
        public string tbl { get; private set; } = WebIntegrationPlayers.Instance.Config.db.TableName;
        private DataBase.DataBase db;
        /// <summary>
        /// When The Server Is Waiting For Players
        /// </summary>
        public void OnWaitingForPlayers()
        {
            if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "1"))
            {
                tbl = tbl;
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "2"))
            {
                tbl = tbl + "_2";
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "3"))
            {
                tbl = tbl + "_3";
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "4"))
            {
                tbl = tbl + "_4";
            }
            Log.Info(WebIntegrationPlayers.Instance.Config.WaitingForPlayers);
            db = new DataBase.DataBase();
            db.clearall(tbl);
        }
    }
}
