using System;
using System.Collections.Generic;
using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine.States;
using Core.Services.InteractionService;
using Core.Services.SceneRepository;

namespace Core.Infractructure.StateMachine
{
    public class StateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public StateMachine(IFactory factory, ISceneRepository sceneRepository, IInteractionService interactionService)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(InitializeState)] = new InitializeState(this, factory,sceneRepository,interactionService),
                [typeof(ScenarioState)] = new ScenarioState(sceneRepository),
                [typeof(EndState)] = new EndState(sceneRepository)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayloadedState<TPayLoad>
        {
            var state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();

            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}