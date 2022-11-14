using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
	public GameObject FoodPrefab;
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;
	void Start ()
	{
		int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
		int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);
		Instantiate(FoodPrefab,  new Vector2(x, y), Quaternion.identity);
	}
	public void Spawn ()
	{
		int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);
		int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);
		Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
	}
}
