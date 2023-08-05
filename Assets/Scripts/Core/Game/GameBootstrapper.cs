using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameBootstrapper : MonoBehaviour
    {
        private StateMachine _stateMachine;
        
        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Start()
        {
            _stateMachine.Enter<InitializeState>();
        }
    }
}