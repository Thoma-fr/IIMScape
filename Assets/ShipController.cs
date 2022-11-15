using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public float PlayerSpeed;
    public float shootForce;
    public GameObject bulletprefabs;
    void Update()
    {
        float amtToMove = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * amtToMove);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go = Instantiate(bulletprefabs, transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce);
            Destroy(go, 5f);
        }
    }
}
