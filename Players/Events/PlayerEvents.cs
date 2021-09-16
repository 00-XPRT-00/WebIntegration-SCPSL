using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace WebIntegrationPlayers.Events
{
    /// <summary>
    /// All Player Events In The Plugin
    /// </summary>
    class PlayerEvents
    {
        public string tbl { get; private set; } = WebIntegrationPlayers.Instance.Config.db.TableName;

        private DataBase.DataBase database;
        /// <summary>
        /// When A Player Leaves The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnLeft(LeftEventArgs ev)
        {
            database = new DataBase.DataBase();
            string uname = ev.Player.Nickname;
            int uid = ev.Player.Id;
            string leavemsg = WebIntegrationPlayers.Instance.Config.PlayerLeave;
            leavemsg = leavemsg.Replace("{userid}", $"{uid}");
            leavemsg = leavemsg.Replace("{username}", $"{uname}");
            Log.Info(leavemsg);
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
            database.delplr(uname, tbl);
        }

        /// <summary>
        /// When A Player Joins The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnJoin(VerifiedEventArgs ev)
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
            database = new DataBase.DataBase();
            int uid = ev.Player.Id;
            string uname = ev.Player.Nickname;
            string rank = ev.Player.GroupName;
            if (ev.Player.GroupName == "") { rank = WebIntegrationPlayers.Instance.Config.DefaultRank; }
            string joinmsg = WebIntegrationPlayers.Instance.Config.PlayerJoin;
            joinmsg = joinmsg.Replace("{userid}",$"{uid}");
            joinmsg = joinmsg.Replace("{username}",$"{uname}");
            joinmsg = joinmsg.Replace("{userrank}",$"{rank}");
            Log.Info(joinmsg);
            database.insplr(uid, uname, rank, tbl);
        }
    }
}
