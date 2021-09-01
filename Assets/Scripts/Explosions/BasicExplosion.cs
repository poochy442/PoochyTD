using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicExplosion : MonoBehaviour
{

    public float explosionTime;

    private float explodeTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (explodeTime >= explosionTime)
        {
            Destroy(gameObject);
        }
        else
        {
            explodeTime += Time.deltaTime;
        }
    }
}
