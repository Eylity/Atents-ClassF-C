public abstract class Istate<T>
{
    private T m_Player;

    public abstract void OnStateEnter();
    public abstract void OnStAteUpdate();
    public abstract void OnStateExit();

}

public enum EPlayerState
{
    Idle,
    Move,
    Attack,
    FlyAttack,
    Length
}
