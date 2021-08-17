using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public float rotationSpeed, marginOfError;
    public bool IsAligned;
    // public GameObject target;

    private void Start()
    {
        IsAligned = false;
    }

    void Update()
    {
        // Simulate target as mouse
        Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Look at target
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);

        // Calculate if target is ahead and set IsAligned accordingly
        float dotProduct = Vector3.Dot(vectorToTarget, transform.forward);
        if(dotProduct < -10 + marginOfError)
        {
            // Target is ahead
            IsAligned = true;
        } else
        {
            // Target is not ahead
            IsAligned = false;
        }
    }
}
