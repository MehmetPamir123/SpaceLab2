using UnityEngine;
using UnityEngine.UI;

public class Treasure : MonoBehaviour
{
    PlayerResourceController PRC;
    public Slider slider;
    public float durationTime;
    public float geatherTime;
    public bool isGeathering;

    public int health;
    public int fuel;
    public int energy;
    public int coin;
    private void Start()
    {
        PRC = GameObject.FindGameObjectWithTag("PlayerResourceController").GetComponent<PlayerResourceController>();
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
        PRC.HealthAdd(health);
        PRC.FuelAdd(fuel);
        PRC.EnergyAdd(energy);
        Destroy(this.gameObject);
    }
}
