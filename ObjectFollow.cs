using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollow : MonoBehaviour
{
    //add this code to any object that you want the camera to be able to follow
    public void OnMouseDown()
    {
        CameraControl.instance.followTransform = transform;
    }
}
