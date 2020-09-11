using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("References")]
    public Enemy_Health enemyHealth;
    public SpriteRenderer enemyRenderer;
    public Rigidbody2D rb2d;
    public Cannonball cannonball;
    public GameManager sManager;
    public GameObject scoreManager;
    public GameObject childs;
    public GameObject explosion;
    public GameObject player;
    public Transform enemyTrasnform;
    [Header("Movement Settings")]
    public float spd = 20;
    public Transform playerPos;
    public float followDistance = 1;
    [Header("Health Settings")]
    public int currentHealth;
    public int maxHealth;
    public int damageTakenContact = 1;
    public int damageTakenProjectile = 1;
    [Header("Sprite Settings")]
    public Sprite lowHealth; 
    public int lowHealthvalue;
    public Sprite mediumHealth;
    public int mediumHealthvalue;
    public Sprite fullHealth;
    public Sprite deadSprite;
    [Header("Death Settings")]
    public bool exploded;
    public int scoreOnDeath = 1;
    
    

    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //scoreManager = GameObject.FindGameObjectWithTag("Manager");
        sManager = scoreManager.GetComponent<GameManager>();
        currentHealth = maxHealth;
        enemyHealth.SetMaxHealth(maxHealth);
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Projectile"))
        {
            TakeDamage(damageTakenProjectile);
        }
        if (col.gameObject.CompareTag("Player"))
        {
            TakeDamage(damageTakenContact);
        }
    }
    void Update()
    {
        SpriteChange();
        if(currentHealth <= 0)
        {
            Dead();
        }
        else
        {
            Movement();
        }
    }
    void Movement()
    {
        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg+90f;
        rb2d.rotation = angle;
        
        if (Vector2.Distance(transform.position, playerPos.position) > followDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, spd * Time.deltaTime);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        enemyHealth.SetHealth(currentHealth);
    }
    public void SpriteChange()
    {
        if(currentHealth <= mediumHealthvalue && currentHealth > lowHealthvalue)
        {
            enemyRenderer.sprite = mediumHealth; 
        }
        if(currentHealth <= lowHealthvalue)
        {
            enemyRenderer.sprite = lowHealth;
        }
        if(currentHealth <= 0)
        {
            enemyRenderer.sprite = deadSprite;
        }
    }
    public void Dead()
    {
        if(exploded == false)
        {
            GameObject explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionEffect, 1.5f);
            exploded = true;
            if (player.GetComponent<Player_Mov>().currentHealth > 0)
            {
                sManager.score++;
            }
            childs.SetActive(false);
            Destroy(gameObject, 5f);
        }

    }
}
