using TMPro;
using UnityEngine;

public static class GameManager
{
   
    private static int score = 0;
    
    public static TextMeshProUGUI scoreText;
    
    public static void UpdateScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Enemies Killed: " + score.ToString();
        }
    }
    
   
    
}
