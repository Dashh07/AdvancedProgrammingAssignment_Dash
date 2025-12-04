using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

public class DebugService
{
    private Player player;
    private Enemy enemy;
    
    public void AddScore()
    {
        GameManager.UpdateScore();
    }
    public void AddHealth()
    {
        player = GameObject.FindFirstObjectByType<Player>();
        if (player != null)
        {
            player.health += 20;
            if (player.health > player.maxHealth)
            {
                player.health = player.maxHealth;
            }
        }
      
    }
    public void KillEnemy()
    {
        enemy = GameObject.FindFirstObjectByType<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(9999);
        }
        
    }
    
}
