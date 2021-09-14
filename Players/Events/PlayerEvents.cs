using Exiled.Events.EventArgs;

namespace WebIntegrationPlayers.Events
{
    /// <summary>
    /// All Player Events In The Plugin
    /// </summary>
    class PlayerEvents
    {
        /// <summary>
        /// When A Player Leaves The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnLeft(LeftEventArgs ev)
        {
            string uid = ev.Player.Id.ToString();
            string uname = ev.Player.ToString();
            string rank = ev.Player.RankName;
        }

        /// <summary>
        /// When A Player Joins The Server
        /// </summary>
        /// <param name="ev"></param>
        public void OnJoin(JoinedEventArgs ev)
        {
            string uname = ev.Player.ToString();
        }
    }
}
