using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{

	public int width;
	public int height;
	public Tile[,] grid;
	public GameObject tile;

	public List<Sprite> terrainSprites;
	public List<GameObject> treesPrefabs;

	// Use this for initialization
	void Start ()
	{
		grid = new Tile[width,height];
		for (int y = 0; y < height; y++)
		{
			for (int x = 0; x < width; x++)
			{
				Tile t = Instantiate(tile, new Vector3(x + this.transform.position.x, y + this.transform.position.y, 0), Quaternion.identity, this.transform).GetComponent<Tile>();
				t.x = x;
				t.y = y;
				float type = Random.Range(0.0f, 1.0f);
				float step = 1.0f / terrainSprites.Count;
				for (int i = 0; i < terrainSprites.Count; i++)
				{
					if (type <= step * i)
					{
						t.sr.sprite = terrainSprites[i];
						break;
					}
				}
				grid [x, y] = t;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
