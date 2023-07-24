using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDelete : MonoBehaviour
{
    public float destroytime = 2f;
    void Start()
    {
        StartCoroutine(Wait());
    }
    private IEnumerator Wait ()
    {
        yield return new WaitForSeconds(destroytime);

        Destroy(gameObject);
    }

}
