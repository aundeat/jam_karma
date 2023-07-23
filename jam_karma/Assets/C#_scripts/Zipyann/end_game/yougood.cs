using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yougood : MonoBehaviour
{
    public GameObject player;
    private void OnCollisionEnter2D(Collision2D other)
    {
        int karma = GetComponent<PlayerAttributes>().karma;


        if (karma > 5)
        {
            SceneManager.LoadScene("youaregood");

        }
        else
        {
            SceneManager.LoadScene("youarebad");
        }
       
    }
   


}
