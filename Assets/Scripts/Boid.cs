using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

	Rigidbody2D rb;
	public float maxForce;
	public float minSpeed;
	public float maxSpeed;

	public float neighbourDistance;
	public float personalDistance;

	public float cohesionWeight;
	public float alignmentWeight;
	public float separateWeight;
	public float seekWeight;

	public Transform target;

	// Use this for initialization
	void Start ()
	{
		rb = gameObject.GetComponent<Rigidbody2D> ();
		Vector2 startDir = new Vector2 (Random.Range (-1.0f, 1.0f), Random.Range (-1.0f, 1.0f));
		rb.AddForce (startDir);
		rb.velocity = rb.velocity.normalized * minSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Cohesion ();
		Alignment ();
		Separate ();
		//Seek ();

		transform.up = rb.velocity;

		if (rb.velocity.magnitude > maxSpeed)
			rb.velocity = rb.velocity.normalized * maxSpeed;
		else if (rb.velocity.magnitude < minSpeed)
			rb.velocity = rb.velocity.normalized * minSpeed;

		Debug.Log(rb.velocity.magnitude);
	}

	void Cohesion()
	{
		Vector3 globalPos = new Vector3 (0, 0, 0);
		int count = 0;
		foreach (Boid b in GameManager.instance.getNeighbours(this))
		{
			globalPos += b.transform.position;
			count++;
		}
		if (count > 0)
		{
			globalPos /= count;
		
			Vector2 desired = globalPos - transform.position;
			desired = desired.normalized * maxSpeed;
			//Debug.DrawLine (transform.position, new Vector3(transform.position.x + desired.x*cohesionWeight, transform.position.y + desired.y*cohesionWeight, transform.position.z), Color.red);

			Vector2 steer = desired - rb.velocity;
				steer = steer.normalized * maxForce;

			rb.AddForce (steer*cohesionWeight);
		}
	}

	void Alignment()
	{
		Vector2 globalVel = new Vector2 (0, 0);
		int count = 0;
		foreach (Boid b in GameManager.instance.getNeighbours(this))
		{
			if (b.rb != null)
			{
				globalVel += b.rb.velocity;
				count++;
			}
		}
		if (count > 0)
		{
			globalVel /= count;

			Vector2 desired = globalVel;
			desired = desired.normalized * maxSpeed;
			//Debug.DrawLine (transform.position, new Vector3(transform.position.x + desired.x*alignmentWeight, transform.position.y + desired.y*alignmentWeight, transform.position.z), Color.yellow);

			Vector2 steer = desired - rb.velocity;
				steer = steer.normalized * maxForce;

			rb.AddForce (steer*alignmentWeight);
		}
	}

	void Separate()
	{
		Vector3 globalSep = new Vector3 (0, 0, 0);
		int count = 0;
		foreach (Boid b in GameManager.instance.getToCloseBoids(this))
		{
			Vector3 sepDir = transform.position - b.transform.position;
			sepDir = sepDir.normalized / sepDir.magnitude;
			globalSep += sepDir;
			count++;
		}
		if (count > 0)
		{
			globalSep /= count;

			Vector2 desired = globalSep;
			desired = desired.normalized * maxSpeed;
			//Debug.DrawLine (transform.position, new Vector3(transform.position.x + desired.x*separateWeight, transform.position.y + desired.y*separateWeight, transform.position.z), Color.blue);

			Vector2 steer = desired - rb.velocity;
				steer = steer.normalized * maxForce;

			rb.AddForce (steer*separateWeight);
		}
	}

	void Seek()
	{
		Vector2 desired = target.position - transform.position;
		desired = desired.normalized * maxSpeed;
		//Debug.DrawLine (transform.position, new Vector3(transform.position.x + desired.x*seekWeight, transform.position.y + desired.y*seekWeight, transform.position.z), Color.green);

		Vector2 steer = desired - rb.velocity;
			steer = steer.normalized * maxForce;

		rb.AddForce (steer*seekWeight);
	}
}
