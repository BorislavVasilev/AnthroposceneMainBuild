using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ResetScrollRotation : MonoBehaviour {

	public float speed = 200.0f;
	public float rotation = 0.0f;
	public float heightMod = 2.0f;
	// Use this for initialization
	void Start () {
		transform.Translate(Vector3.up/heightMod, Camera.main.transform);

		transform.rotation = Quaternion.Euler (0, 0, rotation);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
	}
}
