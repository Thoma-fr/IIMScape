using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public Transform target;
    public GameObject field;
    public GameObject vcam;
    [SerializeField] private float distanceToTarget = 10;
    public static RoomCam instance;
    private Vector3 previousPosition;
    public GameObject roomCam;

    public GameObject light;
    public GameObject currentobject;
    public GameObject oldobject;

    public int score;

    public static Player playerinstance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (playerinstance == null)
        {
            playerinstance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 Mousepos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);
        Ray ray = Camera.main.ScreenPointToRay(Mousepos);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 1000, Color.red, 5f);
        RaycastHit hover;
        if (oldobject != null)
        {
            
        }
        if (Physics.Raycast(transform.position, ray.direction, out hover, 100,3))
        {
            //light.transform.position = Vector3.Lerp(light.transform.position, hover.point, Time.deltaTime * 10);

        }
        else 
        {
            
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            vcam.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView -= 2;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            vcam.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView += 2;
        }
        if (Input.GetButton("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, ray.direction, out hit, 100,3))
            {
                if (hit.transform.tag == "piece")
                {
                    hit.transform.GetComponent<TablePiece>().check();
                    Debug.Log("piece");
                }
                if (hit.transform.tag == "coin")
                {
                    score++;
                    Destroy(hit.transform.gameObject);
                }
                else {
                    RoomCam.instance.target = hit.transform;
                    RoomCam.instance.GetComponent<CinemachineVirtualCamera>().Priority = 20;
                }
                if (hit.transform.tag == "code")
                {
                    Debug.Log("oui");
                    field.SetActive(true);
                }
                if (hit.transform.tag == "movable")
                {
                    hit.transform.GetComponent<clickandmove>().move();
                }
            }
        }
        
        if(Input.GetMouseButton(2))
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
            vcam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

            vcam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        
    }
    public void close()
    {
        field.SetActive(false);
    }
}
