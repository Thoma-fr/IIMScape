using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePiece : MonoBehaviour
{
    public int pieceNumber;

    public void check()
    {
        BrokenTable.instance.CheckPieces(pieceNumber);
    }
}
