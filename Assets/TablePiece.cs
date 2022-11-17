using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablePiece : MonoBehaviour
{
    public int pieceNumber;
    public BrokenTable table;
    public void check()
    {
        table.CheckPieces(pieceNumber);
        Destroy(gameObject);
    }
}
