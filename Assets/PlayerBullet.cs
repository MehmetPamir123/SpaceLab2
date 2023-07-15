using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerBullet : MonoBehaviour
{
    public Bullets bulletStats;
    public Vector3 direction;


    float duration;
    private void Start()
    {
        duration = bulletStats.Durability;

    }
    public void Update()
    {
        if (duration <= 0)
            DestroyBullet();
        duration -= Time.deltaTime;
        direction = transform.right * Time.deltaTime * bulletStats.Speed;
        transform.position += transform.up * Time.deltaTime * bulletStats.Speed*000.5f;
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
        if(damagable != null)
        {
            damagable.TakeDamage(bulletStats.Damage);
            Destroy(this.gameObject);
        }
        

    }
}
