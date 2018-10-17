using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public Vector3 direction;
	public float speed = 5.0f;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		move ();
	}

	public void move()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		direction = new Vector3 (x, y, 0.0f);
		direction = direction.normalized * speed;

		//transform.position += direction * Time.deltaTime;

		GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * Time.deltaTime);

		float dx = Input.GetAxis("RightStickHorizontal");
		float dy = Input.GetAxis("RightStickVertical");

		Vector3 targetDirection = new Vector3(dx, dy, 0.0f);
		targetDirection = targetDirection.normalized;

		if(targetDirection != Vector3.zero)
			transform.up = targetDirection;
	}
}
