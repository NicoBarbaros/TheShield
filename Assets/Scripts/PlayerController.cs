using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour {

	public Vector3 radius;
	public float stopSmooth;
	private Quaternion rotation;
	private float currentRotation = 0.0f;
	private GameObject planet;
	void Start()
	{
		planet = GameObject.Find("Planet");
	}

	void Update()
	{

		currentRotation -= Input.GetAxis("Horizontal")*Time.deltaTime * stopSmooth;
		rotation.eulerAngles = new Vector3(0,0, currentRotation);
		//transform.localRotation = rotation;
		transform.position = rotation * radius;

		LookAtCostumized();
	}

	void LookAtCostumized()
	{
		Vector3 diff = planet.transform.position - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90f);
	}
}