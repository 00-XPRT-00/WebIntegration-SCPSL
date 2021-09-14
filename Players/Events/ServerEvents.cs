using Exiled.Events.EventArgs;

namespace WebIntegrationPlayers.Events
{
    class ServerEvents
    {
        private DataBase.DataBase db;
        /// <summary>
        /// When A Round Ends
        /// </summary>
        /// <param name="ev"></param>
        public void RoundEnd(EndingRoundEventArgs ev)
        {
            db = new DataBase.DataBase();
            db.clearall();
        }
    }
}
