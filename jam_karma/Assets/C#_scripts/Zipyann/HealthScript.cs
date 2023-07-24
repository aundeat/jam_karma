using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    //amount of health
    public int health;

    public int maxHealth;

    //Cooldown before object can be damaged again
    public float damageCooldown;

    public bool isBoss;

    public AudioClip deathSound;

    private bool isCooldown;

    private float cooldownTime;

    private AudioSource audioSource;

    //start health at the beginning
    private int defaultHealth;

    private FlashScript flashScript;

    void Start()
    {
        defaultHealth = health;

        flashScript = GetComponent<FlashScript>();

        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCooldown && Time.time > cooldownTime)
        {
            isCooldown = false;

            if (flashScript != null)
            {
                flashScript.StopFlashing();
            }
        }
    }

    public void DecreaseHealth(int amount)
    {
        if (!isCooldown) {
            health -= amount;

            cooldownTime = Time.time + damageCooldown;

            isCooldown = true;

            if (flashScript != null)
            {
                flashScript.StartFlashing();
            }


            if (health <= 0)
            {
                /*if (!audioSource.isPlaying)
                {
                    audioSource.enabled = true;
                }*/

                if (gameObject.CompareTag("Enemy") || gameObject.CompareTag("Villager"))
                {



                    if(gameObject.transform.childCount == 1)
                    {
                        gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        gameObject.transform.GetChild(0).gameObject.transform.parent = null;
                    }

                  else  if (gameObject.transform.childCount == 2)
                    {
                        float rand = Random.Range(0, 10);

                        if(rand <= 3)
                        {
                            gameObject.transform.GetChild(0).gameObject.SetActive(true);
                            gameObject.transform.GetChild(0).gameObject.transform.parent = null;

                        }
                        else
                        {
                            gameObject.transform.GetChild(1).gameObject.SetActive(true);
                            gameObject.transform.GetChild(1).gameObject.transform.parent = null;
                        }

                        
                    }

                    if (gameObject.CompareTag("Villager"))
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().DecreaseKarma(1);
                    }

                    if (gameObject.CompareTag("Enemy"))
                    {
                        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().IncreaseKarma(1);
                    }


                    if(isBoss)
                    {
                        //TODO: Show Ending screen
                        int karma = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().karma;


                        if (karma > 0)
                        {
                            SceneManager.LoadScene("youaregood");

                        }
                        else
                        {
                            SceneManager.LoadScene("youarebad");
                        }

                    }


                    // Play death sound
                    if (deathSound != null && audioSource != null)
                    {
                        


                        GetComponent<FlashScript>().enabled = false;

                        GetComponent<SpriteRenderer>().enabled = false;
                       GetComponent<DamageOnTouch>().enabled = false;
                        
                        if(GetComponent<EnemyShooting>() != null)
                        {
                            GetComponent<EnemyShooting>().canShoot = false;
                        }

                        if (GetComponent<EnemyScript>() != null)
                        {
                            GetComponent<EnemyScript>().canMove = false;
                        }

                        GetComponent<BoxCollider2D>().isTrigger = true;

                        audioSource.PlayOneShot(deathSound);


                        // Instantiate(soundPicup);
                    }


                    //Kill enemy
                    gameObject.SetActive(false);
                  // StartCoroutine(WaitForDestroy());

                }
                else if (gameObject.CompareTag("Player"))
                {
                    //TODO: Kill Player (respawn at last checkpoint with less ammo or karma??)
                    //Test: Respawn at checkpoint
                    health = defaultHealth;
                    gameObject.GetComponent<PlayerAttributes>().ammo = 20;
                    gameObject.GetComponent<PlayerAttributes>().DecreaseKarma(10);
                    gameObject.transform.position = GetComponent<PlayerAttributes>().currentCheckpoint;

                }
            }

            //TODO: Update UI

        }

    }

    public void IncreaseHealth(int amount) 
    { 
        health += amount; 

        if(health >= maxHealth)
        {
            health = maxHealth;
        }

        //TODO: Update UI
    }


    public void IncreaseMaxHealth(int amount)
    {
        maxHealth += amount;

        //TODO: update Ui
    }

    public void DecreaseMaxHealth(int amount)
    {
        maxHealth -= amount;

        if(maxHealth <= 0)
        {
            maxHealth = 0;
        }

        //TODO: Update UI
    }

    IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }

}
