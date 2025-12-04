using System;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    
    private DebugService debugService;

    public GameObject debugPanel;
    
    private bool isOpen = false;
    
    private GameState State;
    private ServiceLocators services;
    
    public void Initialize(GameState gameState)
    {
        State = gameState;
        services = gameState.Services;
    }

    private void Awake()
    {
        debugService = new DebugService();
    }
    
    void Start()
    {
        debugPanel.SetActive(false);
    }
    
    void Update()
    {
        if (services == null) return;
        var input = services.Get<IInputService>();
        
        if (input.DebugPressed())
        {
            isOpen = !isOpen;
            debugPanel.SetActive(isOpen);
        }
        
    }
    
    
    public void OnGiveScoreButtonPressed()
    {
        debugService.AddScore();
    }
    
    public void OnAddHealthButtonPressed()
    {
        debugService.AddHealth();
    }

    public void OnKillEnemyButtonPressed()
    {
        debugService.KillEnemy();
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
   
}
