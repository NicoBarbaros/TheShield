using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot = false;
	private Renderer rend;
	// Use this for initialization
	void Start () 
	{
		rend = this.gameObject.GetComponent<Renderer> ();
	}

	void Update()
	{
		if(rend.isVisible)
		{

		}
	}
}
