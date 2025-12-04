using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    private GameState gameState;
    private ServiceLocators serviceLocators;
    private void Start()
    {
        Debug.Log("[Entry] Initializing Addressables...");
        Addressables.InitializeAsync().Completed += OnAddressablesReady;
    }

    private void OnAddressablesReady(AsyncOperationHandle<IResourceLocator> obj)
    {
        Debug.Log("[Entry] Addressables Ready. Starting GameStates...");
        
        serviceLocators = new ServiceLocators();
        
        #if UNITY_ANDROID || UNITY_IOS
            serviceLocators.Register<IPlatform>(new MobilePlatform());
        #else
        serviceLocators.Register<IPlatform>(new PCPlatform());
        #endif

        serviceLocators.Register<IInputService>(new InputHandler());
        
        gameState = new GameState(serviceLocators);
        
        gameState.SetState(new MainMenuState(gameState, serviceLocators));

        StartCoroutine(GameUpdateLoop());
    }
    
    private IEnumerator GameUpdateLoop()
    {
        while (true)
        {
            gameState.Update();
            yield return null;
        }
    }

  

}
