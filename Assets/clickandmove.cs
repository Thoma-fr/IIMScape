using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class clickandmove : MonoBehaviour
{
    public Transform target, target2;
    public bool istarget2;

    private void Start()
    {
        //move();
    }
    public void move()
    {

        if (!istarget2)
        {
            transform.DOMove(target2.transform.position, 2f).SetEase(Ease.OutBounce);
            istarget2 = true;
        }
        else
        {
            transform.DOMove(target.transform.position, 2f).SetEase(Ease.OutBounce);
            istarget2 = false;
        }

    }
}
