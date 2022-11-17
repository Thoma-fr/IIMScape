using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class code : MonoBehaviour
{
    public string goodcode;
    //public GameObject field;
    public TextMeshProUGUI input;
    private void Start()
    {
        //input = field.GetComponent<TextMeshProUGUI>();

    }
    private void Update()
    {
        
        if (input.text==goodcode)
        {
            Player.playerinstance.changecam(Player.gameState.lv2);
            Debug.Log("oui");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("non");
        }
    }
    
}
