using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    private Camera cam;
    private float startingSize, currentSize;
    private Vector2 delta;

    public float
        // Movement
        speed,
        // Zoom
        zoomRate, minSize, maxSize;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        delta = Vector2.zero;
        startingSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle camera movement
        delta = Vector2.zero;
        delta.x = Input.GetAxis("Horizontal") * speed;
        delta.y = Input.GetAxis("Vertical") * speed;

        transform.Translate(delta.x * Time.deltaTime, delta.y * Time.deltaTime, 0);

        // Handle camera zoom
        currentSize = cam.orthographicSize;
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        currentSize -= scroll * zoomRate;
        currentSize = Mathf.Clamp(currentSize, minSize, maxSize);
        cam.orthographicSize = currentSize;
    }
}
