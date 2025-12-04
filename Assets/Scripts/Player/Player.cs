using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour , IDamageable
{

    [Header("Player Attributes")]
    public Rigidbody2D m_rb;
    public Vector2 capsuleSize;
    public int health;
    public int maxHealth;
    public Transform spawnPoint;
    
    [Header("Movement attributes")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    
    [Header("Ground Check")]
    public float castDistance;
    public LayerMask whatIsGround;

    [Header("Shooting Attributes")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 10f;
    private int ammoCount;
    private float shootTimer;
    
    [Header("Data")]
    public  SO_Attributes playerData;
    
    [Header("UI Elements")]
    public HealthBar healthBar;
    
    private GameState State;
    private ServiceLocators services;

    private PlayerLogic playerLogic;
 
    private void Awake()
    {

    }

    public void Initialize(PlayerLogic _player)
    {
        playerLogic = _player;
    }
    
    void Update()
    {
        playerLogic?.Tick();
    }
    private void FixedUpdate()
    {
        playerLogic?.FixedTick();
    }

    public void TakeDamage(int damage)
    {
        playerLogic?.TakeDamage(damage);

    }

}
