using UnityEngine;
using UnityEditor;
using ExtencionsEnum;
public class Forja
{

    public const int Forja_por_elemento = 4;
    public string Name;

    public float Dannio;
    public float Curacion;
    public float Efecto;

    public ElementosEnum elemento;

    public static Forja[][] FactoryList() {



        Forja[][] forja = new Forja[ElementosEnum.elemento_1.CountElements()][];
        int index = 0;
        foreach(var runaarray in forja) {

            forja[index]= new Forja[Forja_por_elemento];

            for (int i = 0; i < Forja_por_elemento; i++) {
                forja[index][i] = new Forja()
                {
                    Name = ("Forja [" + i + "]"),
                    Dannio = 0,
                    Curacion = 0,
                    Efecto = 0
                };
            }


            index++; 
        }


        return forja;

    }
}