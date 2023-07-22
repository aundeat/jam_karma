using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knife : MonoBehaviour
{
    private float destroytime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroytime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
