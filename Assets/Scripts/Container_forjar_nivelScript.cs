using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtencionsEnum;
public class Container_forjar_nivelScript : MonoBehaviour,Initiable
{

    public Button btn_op1;
    public Button btn_op2;
    public Button btn_op3;
    public Image Image;
    public Text texto;

    private string Originaltext;
    public Forja Forja;
    void Awake()
    {
        Originaltext = texto.text;
    }

    void Start()
    {
        btn_op1.onClick.AddListener(() => ForjarDanio());
        btn_op2.onClick.AddListener(() => ForjarCuracion());
        btn_op3.onClick.AddListener(() => ForjarEfecto());
       
    }

    private void ForjarEfecto()
    {
       var val = Go_UIScript._Go_UIScript.SliderValue();
        var result = val > 0;
        if (val > 0) {

            Forja.Efecto += val;
            this.RefreshStats();
        }
        Go_UIScript._Go_UIScript.ForjarElemento(result);
        


    }

    private void ForjarCuracion()
    {
        var val = Go_UIScript._Go_UIScript.SliderValue();
        var result = val > 0;
        if (val > 0)
        {

            Forja.Curacion += val;
            this.RefreshStats();
        }
        Go_UIScript._Go_UIScript.ForjarElemento(result);
    }

    private void ForjarDanio()
    {
        var val = Go_UIScript._Go_UIScript.SliderValue();
        var result = val > 0;
        if (val > 0)
        {

            Forja.Dannio += val;
            this.RefreshStats();
        }
        Go_UIScript._Go_UIScript.ForjarElemento(result);
    }

    void OnEnable()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        RefreshStats();
    }

    private void RefreshStats() {

       

        texto.text = string.Format(Originaltext,
        this.Forja.Dannio,
        this.Forja.Curacion,
        this.Forja.Efecto);

        Image.color = Forja.elemento.ColorDeElemento();
    }
}
