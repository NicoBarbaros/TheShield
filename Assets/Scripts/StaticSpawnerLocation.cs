using UnityEngine;
using System.Collections;

public class StaticSpawnerLocation : MonoBehaviour {

	public GameObject[] spwners;
	public float instatiateTime = 5f;

	void Start () 
	{
		SetStaticSpawners ();
		InvokeRepeating ("Instantiate", instatiateTime, instatiateTime);
	}
	
	void SetStaticSpawners()
	{
		Vector3 leftUp = new Vector3 (0f, Screen.height, 0);
		Vector2 leftDown = new Vector2 (0f, 0f);
		Vector2 rightUp = new Vector2 (Screen.width, Screen.height);
		Vector2 rightDown = new Vector2 (Screen.width, 0f);


		spwners[0].transform.localPosition = Camera.main.ScreenToWorldPoint(leftUp);
		spwners[1].transform.localPosition = Camera.main.ScreenToWorldPoint(leftDown);
		spwners[2].transform.localPosition = Camera.main.ScreenToWorldPoint(rightUp);
		spwners[3].transform.localPosition = Camera.main.ScreenToWorldPoint(rightDown);
	}

	void Instantiate()
	{
		GameObject obj = EnemyObjPooling.currentEnemy.GetPooledObject ();
		if (obj == null)
			return;
		GameObject temp = spwners[Random.Range(0, spwners.Length)];
		obj.transform.position = temp.transform.position;
		//obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
	}
}
