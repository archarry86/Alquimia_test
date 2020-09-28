
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtencionsEnum;
public class Container_mezclarScript : MonoBehaviour,Initiable
{

  
    public Button btn_op1;
    public Button btn_op2;
    public Button btn_op3;
    public Button btn_op4;
    public Button btn_op5;

    public GameObject run_a_descubir;

    public Button btn_runa1;
    public Button btn_runa2;
    public Button btn_runa3;
    public Button btn_runa4;

    private ElementosEnum elemento_a_mezclar = ElementosEnum._none;

    private Color inital_runa_color;

    void Awake()
    {
        btn_op1.onClick.AddListener(() => SelectMezclar(ElementosEnum.elemento_1));
        btn_op2.onClick.AddListener(() => SelectMezclar(ElementosEnum.elemento_2));
        btn_op3.onClick.AddListener(() => SelectMezclar(ElementosEnum.elemento_3));
        btn_op4.onClick.AddListener(() => SelectMezclar(ElementosEnum.elemento_4));
        btn_op5.onClick.AddListener(() => SelectMezclar(ElementosEnum.elemento_5));

        btn_runa1.onClick.AddListener(() => Mezclar(0));
        btn_runa2.onClick.AddListener(() => Mezclar(1));
        btn_runa3.onClick.AddListener(() => Mezclar(2));
        btn_runa4.onClick.AddListener(() => Mezclar(3));
    }

    private void Mezclar(int runa_index)
    {
        Go_UIScript._Go_UIScript.MezclarElemento(runa_index, elemento_a_mezclar);
    }

    private void SelectMezclar(ElementosEnum parametro)
    {
        run_a_descubir.SetActive(true);
        elemento_a_mezclar = parametro;

       
        var runas = Go_UIScript._Go_UIScript.Runas(elemento_a_mezclar);

        for (int i = 0; i < runas.Length; i++) {


            GameObject aux = null;
            Button auxbtn = null;
            switch (i) {

                case 0:
                    aux = btn_runa1.gameObject;
                    auxbtn = btn_runa1;
                    break;
                case 1:
                    aux = btn_runa2.gameObject; ;
                    auxbtn = btn_runa2;
                    break;
                case 2:
                    aux = btn_runa3.gameObject;
                    auxbtn = btn_runa3;

                    break;
                case 3:
                    aux = btn_runa4.gameObject;
                    auxbtn = btn_runa4;
                    break;
            }

            if (runas[i].discovered)
            {
                auxbtn.gameObject.SetActive(true);
                var auxim = auxbtn.GetComponent<Image>();
                if (auxim != null)
                    auxim.color = parametro.ColorDeElemento();

            }
            else {
                auxbtn.gameObject.SetActive(false);
                var auxim = auxbtn.GetComponent<Image>();
                if (auxim != null)
                    auxim.color = Color.white;
            }


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
        run_a_descubir.SetActive(false);
    }
}
