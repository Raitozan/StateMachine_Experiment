using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;

	public Boid boidPrefab;
	public List<Boid> boids;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (this.gameObject);
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public List<Boid> getNeighbours(Boid boid)
	{
		List<Boid> neighbours = new List<Boid> ();
		foreach (Boid b in boids)
		{
			if (b == boid)
				continue;
			else if (Vector3.Distance (b.transform.position, boid.transform.position) <= boid.neighbourDistance)
				neighbours.Add (b);
		}
		return neighbours;
	}

	public List<Boid> getToCloseBoids(Boid boid)
	{
		List<Boid> toclose = new List<Boid> ();
		foreach (Boid b in boids)
		{
			if (b == boid)
				continue;
			else if (Vector3.Distance (b.transform.position, boid.transform.position) <= boid.personalDistance)
				toclose.Add (b);
		}
		return toclose;
	}
}
