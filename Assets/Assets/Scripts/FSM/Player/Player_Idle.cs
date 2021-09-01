namespace FSM.Player
{
    public class Player_Idle : State
    {
        private PlayerFsm m_PLayer;
    

        public Player_Idle(PlayerFsm player)
        {
            m_PLayer = player;
        }
        public override void OnStateEnter()
        {
        }

        public override void OnStateUpdate()
        {
        }

        public override void OnStateExit()
        {
        }
    }
}
