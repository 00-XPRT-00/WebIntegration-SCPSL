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
            Log.Info($"Player {uname} Left The Game");
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
            Log.Info($"Player [{uid}] {uname} {rank} Joined The Game");
            database.insplr(uid, uname, rank);
        }
    }
}
