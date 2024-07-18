using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameInstaller : LifetimeScope
{
    [SerializeField] private GameSettings gameSettings;
    
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Transform[] spawnPointsEnemy;
    [SerializeField] private Transform spawnPointsPlayer;
    [SerializeField] private Transform spawnDeadZone;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private DeadZone deadZone;

    [SerializeField] private Canvas canvas;
    [SerializeField] private HUD hud;
    [SerializeField] private GameOverScreen gameOverScreen;
    
    protected override void Configure(IContainerBuilder builder)
    {
        Time.timeScale = 1;
        
        builder.RegisterInstance(gameSettings).AsSelf();
        builder.RegisterComponent(canvas);
        builder.RegisterInstance<GameOverScreen>(gameOverScreen);
        
        SpawnDeadZoneInit(builder);
        SpawnPointInit(builder);
        PlayerInit(builder);
        GameManagerInit(builder);
        EnemySpawnerInit(builder);
        HudInit(builder);
    }

    private void HudInit(IContainerBuilder builder)
    {
        var obj = Instantiate<HUD>(hud, canvas.transform);
        builder.RegisterComponent<HUD>(obj);
    }

    private void SpawnDeadZoneInit(IContainerBuilder builder)
    {
        var obj = Instantiate<DeadZone>(deadZone, spawnDeadZone.position, spawnDeadZone.rotation);
        builder.RegisterComponent<DeadZone>(obj);
    }

    private void EnemySpawnerInit(IContainerBuilder builder)
    {
        var obj = Instantiate<EnemySpawner>(enemySpawner);
        builder.RegisterComponent<EnemySpawner>(obj);
        builder.RegisterComponent<EnemyFactory>(obj.GetComponent<EnemyFactory>());
    }

    private void GameManagerInit(IContainerBuilder builder)
    {
        var obj = Instantiate<GameManager>(gameManager);
        builder.RegisterComponent<GameManager>(obj);
        builder.RegisterEntryPoint<GameManagerPresenter>();
    }

    private void SpawnPointInit(IContainerBuilder builder)
    {
        builder.RegisterComponent(spawnPointsEnemy);
        //builder.RegisterComponent(spawnPointsPlayer);
        //builder.RegisterComponent(spawnDeadZone);
    }

    private void PlayerInit(IContainerBuilder builder)
    {
        var obj = Instantiate<PlayerController>(playerController, spawnPointsPlayer.position, spawnPointsPlayer.rotation);
        builder.RegisterComponent<PlayerController>(obj);
        builder.RegisterComponent<ObjectPool>(obj.GetComponent<ObjectPool>());
        builder.RegisterEntryPoint<PlayerPresenter>();
    }
}