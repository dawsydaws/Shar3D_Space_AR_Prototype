using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtCamera : MonoBehaviour {

	private Camera m_ARCamera;

	void Start () {
		m_ARCamera = Camera.main;//set the private variable to the main scene camera
	}

	void Update() 
	{
		transform.LookAt (transform.position - m_ARCamera.transform.rotation * Vector3.back, m_ARCamera.transform.rotation * Vector3.up); //Set the comments to always be facing the camera
	}

}
