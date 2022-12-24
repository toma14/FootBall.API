namespace FootBall.API.Interfaces
{
    using FootBall.API.Entities;
    public interface IPlayerInterface
    {
        Player GetKeyPlayer(Player player);
    }
}