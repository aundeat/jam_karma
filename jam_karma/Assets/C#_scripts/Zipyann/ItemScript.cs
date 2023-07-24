using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public int health;
    public int maxHealthBonus;
    public int ammo;
    public int money;
    public int price;
    public bool canSteal;

    public AudioClip pickupSound;

    public GameObject soundPicup;

    private AudioSource audioSource;
    private GameObject player;
    private bool canTake;
    private bool isTaken;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTake && !isTaken && (player.GetComponent<HealthScript>().health < player.GetComponent<HealthScript>().maxHealth || health == 0) &&  player.GetComponent<PlayerAttributes>().money >= price && ((!canSteal && price <=0)||Input.GetKeyDown(KeyCode.E)))
        {

            //Take item
            player.GetComponent<HealthScript>().IncreaseHealth(health);
            player.GetComponent<HealthScript>().IncreaseMaxHealth(maxHealthBonus);
            player.GetComponent<PlayerAttributes>().IncreaseAmmo(ammo);
            player.GetComponent<PlayerAttributes>().IncreaseMoney(money);

            if (!canSteal)
            {
                player.GetComponent<PlayerAttributes>().DecreaseMoney(price);

            }

            if (canSteal)
            {
                player.GetComponent<PlayerAttributes>().DecreaseKarma(1);
            }
            // Включаем AudioSource, если он был отключен
            if (!audioSource.isPlaying)
            {
                audioSource.enabled = true;
            }
            // Play pickup sound
            if (pickupSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(pickupSound);

                
                GetComponent<SpriteRenderer>().enabled = false;
                isTaken = true;
               // Instantiate(soundPicup);
            }

            StartCoroutine(WaitForDestroy());

          

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTake = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canTake = false;
        }
    }


    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
