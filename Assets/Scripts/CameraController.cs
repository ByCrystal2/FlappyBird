using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Bird player;
    Camera myCamera;
    private void Awake()
    {
        myCamera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player").GetComponent<Bird>();
    }
    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 NewCameraTransform = new Vector3 (player.transform.position.x, myCamera.transform.position.y, myCamera.transform.position.z);
            myCamera.transform.position = NewCameraTransform;
        }
    }
}
