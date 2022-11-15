using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class code : MonoBehaviour
{
    public string goodcode;
    public TMP_InputField input;
    private void Start()
    {
        input = GetComponent<TMP_InputField>();
        input.Select();
        input.ActivateInputField();
    }
    private void Update()
    {
        
        if (input.text==goodcode)
        {
            Debug.Log("oui");
        }
        else
        {
            Debug.Log("non");
        }
    }
    
}
