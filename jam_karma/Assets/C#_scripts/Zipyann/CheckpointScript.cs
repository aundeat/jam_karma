using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Sprite checkedSprite;

    private bool isActivated;

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated && other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAttributes>().currentCheckpoint = gameObject.transform.position;

            isActivated = true;

            GetComponent<SpriteRenderer>().sprite = checkedSprite;
        }
    }
}
