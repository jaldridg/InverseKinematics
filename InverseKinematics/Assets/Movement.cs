using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Translation
        float horizontalMovementTrig = Input.GetAxisRaw("Horizontal") * Mathf.Sin(transform.rotation.y);
        float verticalMovementTrig = Input.GetAxisRaw("Vertical") * Mathf.Cos(transform.rotation.y);
        Vector2 movement = new Vector2(horizontalMovementTrig, verticalMovementTrig);
        Vector3 velocity = new Vector3(movement.normalized.x, 0.0f, movement.normalized.y) * speed * Time.deltaTime;
        transform.position += velocity;

        // Rotates the whole player when looking left/right
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0.0f, mouseXInput, 0.0f));

        // Rotates the head of the player when looking up/down
        float mouseYInput = Input.GetAxis("Mouse Y");
        Transform headTransform = transform.Find("Head");
        headTransform.Rotate(new Vector3(0.0f, 0.0f, mouseYInput));
    }
}
