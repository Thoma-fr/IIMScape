using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Windows;

public class code : MonoBehaviour
{
    public string goodcode;
    public GameObject field;
    private TMP_InputField input;
    private void Start()
    {
        input = field.GetComponent<TMP_InputField>();
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
