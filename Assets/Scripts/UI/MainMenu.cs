using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    
    [SerializeField] private Button playButton;
    private System.Action onPlayPressed;


    public void SetCallbacks(Action playPressed)
    {
        onPlayPressed = playPressed;
        playButton.onClick.AddListener(OnPlayButtonClicked);
    }
        
    
    public void OnPlayButtonClicked()
    {
        onPlayPressed?.Invoke();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
