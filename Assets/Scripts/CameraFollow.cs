using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform cameraTarget;
    private Camera mainCamera;  

	// Use this for initialization
	void Start () {
        mainCamera = this.GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        mainCamera.orthographicSize = (Screen.height / 100f) / 3f;

        if(cameraTarget != null)
        {
            // transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10f),
                0.1f);
        }
	}
}
