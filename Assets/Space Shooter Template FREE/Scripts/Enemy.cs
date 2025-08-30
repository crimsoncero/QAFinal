using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines 'Enemy's' health and behavior. 
/// </summary>
public class Enemy : MonoBehaviour {

    #region FIELDS
    [Tooltip("Health points in integer")]
    public int health;
    public int shield;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;
    public GameObject hitEffectShield;
    
    [HideInInspector] public int shotChance; //probability of 'Enemy's' shooting during tha path
    [HideInInspector] public float shotTimeMin, shotTimeMax; //max and min time for shooting from the beginning of the path
    #endregion

    private void Start()
    {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
        Debug.Log("Enemy Spawned");
    }

    //coroutine making a shot
    protected virtual void ActivateShooting() 
    {
        if (Random.value < (float)shotChance / 100)                             //if random value less than shot probability, making a shot
        {                         
            Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);             
        }
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(int damage) 
    {
        if (shield > 0)
        {
            Debug.Log("Enemy Shield Hit");
            shield -= damage;
            Instantiate(hitEffectShield,transform.position,Quaternion.identity,transform);
        }
        else
        {
            Debug.Log("Enemy Hull Hit");
            health -= damage;           //reducing health for damage value, if health is less than 0, starting destruction procedure
            if (health <= 0)
                Destruction();
            else
                Instantiate(hitEffect,transform.position,Quaternion.identity,transform);
        }
       
    }    

    //if 'Enemy' collides 'Player', 'Player' gets the damage equal to projectile's damage value
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile.GetComponent<Projectile>() != null)
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            else
                Player.instance.GetDamage(1);
        }
    }

    //method of destroying the 'Enemy'
    void Destruction()                           
    {  
        Debug.Log("Enemy Destroyed");
        Instantiate(destructionVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
