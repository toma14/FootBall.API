namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class PlayerService : IPlayerInterface
    {
        public Player GetConcrettePlayer(Player player)
        {
            if (player == null ||
                player.Name.Length < 20 || player.Surname.Length < 20 )
            {
                return null;
            }
            return player;
        }
    }
}