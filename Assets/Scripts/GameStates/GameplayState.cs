using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class GameplayState: IGameState
{
    private readonly GameState gameState;
    private readonly ServiceLocators serviceLocators;
    
    public GameplayState(GameState gameState, ServiceLocators serviceLocators)
    {
        this.gameState = gameState;
        this.serviceLocators = serviceLocators;
    }
    
    public void Enter()
    {
        Debug.Log("[State] Enter Gameplay");
        Addressables.LoadSceneAsync("scene_game", LoadSceneMode.Single).Completed += OnSceneLoaded;

    }

    private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        var player = GameObject.FindFirstObjectByType<Player>();
        if (player != null)
        {
            var playerManager = player.GetComponent<Player>();
            
        }
        
        var input = serviceLocators.Get<IInputService>();
        var platform = serviceLocators.Get<IPlatform>();
        var playerLogic = new PlayerLogic(player, input, platform, player.playerData);
        player.Initialize(playerLogic);
        
        var enemy = GameObject.FindFirstObjectByType<Enemy>();
        if (enemy != null)
        {
            var enemyManager = enemy.GetComponent<Enemy>();
        }
        
        var enemyLogic = new EnemyLogic(enemy, enemy.enemyData);
        enemy.Initialize(enemyLogic);
        
        var debugMenu = GameObject.FindFirstObjectByType<DebugMenu>();
        if (debugMenu != null)
        {
            debugMenu.Initialize(gameState);
        }

    }

    public void Exit()
    {
        Debug.Log("[State] Exit Gameplay");
        // Cleanup gameplay objects, save progress, etc.
    }
    
    public void Update()
    {
        Debug.Log("[State] Update Gameplay State");
        gameState.Update();
        
        
    }

}
