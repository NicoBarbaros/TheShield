using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	public float projSpeed;
	private GameObject player;
	public float fireTime = .05f;

	private Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = this.gameObject.GetComponent<Renderer> ();
		player = GameObject.Find ("Player");
		//InvokeRepeating ("Fire", fireTime, fireTime);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space))
		{
			Camera.main.GetComponent<AudioSource>().Play();
			Fire ();
		}
	
	}

	void Fire()
	{
		GameObject obj = ObjectPoolManager.current.GetPooledObject ();
		if (obj == null)
			return;

		obj.transform.position = transform.position;
		//obj.transform.rotation = transform.rotation;
		obj.SetActive (true);
		obj.GetComponent<Rigidbody2D> ().velocity = player.transform.up * projSpeed;

	}
}
