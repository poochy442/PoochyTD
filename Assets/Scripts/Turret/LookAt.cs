using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public float rotationSpeed, marginOfError;
    public bool IsAligned;

    // TODO: Change to GameObject
    public Vector3 target;

    private void Start()
    {
        IsAligned = false;
    }

    void Update()
    {
        // Simulate target as mouse - TODO: Change to enemy
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Look at target
        Vector3 vectorToTarget = target - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, rotationSpeed * Time.deltaTime);

        // Extract current rotation
        float currentAngle;
        Vector3 axis;
        transform.rotation.ToAngleAxis(out currentAngle, out axis);

        // Normalize the angles
        currentAngle = currentAngle % 360;
        currentAngle = currentAngle > 180 ? 360 - currentAngle : currentAngle;
        float desiredAngle = Mathf.Abs(angle);

        // Calculate if current angle is close enough to the desired angle to shoot
        
        if(desiredAngle - (marginOfError / 2) < currentAngle && currentAngle < desiredAngle + (marginOfError / 2))
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
