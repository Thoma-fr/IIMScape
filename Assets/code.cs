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
    public Player.gameState gameState;
    public GameObject qr1,qr2,qr3;
    public bool isending;


    private void Start()
    {
        //input = field.GetComponent<TextMeshProUGUI>();

    }
    private void Update()
    {
        
       
            if (input.text == goodcode)
            {
                if (!isending)
                {


                    Player.playerinstance.changecam(gameState);
                    Debug.Log("oui");
                    gameObject.SetActive(false);
                }
                else
                {
                    qr1.SetActive(true);
                    qr2.SetActive(true);
                    qr3.SetActive(true);
                }
            }
            else
            {
                Debug.Log("non");
            }

        }
        
    }
    
