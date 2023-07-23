using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("self", 1f);
    }
    private void self()
    {
        Destroy(gameObject);
    }

}
