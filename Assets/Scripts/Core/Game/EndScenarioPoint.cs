using Core.Infractructure.StateMachine;
using Core.Infractructure.StateMachine.States;
using Core.Logic;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class EndScenarioPoint : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private TriggerObserver _triggerObserver;

        #endregion

        private StateMachine _stateMachine;

        [Inject]
        private void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void OnEnable()
        {
            _triggerObserver.TriggerEnter += OnEndPointEnter;
        }

        private void OnDisable()
        {
            _triggerObserver.TriggerEnter -= OnEndPointEnter;
        }

        private void OnEndPointEnter()
        {
            _stateMachine.Enter<EndState>();
        }
    }
}