using UnityEngine;
using UnityEditor;

using UnityEngine;
using System.Collections;

namespace ExtencionsEnum
{

    public static class ExtencionsEnum
    {

        public static int GetOrdinal(this System.Enum _enum)
        {


            return System.Convert.ToInt32(_enum);
        }


        public static int CountElements(this System.Enum _enum)
        {


            return System.Enum.GetNames(_enum.GetType()).Length;
        }

        public static T[] CreateArray<T>(this System.Enum _enum)
        {

            T[] val = new T[System.Enum.GetNames(_enum.GetType()).Length];

            return val;
        }

        public static string[] GetNames(this System.Enum _enum)
        {

            return System.Enum.GetNames(_enum.GetType());


        }



        public static Color ColorDeElemento(this ElementosEnum _enum)
        {

            Color color = Color.white;
            switch (_enum)
            {

                case ElementosEnum.elemento_1:
                    color = Color.red;
                    break;
                case ElementosEnum.elemento_2:
                    color = Color.blue;
                    break;
                case ElementosEnum.elemento_3:
                    color = Color.green;
                    break;
                case ElementosEnum.elemento_4:
                    color = Color.yellow;
                    break;
                case ElementosEnum.elemento_5:
                    color = new Color(1, 0.27f, 0);
                    break;

            }


            return color;
        }
    }

}