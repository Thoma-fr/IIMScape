using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform target;

    public GameObject vcam;
    [SerializeField] private float distanceToTarget = 10;
    public static RoomCam instance;
    private Vector3 previousPosition;
    public GameObject roomCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 Mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
            Ray ray = Camera.main.ScreenPointToRay(Mousepos);
            Debug.DrawRay(Camera.main.transform.position, ray.direction * 1000, Color.red, 5f);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, ray.direction, out hit, 100))
            {
                
                RoomCam.instance.target = hit.transform;
                RoomCam.instance.GetComponent<CinemachineVirtualCamera>().Priority = 20;
            }
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            RoomCam.instance.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        }


        if (Input.GetMouseButtonDown(1))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(1))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;

            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

            vcam.transform.position = target.position;

            vcam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            vcam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <� This is what makes it work!

            vcam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
    }
}