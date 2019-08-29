using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CameraScaler : MonoBehaviour {

    [SerializeField] float correctWidth = 20;

	void Start () {
        // Creates a camera with the same width with any aspect ratio 
        this.GetComponent<Camera>().orthographicSize = correctWidth / 2 / this.GetComponent<Camera>().aspect;
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(correctWidth, (correctWidth / 2 / this.GetComponent<Camera>().aspect) * 2, 50));
        Handles.Label(this.transform.position + Vector3.up * (correctWidth / 2 / this.GetComponent<Camera>().aspect) + Vector3.left * (correctWidth / 2 - 0.2f), "Camera's real size");
    }
}