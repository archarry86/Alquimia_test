
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExtencionsEnum;

public enum buttons
{

    BUTTON_RIGHT,
    BUTTON_LEFT,
    BUTTON_OPTIONS,
    FUSIONAR,
    DESCUBIR,
    FORJAR,
    MEZCLAR,
    SALIR
}

public class Go_UIScript : MonoBehaviour
{

    public static Go_UIScript _Go_UIScript;

    public static readonly Vector3 hide_position = new Vector3(0, 1047, 0);

    public const string SLIDER_CAMBIO = "SLIDER_CAMBIO";


    public static readonly Vector3 screen_position = new Vector3(0, 41, 0);

    [TextArea]
    private readonly string mensaje_runas_ok = "Yas has descubierto todas las runas de este demo para este elemento.";
    [TextArea]
    public String mensaje_fusionar = "";
    [TextArea]
    public String mensaje_descubrir = "";
    [TextArea]
    public String mensaje_mezclar = "";



    [TextArea]
    public String mensaje_forjar = "";

    public AlertScript alertSctipt;

    public GameObject container_options;
    public GameObject container_fusionar;
    public GameObject container_descubrir;
    public GameObject container_mezclar;
    public GameObject container_forjar;
    public GameObject container_forjar_nivel;


    public GameObject containercontrols;
    public GameObject btn_descubrir;

    private GameObject selected_container = null;



    public Button Button_right;
    public Button button_left;
    public Button Button_options;

    public Slider Slider;
    public GameObject GO_Slider;
    public Text textslider;

    public Image element1;
    public Image element2;



    public Image element3;
    public Image element4;
    public Image element5;
    public Image element6;
    public Image element7;

    public Text help_mezclar;
    public Text help_forjar;
    public Text stats;



    public Button Opcion_Fusionar;
    public Button Opcion_Descubir;
    public Button Opcion_Forjar;
    public Button Opcion_Mezclar;
    public Button Opcion_Salir;



    private int index_option = 0;



    public float[] angle_options = null;


    public GameObject[] go_slider_observadores = null;

    public IObservador[] slider_observadores = null;

    private Runa[][] runas;

    private Forja[][] forjas;

    void Awake()
    {
        Go_UIScript._Go_UIScript = this;
        runas = Runa.FactoryList();
        forjas = Forja.FactoryList();
    }

    void Start()
    {
        /*
    m_YourFirstButton.onClick.AddListener(TaskOnClick);
    m_YourSecondButton.onClick.AddListener(delegate { TaskWithParameters("Hello"); });
    m_YourThirdButton.onClick.AddListener(() => ButtonClicked(42));
    m_YourThirdButton.onClick.AddListener(TaskOnClick);
    */

        selected_container = container_options;

        Button_right.onClick.AddListener(() => ButtonClicked(buttons.BUTTON_RIGHT));
        button_left.onClick.AddListener(() => ButtonClicked(buttons.BUTTON_LEFT));
        Button_options.onClick.AddListener(() => ButtonClicked(buttons.BUTTON_OPTIONS));

        Slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        Opcion_Fusionar.onClick.AddListener(() => ShowFusionar());
        Opcion_Descubir.onClick.AddListener(() => ShowDescubir());
        Opcion_Forjar.onClick.AddListener(() => ShowForjar());
        Opcion_Mezclar.onClick.AddListener(() => ShowMezclar());
        Opcion_Salir.onClick.AddListener(() => Salir());

        if (go_slider_observadores != null)
        {
            slider_observadores = new IObservador[go_slider_observadores.Length];
            for (int i = 0; i < go_slider_observadores.Length; i++)
            {

                var sobs = go_slider_observadores[i].GetComponent<IObservador>();
                if (sobs != null)
                {
                    slider_observadores[i] = sobs;
                }

            }
        }
    }

    private void ValueChangeCheck()
    {
        textslider.text = Slider.value.ToString(System.Globalization.CultureInfo.InvariantCulture);

        if (slider_observadores == null)
            return;

        foreach (var obs in slider_observadores)
        {
            if (obs != null)
                obs.Notificar(this.gameObject, Go_UIScript.SLIDER_CAMBIO, textslider.text);
        }
    }

    private void Salir()
    {
        Application.Quit();
    }

