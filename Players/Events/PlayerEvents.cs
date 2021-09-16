using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace WebIntegrationPlayers.Events
{
    /// <summary>
    /// All Player Events In The Plugin
    /// </summary>
    class PlayerEvents
    {
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
            database.delplr(uname);
        }

        /// <summary>
        /// When A Player Joins The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnJoin(VerifiedEventArgs ev)
        {
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
            database.insplr(uid, uname, rank);
        }
    }
}
