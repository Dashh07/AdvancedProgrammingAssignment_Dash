using System;
using UnityEngine;
using System.Collections.Generic;


public class GameState 
{
    private IGameState gameState;
    private readonly ServiceLocators services;
    
    public GameState(ServiceLocators services)
    {
        this.services = services;
    }

    public void SetState(IGameState newState)
    {
        if (gameState != null)
        {
            gameState.Exit();
        }
        
        gameState = newState;
        gameState.Enter();
    }

    public void Update()
    {
        if (gameState != null)
        {
            gameState.Update();
        }
    }

   public ServiceLocators Services => services;
}
