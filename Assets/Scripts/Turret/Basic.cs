using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic : MonoBehaviour
{
    public GameObject bullet;
    public float attackSpeed;

    private LookAt la;
    private float cooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        la = GetComponentInParent<LookAt>();
    }

    private void Shoot()
    {
        Debug.Log("Shooting");
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = transform.position;
        Vector3 rightVector = transform.TransformVector(Vector3.right);
        Debug.Log(rightVector);
        b.transform.position += rightVector * 0.04f;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle shooting
        if(cooldown <= 0)
        {
            // Ready to shoot, check if aligned first
            if (la.IsAligned)
            {
                Shoot();
                cooldown = 1f / attackSpeed;
            }
        } else
        {
            // Reduce cooldown
            cooldown -= Time.deltaTime;
        }
        
    }
}
