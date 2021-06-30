using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Jumper : MonoBehaviour
{

    public bool onPlatform;
    private Rigidbody rb;
    private float moveSpeed, dirX, verticalSpeedInit;

    private Vector2 screenBounds;
    private float objectWidth, objectHeight;

    private float coeffSlowDown,gmin,gmax, impulseAttenuation, grav;

    private float TouchTime;

    void Start()
    {
        onPlatform = false;
        rb = GetComponent<Rigidbody>();
        moveSpeed = 1f;
        gmin = -3f;
        verticalSpeedInit =8.5f* (float)Math.Sqrt(gmin / -10f); // values chosen so that the ball jumps at right distance
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<Renderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<Renderer>().bounds.extents.y; //extents = size of height / 2
        gmax = 0f;
        coeffSlowDown = (gmax - gmin) / 300;

        //cam = GetComponent<Camera>();

    }

    public float Get_Gravity()
    {
        return grav;
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = gmax + coeffSlowDown*transform.position.y;

        //Debug.Log(Camera.main.WorldToViewportPoint(transform.position).x);
        dirX = 0;


        if (Input.touchCount > 0)
        {
            if (Camera.main.WorldToViewportPoint(Input.GetTouch(0).deltaPosition).x > 0.5)
                {
                    dirX += -0.1f;
                }
                else { dirX += 0.1f; }
                
        }

        dirX += Input.GetAxis("Horizontal") * moveSpeed; //for computer
        //dirX = -Input.acceleration.y * moveSpeed;

        if (onPlatform)
        {
            grav = gmin + coeffSlowDown * transform.position.y;
            Physics.gravity = new Vector3(0, grav, 0);
            impulseAttenuation = (float)Math.Sqrt(grav / gmin);
            rb.velocity = new Vector3(dirX, verticalSpeedInit * impulseAttenuation, 0f); // formula of jump ! to keep the height of the jump constant, took me one morning to find ... 
            onPlatform = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity += new Vector3(dirX* impulseAttenuation, 0f, 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (rb.velocity.y < 0)
        {
            if (other.gameObject.CompareTag("platform") )
            {
                other.gameObject.GetComponent<Renderer>().material.color = Color.green;
                onPlatform = true;
            }
            else
            {
                other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }

    }

    //void LateUpdate()
    //{

    //    Vector3 viewPos = transform.position;
    //    viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
    //    viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
    //    transform.position = viewPos;
    //}
}
