using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable

{
    [Header("Enemy Data")]
    public  SO_Attributes enemyData;
    
    [Header("Enemy Stats")]
    public Transform spawnPoint;
    
    [Header("Shooting Attributes")]
    public Transform firePoint;
    public GameObject projectile;
    public float bulletSpeed = 10f;
    private float timer;

    [Header("Movement Attributes")]
    public float speed;
    public GameObject player;
    
    [Header("UI Elements")]
    public HealthBar healthBar;

    private EnemyLogic enemyLogic;
    
    public void Initialize(EnemyLogic _enemyLogic)
    {
        enemyLogic = _enemyLogic;
    }

 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // health = enemyData.health;
        // maxHealth = enemyData.health;
        // health = maxHealth;
        // healthBar.SetMaxHealth(maxHealth);
        // transform.position = spawnPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        enemyLogic?.Tick();
       
    }
    public void TakeDamage(int damage)
    {
       enemyLogic.TakeDamage(damage);
    }
  
   
   
}
