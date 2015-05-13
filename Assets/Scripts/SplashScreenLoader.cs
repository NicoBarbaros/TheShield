using UnityEngine;
using System.Collections;

public class SplashScreenLoader : MonoBehaviour {

	public float delayTime = 5f;
	public bool done = false;

	private float timer;
	// Use this for initialization
	void Start () 
	{
	  	timer = delayTime;
		StartCoroutine ("SomeFunction");
	}

	void Update()
	{
		Debug.Log (timer);
		if(timer > 0)
		{
			timer -= Time.deltaTime;
			return;
		}

		if(done)
		{
			Application.LoadLevel(1);
		}
	}

	IEnumerator SomeFunction()
	{
		yield return null;
		done = true;
	}
	

}
