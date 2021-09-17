using Exiled.API.Features;

namespace WebIntegrationPlayers.Events
{
    class ServerEvents
    {
        public string tbl { get; private set; } = WebIntegrationPlayers.Instance.Config.db.TableName; // Get The Table Name Config
        private DataBase.DataBase db;
        /// <summary>
        /// When The Server Is Waiting For Players
        /// </summary>
        public void OnWaitingForPlayers()
        {
            // Check Server Name To Determine What Server It Is
            if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "1"))
            {
                tbl = tbl; // Use Default Table Name
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "2"))
            {
                tbl = tbl + "_2"; // Add _2 To End Of Table Name
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "3"))
            {
                tbl = tbl + "_3"; // Add _3 To End Of Table Name
            }
            else if (Server.Name == WebIntegrationPlayers.Instance.Config.MainServerName.Replace("{server_num}", "4"))
            {
                tbl = tbl + "_4"; // Add _4 To End Of Table Name
            }
            Log.Info(WebIntegrationPlayers.Instance.Config.WaitingForPlayers); // Send Waiting For Players Message To Console
            db = new DataBase.DataBase();
            // Clear All From The Database
            db.clearall(tbl);
        }
    }
}
