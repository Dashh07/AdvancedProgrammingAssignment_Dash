using UnityEngine;

public class EnemyLogic
{
    private readonly Enemy _enemy;
    
    private int health;
    private int maxHealth;
    private float distance;
    private int ammo;
    private float shootTimer;
    
    public EnemyLogic(Enemy enemy, SO_Attributes enemyData)
    {
        _enemy = enemy;
        
        health = enemyData.health;
        maxHealth = enemyData.health;
        health = maxHealth;
        ammo = enemyData.Ammo;
        shootTimer = 0f;
        
        _enemy.healthBar.SetMaxHealth(maxHealth);
        _enemy.transform.position = _enemy.spawnPoint.position;

    }
    
    public void Tick()
    {
        shootTimer += Time.deltaTime;
        
        ChasePlayer();
        if (shootTimer >= 1.5f)
        {
            Shoot();
            shootTimer = 0f;
        }
    }
    
    public void ChasePlayer()
    {
        distance = Vector2.Distance(_enemy.transform.position, _enemy.player.transform.position);
        Vector2 direction = (_enemy.player.transform.position - _enemy.transform.position).normalized;
        _enemy.transform.position += (Vector3)(direction * _enemy.speed * Time.deltaTime);
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _enemy.transform.rotation = Quaternion.Euler(Vector3.forward*angle);

        
    }
    
    public void Shoot()
    {
        if (ammo <= 0) return;
        
        GameObject bullet = Object.Instantiate(_enemy.projectile, _enemy.firePoint.position, _enemy.firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = _enemy.firePoint.right * _enemy.bulletSpeed;
        ammo--;
    }
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        _enemy.healthBar.SetHealth(health);
        Die();
    }
    public void Die()
    {
        if (health <= 0)
        {
            Debug.Log("DEAD!");
            GameManager.UpdateScore();
            var newEnemy = Object.Instantiate(_enemy.gameObject, _enemy.spawnPoint.position, _enemy.spawnPoint.rotation);
            var newEnemySpawned = newEnemy.GetComponent<Enemy>();
            var enemyLogic = new EnemyLogic(newEnemySpawned, newEnemySpawned.enemyData);
            newEnemySpawned.Initialize(enemyLogic);
            Object.Destroy(_enemy.gameObject);
        }
    }
    
}
