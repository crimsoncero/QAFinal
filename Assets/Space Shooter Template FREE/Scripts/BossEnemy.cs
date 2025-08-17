using UnityEngine;

public class BossEnemy : Enemy
{
    protected override void ActivateShooting()
    {
        Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);
        Instantiate(Projectile,  gameObject.transform.position, Quaternion.Euler(new Vector3(0, 0, -5)));
        Instantiate(Projectile,  gameObject.transform.position,  Quaternion.Euler(new Vector3(0, 0, 5)));
        
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }
}
