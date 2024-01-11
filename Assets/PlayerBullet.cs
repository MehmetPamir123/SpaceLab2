using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerBullet : MonoBehaviour
{
    public Bullets bulletStats;

    float duration;
    private void Start()
    {
        duration = bulletStats.Durability;
        Invoke("DestroyBullet", bulletStats.Durability);

    }
    public virtual void Update()
    {
        Move();
    }
    public virtual void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
    public virtual void Move()
    {
        transform.position += transform.up * Time.deltaTime * bulletStats.Speed * 000.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IDamagableEnemy>() == null && collision.GetComponent<IDamagableFriend>() == null)
        {
            return;
        }

        if(gameObject.tag == "Bullet_Friend" && collision.GetComponent<IDamagableEnemy>() != null)
        {
            IDamagableEnemy damagable = collision.GetComponent<IDamagableEnemy>();
            damagable.TakeDamage(bulletStats.Damage);
            Hit();
        }
        if (gameObject.tag == "Bullet_Enemy" && collision.GetComponent<IDamagableFriend>() != null)
        {
            IDamagableFriend damagable = collision.GetComponent<IDamagableFriend>();
            damagable.TakeDamage(bulletStats.Damage);
            Hit();
        }

    }

    public void Hit()
    {

        DestroyBullet();
    }
}