    private void show_screen(GameObject toshow, GameObject tohide)
    {



        index_option = 0;

        var angle_option = toshow.transform.eulerAngles;
        angle_option.z = angle_options[index_option];
        toshow.transform.eulerAngles = angle_option;

        tohide.transform.localPosition = hide_position;

        toshow.transform.localPosition = screen_position;

        selected_container = toshow;

        var initable = selected_container.GetComponent<Initiable>();

        if (initable != null)
        {
            initable.Init();
        }

        btn_descubrir.gameObject.SetActive(toshow == container_descubrir);

        Button_options.gameObject.SetActive(tohide == container_options || toshow == container_forjar_nivel);

        var leftrightbutton = toshow == container_options ||
            toshow == container_forjar_nivel ||
            toshow == container_mezclar ||
            toshow == container_descubrir
           ;

        button_left.gameObject.SetActive(leftrightbutton);

        Button_right.gameObject.SetActive(leftrightbutton);

        Slider.value = 0;
        Slider.gameObject.SetActive(tohide == container_options);
        // textslider.gameObject.SetActive(tohide == container_options);
        GO_Slider.gameObject.SetActive(tohide == container_options);

        var showelements = tohide == container_options && toshow != container_forjar ;

        showelements = showelements || toshow == container_forjar_nivel;

        element1.gameObject.SetActive(showelements);
        element2.gameObject.SetActive(showelements);
        element3.gameObject.SetActive(showelements);
        element4.gameObject.SetActive(showelements);
        element5.gameObject.SetActive(showelements);


        element6.gameObject.SetActive(false);
        element7.gameObject.SetActive(false);


       /* help_mezclar.gameObject.SetActive(toshow == container_mezclar);
        help_forjar.gameObject.SetActive(toshow == container_fusionar);
        stats.gameObject.SetActive(toshow == container_forjar_nivel);*/
    }

    private void ShowMezclar()
    {

        show_screen(container_mezclar, container_options);


    }

    private void ShowForjar()
    {
        show_screen(container_forjar, container_options);

        Slider.gameObject.SetActive(false);
        // textslider.gameObject.SetActive(tohide == container_options);
        GO_Slider.gameObject.SetActive(false);


    }

    private void ShowDescubir()
    {
        show_screen(container_descubrir, container_options);
    }

    private void ShowFusionar()
    {
        show_screen(container_fusionar, container_options);
    }

    void OnEnable()
    {

    }

    void Update()
    {

    }



    void ButtonClicked(buttons buttonNo)
    {
        //Output this to console when the Button3 is clicked
        Debug.Log("Button clicked = " + buttonNo);

        switch (buttonNo)
        {
            case buttons.BUTTON_RIGHT:

                index_option = (index_option + 1) % angle_options.Length;
                var angle_option = container_options.transform.eulerAngles;
                angle_option.z = angle_options[index_option];
                selected_container.transform.eulerAngles = angle_option;

                break;
            case buttons.BUTTON_LEFT:

                index_option--;
                if (index_option < 0)
                {
                    index_option = angle_options.Length - 1;
                }

                angle_option = container_options.transform.eulerAngles;
                angle_option.z = angle_options[index_option];
                selected_container.transform.eulerAngles = angle_option;


                break;
            case buttons.BUTTON_OPTIONS:
                show_screen(container_options, selected_container);

                break;
        }
    }

