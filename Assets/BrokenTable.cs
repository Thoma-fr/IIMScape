using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTable : MonoBehaviour
{
    public List<GameObject> pieces;
    public static BrokenTable instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CheckPieces( int i)
    {
        pieces[i].SetActive(true);
    }
}
