using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerMove : MonoBehaviour
{

	public CharacterController controller;
    protected Joystick joystick;
	public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();

    }
    void Update()
    {
     float horizontal = joystick.Horizontal;
     float vertical = joystick.Vertical;
     Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

     if(direction.magnitude >=0.1f)
     {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
     	controller.Move(direction * speed * Time.deltaTime);
     }

    }
}
