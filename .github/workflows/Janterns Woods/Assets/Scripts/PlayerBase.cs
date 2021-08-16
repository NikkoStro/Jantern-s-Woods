using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour {

    public float speed = 10;
    public Rigidbody rb;
    public bool forward;
    public bool back;
    public bool left;
    public bool right;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.W))
        {
            Determine();

            if (forward == true)
            {
                rb.velocity = new Vector3(0, 0, 1) * speed;
            }

            if (back == true)
            {
                rb.velocity = new Vector3(0, 0, -1) * speed;
            }

            if (left == true)
            {
                rb.velocity = new Vector3(-1, 0, 0) * speed;
            }

            if (right == true)
            {
                rb.velocity = new Vector3(1, 0, 0) * speed;
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            turnLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            turnRight();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            turnAround();
        }
    }

    public void Determine()
    {
        if (gameObject.transform.rotation.eulerAngles.y > -2 && gameObject.transform.rotation.eulerAngles.y < 2);
        {
            forward = true;
            back = false;
            left = false;
            right = false;
            //rb.velocity = new Vector3(0, 0, 1) * speed;
        }

        if (gameObject.transform.rotation.eulerAngles.y > 178 && gameObject.transform.rotation.eulerAngles.y < 182);
        {
            forward = false;
            back = true;
            left = false;
            right = false;
            //rb.velocity = new Vector3(0, 0, -1) * speed;
        }

        if (gameObject.transform.rotation.eulerAngles.y > 88 && gameObject.transform.rotation.eulerAngles.y < 92);
        {
            forward = false;
            back = false;
            left = false;
            right = true;
            //rb.velocity = new Vector3(1, 0, 0) * speed;
        }

        if (gameObject.transform.rotation.eulerAngles.y > -88 && gameObject.transform.rotation.eulerAngles.y < -92);
        {
            forward = false;
            back = false;
            left = true;
            right = false;
            //rb.velocity = new Vector3(-1, 0, 0) * speed;
        }
    }

    public void turnLeft()
    {
        gameObject.transform.Rotate(0, -90, 0, Space.Self);
    }

    public void turnRight()
    {
        gameObject.transform.Rotate(0, 90, 0, Space.Self);
    }

    public void turnAround()
    {
        gameObject.transform.Rotate(0, 180, 0, Space.Self);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Point")
        {
            rb.velocity = new Vector3(0, 0, 0) * speed;
        }
    }
}
