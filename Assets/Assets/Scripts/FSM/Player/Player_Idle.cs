namespace FSM.Player
{
    public class Player_Idle : Istate<PlayerFSM>
    {
        private PlayerFSM m_PLayer;
    

        public Player_Idle(PlayerFSM player)
        {
            m_PLayer = player;
        }
        public override void OnStateEnter()
        {
        }

        public override void OnStAteUpdate()
        {
        }

        public override void OnStateExit()
        {
        }
    }
}
