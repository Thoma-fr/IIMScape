using Cinemachine;

using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public enum gameState
    {
        lv1,
        lv2,
        lv3
    }

    public GameObject lv1,lv2,lv3;

    public gameState myState = gameState.lv1;

    [SerializeField] private Camera cam;
    public Transform target,target2,target3;
    public GameObject field;

    [Header("cam")]
    public GameObject vcam1,vcam2,vcam3;
    public GameObject currentCam;
    public GameObject rocurrentRoomCam;
    public GameObject roomCam1, roomCam2, roomCam3;
    
    [SerializeField] private float distanceToTarget = 10;
    public static RoomCam instance;
    private Vector3 previousPosition;
    

    public GameObject light;
    public GameObject currentobject;
    public GameObject oldobject;

    public TextMeshProUGUI buttontext;

    
    public int score;

    public TextMeshPro scoretext;

    public static Player playerinstance;

    public GameObject diceDisplay;
    public GameObject buttonclose;
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
    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        changecam(myState);
        scoretext.text = score.ToString();
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
            currentCam.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView -= 2;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            currentCam.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView += 2;
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
                else if (hit.transform.tag == "coin")
                {
                    score++;
                    Destroy(hit.transform.gameObject);
                }
                else if (hit.transform.tag == "movable")
                {
                    hit.transform.GetComponent<clickandmove>().move();
                }
                else {
                    RoomCam.instance.target = hit.transform;
                    RoomCam.instance.lookarond();
                    RoomCam.instance.GetComponent<CinemachineVirtualCamera>().Priority = 20;
                }
                if (hit.transform.tag == "code")
                {
                   // Debug.Log("oui");
                    field.SetActive(true);
                    buttonclose.SetActive(true);
                    RoomCam.instance.GetComponent<CinemachineVirtualCamera>().Priority = 1;
                }
                if (hit.transform.tag == "dice")
                {
                   // Debug.Log("oui");
                    diceDisplay.SetActive(true);
                    buttonclose.SetActive(true);
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

            currentCam.transform.position = target.position;

            currentCam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            currentCam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

            currentCam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

            previousPosition = newPosition;
        }
        
    }
    public void close()
    {
        field.SetActive(false);
        diceDisplay.SetActive(false);
        buttonclose.SetActive(false);

    }
    public void opendice()
    {
        diceDisplay.SetActive(true);
    }
    public void codebutton(int num)
    {
        Debug.Log(num);
        buttontext.text += num;
    }
    public void resetstring()
    {
        Debug.Log("reset");
        buttontext.text = "";
    }
    public void changecam(gameState state)
    {
        myState = state;
        switch (state)
        {
            case gameState.lv1:
                currentCam = vcam1;
                lv2.SetActive(false);
                break;
            case gameState.lv2:
                lv2.SetActive(true);
                lv1.transform.DOMoveX(-100, 3f);
                lv2.transform.DOMoveX(-1, 3f);
                break;
            case gameState.lv3:
                
                rocurrentRoomCam = roomCam1;
                break;
            default:
                break;
        }
        //previousPosition = currentCam.transform.position;
    }
}
