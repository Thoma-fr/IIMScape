using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenTable : MonoBehaviour
{
    public List<GameObject> pieces;
    //public static BrokenTable instance;
    public int count;
    public GameObject text;
    private void Awake()
    {

    }

    public void CheckPieces( int i)
    {
        count ++;
        pieces[i].SetActive(true);
        if (count >= pieces.Count)
        {
            text.SetActive(true);
        }
    }
}
