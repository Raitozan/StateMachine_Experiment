using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	public SpriteRenderer sr;
	public int x;
	public int y;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public int toCoordinate(float f)
	{
		if (f - (int)f >= 0.5f)
			return (int)f + 1;
		else
			return (int)f;
	}
}
