using Assets.Features.OgreModule.Script.EnemyMovement;
using Zenject;

public class GolemGameObjectContextInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<WaitingComponent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<SimpleMovementComponent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<AttackSensorComponent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<MeleeAttackComponent>().FromComponentInHierarchy().AsSingle();
        Container.Bind<JumpAttackComponent>().FromComponentInHierarchy().AsSingle();
    }
}
