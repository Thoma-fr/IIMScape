using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ship")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            
        }
    }
}