    internal void FusionarPdTRAVCAM()
    {

        if (Slider.value <= 0)
        {

            var mensaje_error = "Selecciona una cantidad correcta para hacer una fusion.";
            alertSctipt.ShowAlert(mensaje_error);
            return;
        }

        var mensaje = string.Format(mensaje_fusionar, Slider.value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        alertSctipt.ShowAlert(mensaje);
    }

    internal void DescubrirElemento(ElementosEnum elementoadescubrir)
    {

        if (Slider.value <= 0)
        {

            var mensaje = string.Format("Selecciona una cantidad correcta para descubrir un elemento.");
            alertSctipt.ShowAlert(mensaje);
            return;
        }

        var runas = this.runas[elementoadescubrir.GetOrdinal()];

        Runa runa = null;
        for (int i = 0; i < Runa.runasporelemento && runa == null; i++)
        {

            if (!runas[i].discovered)
            {
                runa = runas[i];
            }
        }

        if (runa != null)
        {
            runa.discovered = true;

            var mensaje = string.Format(mensaje_descubrir, Slider.value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            alertSctipt.ShowAlert(mensaje);

        }
        else
            alertSctipt.ShowAlert(mensaje_runas_ok);
    }


    internal void MezclarElemento(int runaindex, ElementosEnum el_mezclar)
    {

        if (Slider.value <= 0)
        {

            var mensaje = string.Format("Selecciona una cantidad correcta para hacer la mezcla.");
            alertSctipt.ShowAlert(mensaje);
            return;
        }

        var runas = this.runas[el_mezclar.GetOrdinal()];

        var runa = runas[runaindex];

        if (runa != null)
        {
            runa.discovered = true;

            var mensaje = string.Format(mensaje_mezclar, runa.Name, Slider.value.ToString(System.Globalization.CultureInfo.InvariantCulture));
            alertSctipt.ShowAlert(mensaje);

        }

    }

    internal float SliderValue()
    {

        return Slider.value;

    }

    internal void ForjarElemento(bool result)
    {


        if (Slider.value <= 0)
        {

            var mensajeerror = string.Format("Selecciona una cantidad correcta para hacer la forja.");
            alertSctipt.ShowAlert(mensajeerror);
            return;
        }

       var mensaje = "Forja exitosa.";
        alertSctipt.ShowAlert(mensaje);


    }

    internal void ForjarElemento(int index, ElementosEnum elemento_a_forjar)
    {

        // container_forjar.transform.localPosition = Go_UIScript.hide_position;
        // container_forjar_nivel.transform.localPosition = Go_UIScript.screen_position;



        container_forjar_nivel.GetComponent<Container_forjar_nivelScript>().Forja = forjas[elemento_a_forjar.GetOrdinal()][index];
        container_forjar_nivel.GetComponent<Container_forjar_nivelScript>().Forja.elemento = elemento_a_forjar;
        show_screen(container_forjar_nivel, container_forjar);


        element1.gameObject.SetActive(false);
        element2.gameObject.SetActive(false);
        element3.gameObject.SetActive(false);
        element4.gameObject.SetActive(false);
        element5.gameObject.SetActive(false);
        element6.gameObject.SetActive(true);
        element7.gameObject.SetActive(false);
        switch (elemento_a_forjar)
        {
            case ElementosEnum.elemento_1:
                element1.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_2:
                element2.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_3:
                element3.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_4:
                element4.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_5:
                element5.gameObject.SetActive(true);
                break;

        }


        Slider.value = 0;
        Slider.gameObject.SetActive(true);
        // textslider.gameObject.SetActive(tohide == container_options);
        GO_Slider.gameObject.SetActive(true);
        container_forjar_nivel.GetComponent<Container_forjar_nivelScript>().Init();

    }
    internal Forja[] Forjas(ElementosEnum elemento_a_forjar)
    {
        var forjas = this.forjas[elemento_a_forjar.GetOrdinal()];

        return forjas;
    }

    internal Runa[] Runas(ElementosEnum el_mezclar)
    {

        element1.gameObject.SetActive(false);
        element2.gameObject.SetActive(false);
        element3.gameObject.SetActive(false);
        element4.gameObject.SetActive(false);
        element5.gameObject.SetActive(false);
        element6.gameObject.SetActive(true);
        element7.gameObject.SetActive(true);
        switch (el_mezclar)
        {

            case ElementosEnum.elemento_1:
                element1.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_2:
                element2.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_3:
                element3.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_4:
                element4.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_5:
                element5.gameObject.SetActive(true);
                break;

        }

        var runas = this.runas[el_mezclar.GetOrdinal()];

        return runas;

    }


    internal void UIelemento(ElementosEnum elemento)
    {
        element1.gameObject.SetActive(false);
        element2.gameObject.SetActive(false);
        element3.gameObject.SetActive(false);
        element4.gameObject.SetActive(false);
        element5.gameObject.SetActive(false);
        element6.gameObject.SetActive(true);

        switch (elemento)
        {

            case ElementosEnum.elemento_1:
                element1.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_2:
                element2.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_3:
                element3.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_4:
                element4.gameObject.SetActive(true);
                break;
            case ElementosEnum.elemento_5:
                element5.gameObject.SetActive(true);
                break;

        }
    }
}