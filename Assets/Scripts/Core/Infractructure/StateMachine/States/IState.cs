namespace Core.Infractructure.StateMachine.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}