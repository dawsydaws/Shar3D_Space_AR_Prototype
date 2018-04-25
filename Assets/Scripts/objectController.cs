using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectController : MonoBehaviour {

	private GameObject m_currentObject;
	private float m_rotSpeed = 1000; 

	// Use this for initialization
	void Start () {
		m_currentObject = GameObject.Find ("CurrentObject");//set the private variable to the Gameobject named CurrentObject
	}

	//To be called by the onscreen buttons
	public void OnButtonPressX (){
		m_currentObject.transform.Rotate (new Vector3 (Time.deltaTime * m_rotSpeed, 0, 0));//rotates object in x-axis
	}

	public void OnButtonPressY (){
		m_currentObject.transform.Rotate (new Vector3 (0, Time.deltaTime * m_rotSpeed, 0));//rotates object in y-axis
	}

	public void OnButtonPressZ (){
		m_currentObject.transform.Rotate (new Vector3 (0, 0, Time.deltaTime * m_rotSpeed));//rotates object in z-axis
	}

	public void OnButtonPressScaleUp (){
		m_currentObject.transform.localScale += (new Vector3 (0.1f, 0.1f, 0.1f));//increases the scale of the object
	}

	public void OnButtonPressScaleDown (){
		m_currentObject.transform.localScale += (new Vector3 (-0.1f, -0.1f, -0.1f));//decreases the scale of the object
	}
}
