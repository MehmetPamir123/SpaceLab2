using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    PlayerHealth playerHealth;
    public Slider slider;
    public float durationTime;
    public float geatherTime;
    public bool isGeathering;

    public float health;
    public float fuel;
    public float energy;
    public float coin;

    PlayerStats playerStats;
    private void Start()
    {
        slider.maxValue = geatherTime;
        slider.value = geatherTime;
        isGeathering = false;
    }
    private void Update()
    {
        if (!isGeathering) { durationTime -= Time.deltaTime; }
        if(durationTime <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isGeathering = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            geatherTime-= Time.deltaTime;
            slider.value = geatherTime;
        }
        if (geatherTime <= 0)
        {
            Geathered();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isGeathering = false;
        }
    }
    void Geathered()
    {
        playerStats.Energy += energy;
        playerStats.Fuel += fuel;
        playerStats.Coin += coin;

        playerHealth.PlayerTakeDamage(-health);
    }
}
