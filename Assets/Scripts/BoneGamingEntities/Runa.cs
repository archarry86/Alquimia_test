using UnityEngine;
using UnityEditor;
using ExtencionsEnum;
public class Runa 
{

    public const int runasporelemento = 4;
    public string Name;

    public bool discovered = false;

    public ElementosEnum elemento;

    public static Runa[][] FactoryList() {

    

        Runa[][] runas = new Runa[ElementosEnum.elemento_1.CountElements()][];
        int index = 0;
        foreach(var runaarray in runas) {

            runas[index]= new Runa[runasporelemento];

            for (int i = 0; i < runasporelemento; i++) {
                runas[index][i] = new Runa()
                {
                    Name = ("Runa  [" + i + "]"),
                    discovered = false
                };

            }


            index++; 
        }


        return runas;

    }
}