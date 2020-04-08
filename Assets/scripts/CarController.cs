using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
	protected Joystick joystick;
	protected Joybutton joybutton;
	protected bool carengine;


	[SerializeField]
	float accelerationPower = 7f;
	[SerializeField]
	float steeringPower = 1f;
	float steeringAmount, speed, direction;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<Joybutton>();
        carengine = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	var rb = GetComponent<Rigidbody2D>();

        steeringAmount = - (Input.GetAxis ("Horizontal") + joystick.Horizontal);
		/*speed = (Input.GetAxis ("Vertical") + joystick.Vertical) * accelerationPower;*/
		if (carengine)
		{
			speed = accelerationPower;
		}
		else
		{
			speed = 0f;
		}

		direction = Mathf.Sign(Vector2.Dot (rb.velocity, rb.GetRelativeVector(Vector2.up)));
		rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

		rb.AddRelativeForce ( - Vector2.right * rb.velocity.magnitude * steeringAmount / 2);

        rb.AddRelativeForce (Vector2.up * speed);
/*
        if (!carengine && joybutton.Pressed)
        {
        	carengine = true;
        }

        if (carengine && !joybutton.Pressed)
        {
        	carengine = false;
        }
*/
        if (joybutton.Pressed)
        {
        	carengine = true;
        }
    }
}
