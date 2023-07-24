using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyOnTouch : MonoBehaviour
{

    public string[] tags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        for(int i = 0; i < tags.Length; i++)
        {
            if (other.gameObject.CompareTag(tags[i])) { 
            Destroy(gameObject);
            }
        }
    }
}
