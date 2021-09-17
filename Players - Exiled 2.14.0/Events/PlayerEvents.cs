using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace WebIntegrationPlayers.Events
{
    /// <summary>
    /// All Player Events In The Plugin
    /// </summary>
    class PlayerEvents
    {
        public string tbl { get; private set; } = WebIntegrationPlayers.Instance.Config.db.TableName; // Get The Table Name

        private DataBase.DataBase database;
        /// <summary>
        /// When A Player Leaves The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnLeft(LeftEventArgs ev)
        {
            database = new DataBase.DataBase();
            string uname = ev.Player.Nickname; // Get Left Players Username
            int uid = ev.Player.Id; // Get Left Players ID
            string leavemsg = WebIntegrationPlayers.Instance.Config.PlayerLeave;
            leavemsg = leavemsg.Replace("{userid}", $"{uid}"); // Replace {userid} With The Players User ID
            leavemsg = leavemsg.Replace("{username}", $"{uname}"); // Replace {username} With The Players Username
            Log.Info(leavemsg); // Send Leave Message To Console
            // Determine What Server It Is
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
            // Delete A Player From The Database Table
            database.delplr(uname, tbl);
        }

        /// <summary>
        /// When A Player Joins The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnJoin(VerifiedEventArgs ev)
        {
            // Determine What Server It Is
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
            database = new DataBase.DataBase();
            int uid = ev.Player.Id; // Get Joined Players ID
            string uname = ev.Player.Nickname; // Get Joined Players Username
            string rank = ev.Player.GroupName; // Get Joined Players Rank Name
            if (ev.Player.GroupName == "") { rank = WebIntegrationPlayers.Instance.Config.DefaultRank; } // Get The Default Rank From Config
            string joinmsg = WebIntegrationPlayers.Instance.Config.PlayerJoin; // Get The Join Message From The Config
            joinmsg = joinmsg.Replace("{userid}",$"{uid}"); // Repalce {userid} From Config With The Users ID
            joinmsg = joinmsg.Replace("{username}",$"{uname}"); // Replace {username} From Config With The Username
            joinmsg = joinmsg.Replace("{userrank}",$"{rank}"); // Replace {userrank} From Config With The Users Rank
            Log.Info(joinmsg);
            // Add A Player To The Database Table
            database.insplr(uid, uname, rank, tbl);
        }
    }
}
