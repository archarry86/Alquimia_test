using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Element : MonoBehaviour, IObservador
{
    private static int Initial_elements = 0;
    public Text text = null;

    public void Notificar(GameObject ob, string Mensaje, object valor)
    {
       if(text != null) {

            text.text = valor.ToString();// ((float)valor).ToString(System.Globalization.CultureInfo.InvariantCulture);
        }
    }

    void Awake() {

       
    }


    // Start is called before the first frame update
    void Start()
    {

     //   text = this.transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
