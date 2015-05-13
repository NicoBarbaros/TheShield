using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	// Use this for initialization
    GameObject cube;
    [SerializeField]  private float approacSpeed;
	void Start () {
      cube = GameObject.Find("Planet");
	
	}
	
	// Update is called once per frame
	void Update () {
        
		float step = approacSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, cube.transform.position, step);

	}
}
