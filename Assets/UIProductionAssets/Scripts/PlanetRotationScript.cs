using UnityEngine;
using System.Collections;

public class PlanetRotationScript : MonoBehaviour
{
    public float rotationspeed = 1.5f;

    // Use this for initialization
    void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {     
            transform.Rotate(Vector3.up, rotationspeed * Time.deltaTime);
	}
}
