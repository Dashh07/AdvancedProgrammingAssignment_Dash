using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      Destroy(this, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        //var self = this.gameObject.GetComponent<IDamageable>();
        
        if (damageable != null )
        {
            damageable.TakeDamage(10);
        }

        Destroy(gameObject);
    }
    
  
    
    
}
