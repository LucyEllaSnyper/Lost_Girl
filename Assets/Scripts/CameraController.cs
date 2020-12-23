using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }


    /*
     * follow and rotate script, not exact
     * 
    //the player info
    public Transform lookAt;
    //camera info
    public Transform camTransform;

    private Camera cam;

    private float distance = 3.0f;
    private float posX = 0.0f;
    private float posY = 0.0f;
    private float sensivityX = 4.0f;
    private float sensivityY = 1.0f;


    private void Start()
    {
        camTransform = transform;
        //gets the first main camera in the scene
        cam = Camera.main;

    }

    private void Update()
    {
        posX += Input.GetAxis("Mouse X");
        posY += Input.GetAxis("Mouse Y");
    }

    //now calculate the position of the camera
    private void LateUpdate()
    {
        Vector3 dir = new Vector3(-2, 5, -distance);
        Quaternion rotation = Quaternion.Euler(posY, posX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        
    }
    */


}
