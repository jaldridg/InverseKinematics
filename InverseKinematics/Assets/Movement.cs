using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float sensitivity = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0.0f, Input.GetAxisRaw("Vertical"));
        // Rotate movement based on which way the player is facing
        movement = Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up) * movement;
        Vector3 velocity = new Vector3(movement.normalized.x, 0.0f, movement.normalized.z) * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.LeftShift)) {
            transform.position += velocity * 0.5f;
        } else {
            transform.position += velocity;
        }

        // Rotates the whole player when looking left/right
        transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X") * sensitivity;

        // Rotates the head of the player when looking up/down
        Transform headTransform = transform.Find("Head");
        headTransform.eulerAngles += Vector3.left * Input.GetAxis("Mouse Y") * sensitivity;
    }
}
