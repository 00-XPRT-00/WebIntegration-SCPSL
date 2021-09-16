using Exiled.API.Features;

namespace WebIntegrationPlayers.Events
{
    class ServerEvents
    {
        private DataBase.DataBase db;
        /// <summary>
        /// When The Server Is Waiting For Players
        /// </summary>
        public void OnWaitingForPlayers()
        {
            Log.Info(WebIntegrationPlayers.Instance.Config.WaitingForPlayers);
            db = new DataBase.DataBase();
            db.clearall();
        }
    }
}
