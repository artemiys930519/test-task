using Core.Events.Model;
using Core.Game.Player;
using Core.Infractructure.Factory;
using Core.Infractructure.StateMachine;
using Core.Services.InputService;
using Core.Services.InteractionService;
using Core.Services.PointRegisterService;
using Core.Services.SceneRepository;
using Core.Services.ScoreService;
using ScriptableObjects;
using UnityEngine;
using Zenject;
using IFactory = Core.Infractructure.Factory.IFactory;

namespace Installers
{
    public class SceneInstaller : MonoInstaller<SceneInstaller>
    {
        [SerializeField] private LevelData _levelData;
        [SerializeField] private ScenarioData _scenarioData;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.Bind<StateMachine>().AsSingle();
            Container.DeclareSignal<RaiseEnemySignal>();
            Container.Bind<IInputService>().To<InputService>().AsTransient();
            Container.Bind<ISceneRepository>().To<SceneRepository>().AsSingle();
            Container.Bind<IPointRegisterService>().To<PointRegisterService>().AsSingle();
            Container.Bind<IFactory>().To<Factory>().AsTransient().WithArguments(_levelData);
            Container.Bind<IInteractionService>().To<PhysicsRaycastInteractionService>().AsSingle();
            Container.Bind<IScoreService>().To<ScoreService>().AsSingle().WithArguments(_scenarioData);
        }
    } 
}

