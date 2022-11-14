using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
            RaycastHit gunhit;
        }
       
        //if (Physics.Raycast(Camera.main.transform.position, ray.direction, out gunhit, range, mask))
        //{
            
        //}
    }
}
