using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
	Vector2 dir = Vector2.right;
	public List<Transform> tail = new List<Transform>();
	bool ate = false;
	public GameObject TailPrefab;
	public GameObject cam;
	private AppleSpawner AppleSpawner;
	void Start()
	{
		AppleSpawner = cam.GetComponent<AppleSpawner>();
		InvokeRepeating("Move", 0.1f, 0.1f); 
	}
	void Update()
	{
		 if (Input.GetKey(KeyCode.RightArrow) && dir != Vector2.left)
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow) && dir != Vector2.up)
			dir = -Vector2.up;
		else if (Input.GetKey(KeyCode.LeftArrow) && dir != Vector2.right)
				dir = -Vector2.right;
		else if (Input.GetKey(KeyCode.UpArrow) && dir != Vector2.down)
			dir = Vector2.up;
	}
	void Move ()
	{
		Vector2 vec = transform.position;
		transform.Translate(dir);
		if (ate)
		{
			GameObject g =(GameObject)Instantiate(TailPrefab, vec, Quaternion.identity);
			tail.Insert(0, g.transform);
			ate = false;
			AppleSpawner.Spawn ();
		}
		else if (tail.Count > 0)
		{
			tail.Last().position = vec;
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name.StartsWith("FoodPrefab"))
		{
			ate = true;
			Destroy(col.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D coll)
	{
		SceneManager.LoadScene (1);
	}
}
