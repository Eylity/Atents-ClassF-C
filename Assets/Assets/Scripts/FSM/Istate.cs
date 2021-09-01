public abstract class Istate<T>
{
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}

public enum EPlayerState
{
    Idle,
    Attack,
    FlyAttack,
    FullSwing,
    Skill,
    Length
}
