using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    public Joystick joystick;
    Vector3 addedPos;
    Animator playerAnim;

    public float speed;
    float xRange = 23f;
    public float turnSpeed;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movePlayer();
        sceneSet();

        if (Input.GetMouseButton(0))
        {
            playerAnim.SetBool("idleAnim", true);
        }
        else
        {
            playerAnim.SetBool("idleAnim", false);
        }

        if (joystick.Vertical < 0)
        {
            speed = 15;
        }
    }

    public void movePlayer()
    {
        //playerRb.velocity = new Vector3(joystick.Horizontal * speed * Time.deltaTime, transform.position.y, joystick.Vertical * speed * Time.deltaTime);

        addedPos = new Vector3(joystick.Horizontal * speed * Time.deltaTime, 0, joystick.Vertical * speed * Time.deltaTime);
        transform.position += addedPos;

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            //Vector3 localForward = transform.worldToLocalMatrix.MultiplyVector(transform.right);
            //clone.transform.Rotate(localForward, speedRight);
            //transform.rotation = Quaternion.LookRotation(playerRb.velocity);

            transform.rotation = Quaternion.LookRotation(addedPos);
            Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
        }
        
    }

    public void sceneSet()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
