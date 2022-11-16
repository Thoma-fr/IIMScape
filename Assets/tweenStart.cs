using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class tweenStart : MonoBehaviour
{
    public List<GameObject> toTween;

    private void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        foreach (GameObject t in toTween)
        {
            Debug.Log("oui");
            t.transform.localScale = new Vector3(0, 0, 0);
        }
        foreach (GameObject t in toTween)
        {
            mySequence.Append(t.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetEase(Ease.OutBounce));
        }
    }
}
