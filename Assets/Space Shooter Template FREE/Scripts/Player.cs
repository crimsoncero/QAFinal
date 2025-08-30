using UnityEngine;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    public static Player instance;

    private bool _isImmune = false;
    
    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(int damage)
    {
        if (_isImmune) return;
        
        Destruction();
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Debug.Log("Player Destroyed");
        Destroy(gameObject);
    }

    public void SetImmune(bool isImmune)
    {
        _isImmune = isImmune;
    }
}
















