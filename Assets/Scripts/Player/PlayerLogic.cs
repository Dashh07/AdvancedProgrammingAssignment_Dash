using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic
{
    private readonly  Player player;
    private readonly IInputService inputService;
    private readonly IPlatform platformService;

    private int health;
    private int maxHealth;
    private int ammo;
    private float shootTimer;
    
    public PlayerLogic(Player player, IInputService inputService, IPlatform platformService, SO_Attributes playerData)
    {
        this.player = player;
        this.inputService = inputService;
        this.platformService = platformService;

        health = playerData.health;
        maxHealth = playerData.maxHealth;
        health = maxHealth;
        ammo = playerData.Ammo;
        shootTimer = 0f;
        
        player.healthBar.SetMaxHealth(maxHealth);
        player.transform.position = player.spawnPoint.position;

    }

    public void Tick()
    {
        shootTimer += Time.deltaTime;
        
        if (inputService.IsJumpPressed() && Grounded())
        {
            Jump();
        }
        if (inputService.isFiring() && shootTimer >= 0.5f && ammo > 0)
        {
            Shoot();
            ammo--;
            shootTimer = 0f;
        }
    }
    
    public void FixedTick()
    {
        Vector2 moveAmt = inputService.GetMovementInput();
        Move(moveAmt);
        Rotation(moveAmt);
        
    }
    
    private void Jump()
    {
        player.m_rb.AddForce(new Vector2(0f, player.jumpForce), ForceMode2D.Impulse);
    }
    
    private void Move(Vector2 moveAmt)
    {
        player.m_rb.linearVelocity = new Vector2(moveAmt.x * player.moveSpeed, player.m_rb.linearVelocity.y);
    }
    
    private void Rotation (Vector2 moveAmt)
    {
        if (moveAmt.x > 0)
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (moveAmt.x < 0)
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private bool Grounded()
    {
        return Physics2D.CapsuleCast(player.transform.position, player.capsuleSize, CapsuleDirection2D.Vertical, 0f, Vector2.down,player.castDistance,player.whatIsGround);
    }
    
    
    
    private void Shoot()
    {
        shootTimer = 0f;
        var bullet = Object.Instantiate(player.bulletPrefab, player.bulletSpawn.position, player.bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody2D>().linearVelocity = player.bulletSpawn.right * player.bulletSpeed;
    }
    
   public void TakeDamage(int damage)
    {
        Debug.Log("Player TAKING DAMAGE: " + damage);
        health -= damage;
        player.healthBar.SetHealth(health);
        Die();
    }
    private void Die()
    {
        if (health <= 0)
        {
            Debug.Log("Player DEAD!");
            Object.Destroy(player.gameObject);
            SceneManager.LoadScene("Main");
        }
    }
}
