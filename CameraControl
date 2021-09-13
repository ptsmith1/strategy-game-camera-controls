using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attatch this script to a game object, and attatch the camera to the game object
public class CameraControl : MonoBehaviour
{
    public static CameraControl instance;

    public Transform followTransform;
    public Transform cameraTransform;

    private float movementSpeed;
    public float normalSpeed;
    public float fastSpeed;
    public float movementTime;
    public float rotationSpeed;
    public float normalRotation;
    public float fastRotation;
    private float rotateX, rotateY;

    public Vector3 newPosition;
    public Quaternion newRotation;
    public Vector3 fastZoom;
    public Vector3 normalZoom;
    public Vector3 zoomSpeed;
    public Vector3 newZoom;
    public Vector3 dragStartPosition;
    public Vector3 dragCurrentPosition;
    public Vector3 rotateStartPostition;
    public Vector3 rotateCurrentPosition;
    public Vector3 followOffset;

    void Start()
    {
        instance = this;
        newPosition = transform.position;
        newZoom = cameraTransform.localPosition;
        followOffset = new Vector3(-0f, 0f, 0f);
        //variables affecting camera sensitibity
        normalSpeed = 0.5f;
        fastSpeed = 2f;
        normalRotation = 0.7f;
        fastRotation = 2f;
        fastZoom = new Vector3(0, -0.02f, 0.04f);
        normalZoom = new Vector3(0, -0.002f, 0.004f);
    }

    //LateUpdate fixes stuttering due to the camera and object being followed updating position at the same time
    private void LateUpdate()
    {
        //when a followable object is clicked a new instance of followTransform is made and the camera position changed to the object with an offset
        if (followTransform != null)
        {
            transform.position = followTransform.position + followOffset;
            movementSpeed = 0;
        }
    }

    void Update()
    {
        //gets user inputs
        HandleKeyboardInput();
        HandleMouseInput();
        ChangeCameraSpeed();

        //updates camera transform based on inputs calculated above, using lerps smoothes out the movement
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-rotateY, rotateX, 0), Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);

        //allows exit of object follow
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followTransform = null;
        }
    }
    void ChangeCameraSpeed()
    {
        //allows camera control speed to be increased
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
            rotationSpeed = fastRotation;
            zoomSpeed = fastZoom;
        }
        else
        {
            movementSpeed = normalSpeed;
            rotationSpeed = normalRotation;
            zoomSpeed = normalZoom;
        }
    }

    void HandleMouseInput()
    {
        //mouse zoom
        if (Input.mouseScrollDelta.y != 0)
        {
            //stop you zooming inside things
            if (newZoom.y > 1f || Input.mouseScrollDelta.y < 0f)
            {
                newZoom += Input.mouseScrollDelta.y * zoomSpeed * 20f;
            }
        }

        //mouse rotate
        if (Input.GetMouseButton(1))
        {
            rotateX += Input.GetAxis("Mouse X") * rotationSpeed;
            rotateY += Input.GetAxis("Mouse Y") * rotationSpeed;

        }
    }

    void HandleKeyboardInput() 
    {
        //up and down
        if (Input.GetKey(KeyCode.Space))
        {
            newPosition += (transform.up * movementSpeed);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            newPosition += (transform.up * -movementSpeed);
        }

        //panning
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            newPosition += (transform.right * -movementSpeed);
        }

        //rotations
        if (Input.GetKey(KeyCode.Q))
        {
            rotateX += rotationSpeed * 0.4f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotateX -= rotationSpeed * 0.4f;
        }
        if (Input.GetKey(KeyCode.C))
        {
            rotateY += rotationSpeed * 0.4f;
        }
        if (Input.GetKey(KeyCode.V))
        {
            rotateY -= rotationSpeed * 0.4f;
        }

        //zoom
        if (Input.GetKey(KeyCode.R))
        {
            //to stop you zooming inside things
            if (newZoom.y > 1f)
            {
                newZoom += zoomSpeed;
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            newZoom -= zoomSpeed;
        }
    }
}
