
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Contianer_fusionarScript : MonoBehaviour
{

  
    public Button Fusionar;

    void Awake()
    {

    }

    void Start()
    {
        Fusionar.onClick.AddListener(() => FusionarBtn());
    }

     void FusionarBtn()
    {
        Go_UIScript._Go_UIScript.FusionarPdTRAVCAM();
    }

    void OnEnable()
    {

    }

 

}
