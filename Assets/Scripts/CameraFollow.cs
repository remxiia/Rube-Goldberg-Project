using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTransform; //follows the player
    public BoxCollider2D worldBounds; //sets boundaries for the world so the camera can't leave it

    float xMin;
    float xMax;
    float yMin;
    float yMax; //will hold the position of cam

    float camX;
    float camY; //position of our camera

    float camRatio; //y width of camera
    float camSize; //x length of camera

    Camera mainCam; //ref to camera component

    Vector3 smoothPos; //math for the staggered effect of our cam following the ball

    public float smoothRate; //speed, how quickly the cam will watch up to the player when it moves

    // Start is called before the first frame update
    void Start()
    {
        //adding smoothing: freeform movement for the camera so it's not locked onto the player
        xMin = worldBounds.bounds.min.x; //xMin will hold worldbounds, bounds (box collider components), minimum side of field, x
        xMax = worldBounds.bounds.max.x;
        yMin = worldBounds.bounds.min.y;
        yMax = worldBounds.bounds.min.y;

        mainCam = gameObject.GetComponent<Camera>();

        camSize = mainCam.orthographicSize;
        camRatio = (xMax + camSize) / 8.0f; //finding the y and x of the camera, then moving it in the middle
    }

    // Update is called once per frame
    void Update()
    {
        //you DONT want to do what's in FixedUpdate in Update bc it'll lag the camera too much
    }

    void FixedUpdate() //there is a fixed rate at which FixedUpdate is running. Anything physics related = in FixedUpdate
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camSize, yMax - camSize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + camRatio, xMax - camRatio);

        smoothPos = Vector3.Lerp(gameObject.transform.position, new Vector3(camX, camY, gameObject))
        //first parameter = current pos, second par = where we want the camera to move, third par = the rate that we want to move at

        gameObject.transform.position = smoothPOs; //set my position to what all that math above is doing

        //!!!Create a new object for world bounds!!! - give it a box collider component 
    }
}
