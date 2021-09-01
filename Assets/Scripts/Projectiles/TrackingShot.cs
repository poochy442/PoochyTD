using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingShot : MonoBehaviour
{
    // TODO: Change to GameObject
    public Vector3 target;

    public float speed;
    public GameObject explosion;
    
    void Update()
    {
        float calculatedSpeed = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, target) < calculatedSpeed)
        {
            // Target is hit
            transform.position = target;

            // TODO: Deal damage

            GameObject obj = Instantiate(explosion) as GameObject;
            obj.transform.position = transform.position;
            Destroy(gameObject);
        } else
        {
            // Move towards target
            Vector3 newPosition = Vector3.MoveTowards(transform.position, target, calculatedSpeed);
            Debug.Log("Old position: " + transform.position + ", new positition: " + newPosition + ", distance: " + Vector3.Distance(transform.position, newPosition) + ", speed: " + calculatedSpeed + ", time*Deltatime" + Time.deltaTime);
            transform.position = newPosition;
            // transform.position += (target - transform.position).normalized * calculatedSpeed;
        }
    }
}
