using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyOnTouch : MonoBehaviour
{

    public string[] tags;

    private void OnCollisionEnter2D(Collision2D other)
    {
        for(int i = 0; i < tags.Length; i++)
        {
            if (other.gameObject.CompareTag(tags[i])) { 
            Destroy(gameObject);
            }
        }
    }
}
