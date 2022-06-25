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
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 velocity = new Vector3(movement.normalized.x, 0.0f, movement.normalized.y) * speed * Time.deltaTime;
        transform.position += Quaternion.AngleAxis(transform.eulerAngles.y, Vector3.up).eulerAngles;

        // Rotates the whole player when looking left/right
        transform.eulerAngles += Vector3.up * Input.GetAxis("Mouse X") * sensitivity;

        // Rotates the head of the player when looking up/down
        Transform headTransform = transform.Find("Head");
        headTransform.eulerAngles += Vector3.left * Input.GetAxis("Mouse Y") * sensitivity;
    }
}
