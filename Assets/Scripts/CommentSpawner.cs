using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CommentSpawner : MonoBehaviour {

	private GameObject m_currentObject;
	public GameObject rightClickMenuPrefab;
	public GameObject worldSpaceRightClickCanvasPrefab;
	public GameObject commentMarkerPrefab;

	private Camera m_ARcamera;
	private Ray m_ray; 
	private RaycastHit m_hit;
	private Quaternion m_hitAngle; 
	private GameObject m_newCommentMarkerClone;
	private GameObject m_rightClickMenu;
	private GameObject m_rightClickMenuCanvas;

	private GameObject m_worldSpaceRightClickCanvas;


	// Use this for initialization
	void Start () {
		m_ARcamera = GetComponent<Camera> ();
		m_rightClickMenuCanvas = GameObject.Find ("RightClickMenuCanvas");

		m_currentObject = GameObject.Find("CurrentObject"); 

	}
	
	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) { //If the screen is touched...
			m_ray = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);//create raycast from point of touch
			if (Physics.Raycast (m_ray, out m_hit)) {
				if (m_hit.collider.name == "CurrentObject") {//if the raycast hits an object name Currentobject...

					Quaternion m_hitAngle = Quaternion.LookRotation(m_hit.normal);//set quarternion variable
					m_newCommentMarkerClone = Instantiate (commentMarkerPrefab, m_hit.point, m_hitAngle, m_currentObject.transform) as GameObject;//create comment marker on the point of the raycast hit and set the parent to be shared object

					m_worldSpaceRightClickCanvas = Instantiate (worldSpaceRightClickCanvasPrefab, m_currentObject.transform) as GameObject;//create the comment UI using the prefab and set the parent to be the shared object


					Vector3 markerPos = m_newCommentMarkerClone.transform.position;//new position markerPos is equal to the position of the newly created comment marker
					m_worldSpaceRightClickCanvas.transform.position = markerPos + new Vector3(0.001f,0.005f, -0.011f);//set the position of the comment marker to be equal to it's own position plus a new vector - this offsets the marker so it doesn't appear to be inside the shared object
					m_worldSpaceRightClickCanvas.transform.localScale = new Vector3(0.001f,0.001f,0.001f);//set the scale of the new comment UI
				
				}
			
			}
		}
			
	}
}
