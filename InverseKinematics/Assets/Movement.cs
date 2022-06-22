using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float sensitivity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Horizontal"));
        float xVel = movement.normalized.x * Mathf.Cos(transform.eulerAngles.y);
        float yVel = movement.normalized.y * Mathf.Sin(transform.eulerAngles.y);
        Debug.Log("Rot: " + transform.eulerAngles.y);
        Vector3 velocity = new Vector3(xVel, 0.0f, yVel) * speed * Time.deltaTime;
        transform.position += velocity;

        // Rotates the whole player when looking left/right
        transform.Rotate(new Vector3(0.0f, Input.GetAxis("Mouse X") * sensitivity, 0.0f));

        // Rotates the head of the player when looking up/down
        Transform headTransform = transform.Find("Head");
        headTransform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * sensitivity, 0.0f, 0.0f));
    }
}
