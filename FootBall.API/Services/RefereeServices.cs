namespace FootBall.API.Services
{
    using FootBall.API.Interfaces;
    using FootBall.API.Entities;
    public class RefereeServices : RefereeInterface
    {
        public Referee GetConcrettePlayer(Referee Referee)
        {
            if (Referee == null ||
                Referee.Name.Length < 20 || Referee.Surname.Length < 20)
            {
                return null;
            }
            return Referee;
        }
// aq mexute xazze RefereeInterface-s miwitlebda da Show potential fixes-isgan davwere es
        public Referee GetKeyPlayer(Referee Referee)
        {
            throw new NotImplementedException();
        }
    }
}