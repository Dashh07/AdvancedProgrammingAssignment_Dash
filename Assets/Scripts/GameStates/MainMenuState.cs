using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class MainMenuState: IGameState
{
    private readonly GameState gameState;
    private readonly ServiceLocators serviceLocators;

    public MainMenuState(GameState gameState, ServiceLocators serviceLocators)
    {
        this.gameState = gameState;
        this.serviceLocators = serviceLocators;
        
    }
    

    public void Enter()
    {
        Debug.Log("[State] Enter MainMenu");
        Addressables.LoadSceneAsync("scene_mainmenu", LoadSceneMode.Single).Completed += OnSceneLoaded;

    }

    public void Exit()
    {
        Debug.Log("[State] Exit MainMenu");
        
    }

    public void Update()
    {
        Debug.Log("[State] Update MainMenu");
    }
    private void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        var ui = GameObject.FindFirstObjectByType<MainMenu>();
        if (ui != null)
            ui.SetCallbacks(() => gameState.SetState(new GameplayState(gameState, serviceLocators)));
    }
}
