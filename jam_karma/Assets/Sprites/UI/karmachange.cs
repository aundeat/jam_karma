using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class karmachange : MonoBehaviour
{
    
    public GameObject player ;
    public int karma1;

    private void Update()
    {
        add();
    }
    public void add ()
    {
       karma1 = player.GetComponent<PlayerAttributes>().karma;

        GetComponent<Slider>().value = karma1 ;
       
    }
} 
