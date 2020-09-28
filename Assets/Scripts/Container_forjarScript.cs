
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtencionsEnum;
public class Container_forjarScript : MonoBehaviour, Initiable
{


    public Button btn_op1;
    public Button btn_op2;
    public Button btn_op3;
    public Button btn_op4;
    public Button btn_op5;

    public GameObject run_a_forjar;

    public Button btn_Forja1;
    public Button btn_Forja2;
    public Button btn_Forja3;
    public Button btn_Forja4;

    private ElementosEnum elemento_a_forjar = ElementosEnum._none;

    private Color inital_runa_color;

    void Awake()
    {
        btn_op1.onClick.AddListener(() => SelectForjar(ElementosEnum.elemento_1));
        btn_op2.onClick.AddListener(() => SelectForjar(ElementosEnum.elemento_2));
        btn_op3.onClick.AddListener(() => SelectForjar(ElementosEnum.elemento_3));
        btn_op4.onClick.AddListener(() => SelectForjar(ElementosEnum.elemento_4));
        btn_op5.onClick.AddListener(() => SelectForjar(ElementosEnum.elemento_5));

        btn_Forja1.onClick.AddListener(() => Fojar(0));
        btn_Forja2.onClick.AddListener(() => Fojar(1));
        btn_Forja3.onClick.AddListener(() => Fojar(2));
        btn_Forja4.onClick.AddListener(() => Fojar(3));
    }

    private void Fojar(int index)
    {
        Go_UIScript._Go_UIScript.ForjarElemento(index, elemento_a_forjar);
    }

    private void SelectForjar(ElementosEnum parametro)
    {
        run_a_forjar.SetActive(true);
        elemento_a_forjar = parametro;


        var forjas = Go_UIScript._Go_UIScript.Forjas(elemento_a_forjar);

        for (int i = 0; i < forjas.Length; i++)
        {


            GameObject aux = null;
            Button auxbtn = null;
            switch (i)
            {

                case 0:
                    aux = btn_Forja1.gameObject;
                    auxbtn = btn_Forja1;
                    break;
                case 1:
                    aux = btn_Forja2.gameObject; ;
                    auxbtn = btn_Forja2;
                    break;
                case 2:
                    aux = btn_Forja3.gameObject;
                    auxbtn = btn_Forja3;

                    break;
                case 3:
                    aux = btn_Forja4.gameObject;
                    auxbtn = btn_Forja4;
                    break;
            }


            auxbtn.gameObject.SetActive(true);
            var auxim = auxbtn.GetComponent<Image>();
            if (auxim != null)
                auxim.color = elemento_a_forjar.ColorDeElemento();




        }

    }

    void Start()
    {

    }

    void OnEnable()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        run_a_forjar.SetActive(false);
    }

}
