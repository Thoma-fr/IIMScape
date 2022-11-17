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
    public GameObject qrcodefin;
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
                    qrcodefin.SetActive(true);
                }
            }
            else
            {
                Debug.Log("non");
            }

        }
        
    }
    
