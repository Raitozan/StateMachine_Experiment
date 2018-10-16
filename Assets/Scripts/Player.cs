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
		int x = 0, y = 0;
		if(Input.GetKey(KeyCode.LeftArrow))
			x = -1;
		if (Input.GetKey(KeyCode.RightArrow))
			x = 1;
		if(Input.GetKey(KeyCode.UpArrow))
			y = 1;
		if (Input.GetKey(KeyCode.DownArrow))
			y = -1;

		direction = new Vector3 (x, y, 0.0f);
		direction = direction.normalized * speed;

		transform.position += direction * Time.deltaTime;
	}
}
