using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AlertScript : MonoBehaviour
{

    public Text texto;

    public Button okbutton;
    // Start is called before the first frame update
    void Start()
    {
        okbutton.onClick.AddListener(() => { this.transform.localPosition = Go_UIScript.hide_position;  });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  


    public void ShowAlert(string mensaje) {
        texto.text = mensaje;
        this.transform.localPosition = Go_UIScript.screen_position;
    }

    internal void ShowAlert(object mensaje_runas_ok)
    {
        throw new NotImplementedException();
    }
}
