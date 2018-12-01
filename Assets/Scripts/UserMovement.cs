using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{


	public float baseSpeed;
	public float speed;

	// Use this for initialization
	void Start ()
	{
		speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 delta = new Vector3();
		delta.x = Time.deltaTime * speed * Input.GetAxis("Horizontal");
		delta.y = Time.deltaTime * speed * Input.GetAxis("Vertical");
		transform.Translate(delta);
	}
}
