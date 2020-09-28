
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtencionsEnum;
public class Container_descubrirScript : MonoBehaviour,Initiable
{

    public GameObject fondo_descubir;

    public Button btn_op1;
    public Button btn_op2;
    public Button btn_op3;
    public Button btn_op4;
    public Button btn_op5;

    public Button btn_descubrir;

    public Image runa_descubir;

    void Awake()
    {

    }

    private ElementosEnum elementoadescubrir = ElementosEnum._none;

    private Color inital_runa_color;

    void Start()
    {
        btn_op1.onClick.AddListener(() =>SelectDescubrir(ElementosEnum.elemento_1 ));
        btn_op2.onClick.AddListener(() =>SelectDescubrir(ElementosEnum.elemento_2 ));
        btn_op3.onClick.AddListener(() =>SelectDescubrir(ElementosEnum.elemento_3 ));
        btn_op4.onClick.AddListener(() =>SelectDescubrir(ElementosEnum.elemento_4));
        btn_op5.onClick.AddListener(() => SelectDescubrir(ElementosEnum.elemento_5));
        btn_descubrir.onClick.AddListener(() => DescubrirElemento());
        inital_runa_color =  runa_descubir.color;

    }

    void DescubrirElemento()
    {

        Go_UIScript._Go_UIScript.DescubrirElemento(elementoadescubrir);
    }

    void SelectDescubrir(ElementosEnum param)
    {
        btn_descubrir.gameObject.SetActive(true);
        elementoadescubrir = param;
        Color color = inital_runa_color;
      

        runa_descubir.color = elementoadescubrir.ColorDeElemento();

        Go_UIScript._Go_UIScript.UIelemento(elementoadescubrir);

    }

    void OnEnable()
    {

    }

    void Update()
    {

    }

    public void Init()
    {
        elementoadescubrir = ElementosEnum._none;
        btn_descubrir.gameObject.SetActive(false);
        runa_descubir.color = inital_runa_color;

    }
}
