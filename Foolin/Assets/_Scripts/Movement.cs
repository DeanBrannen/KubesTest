using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float mSpeed;
    public float turnSmoothTime = 0.3f; // The time it takes to turn smoothly
    private float turnSmoothVelocity; // Velocity for smoothing out turns
    public Vector2 mov;

    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 direction;

    // Update is called once per frame
    //void Update()
    //{
    //    mov = new Vector2(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"));
    //
    //
    //    Vector3 direction = rb.velocity.normalized;
    //    float dirAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //
    //
    //    Quaternion finalRotation = Quaternion.Euler(0, 0, dirAngle);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, finalRotation, tCount * rSpeed);
    //}
    //
    //private void FixedUpdate()
    //{
    //
    //    rb.AddForce(mov * mSpeed);
    //
    //}


    void Update()
    {
        // Capture input for moving left/right and up/down
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the new movement direction
        mov.x = moveHorizontal;
        mov.y = moveVertical;

        // Normalize the movement direction to ensure consistent speed in all directions
        mov.Normalize();

        // Move the player in the calculated direction
        transform.Translate(mov * mSpeed * Time.deltaTime);


        // Calculate the target rotation
        float targetAngle = Mathf.Atan2(mov.y, mov.x) * Mathf.Rad2Deg + 90f;
        Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);

        // Smoothly interpolate the current rotation towards the target rotation
        turnSmoothVelocity = Mathf.SmoothDampAngle(cube.transform.eulerAngles.z, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        cube.transform.rotation = Quaternion.Euler(0, 0, turnSmoothVelocity);
    }

}
