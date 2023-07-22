using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyCountdown : MonoBehaviour
{

    public float timeUntilDestroy;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(WaitForDestroy());
    }


    private IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(timeUntilDestroy);

        Destroy(gameObject);
    }
}
