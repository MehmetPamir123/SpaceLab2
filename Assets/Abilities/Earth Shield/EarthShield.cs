using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthShield : MonoBehaviour
{
    public int HP;
    Transform playerTP;
    private void Start()
    {
        playerTP = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void Update()
    {
        transform.position = playerTP.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet_Enemy")
        {
            HP -= collision.GetComponent<PlayerBullet>().bulletStats.Damage;
            Destroy(collision.gameObject);
            if(HP <= 0) { Destroy(this.gameObject); };
        }
    }
}
