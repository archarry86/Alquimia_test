#if unity_editor
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
using UnityEngine.UI;
using System.Text;

[ExecuteInEditMode]
public class HelperClassCreator : MonoBehaviour
{


    public GameObject target = null;

    void Start()
    {
        this.enabled = false;
    }

    void OnEnable()
    {
        try
        {
            OnEnableHelper();
        }
        catch (System.Exception ex)
        {
        }



        this.enabled = false;

    }


    protected void OnEnableHelper()
    {

        try
        {
            string folder = @"D:\TRABAJO\BoneGaming\Alquimia\Assets\Scripts";

            int count = target.transform.childCount;

            StringBuilder buider = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                var _gobject = this.target.transform.GetChild(i);
                buider.AppendLine(" public GameObject " + _gobject.gameObject.name + ";");
            }


            var classnamestring = capitlicefirstchar(target.name);

            var ClassNameFile = classnamestring + "Script.cs";


            var tempalteclass = @"
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class " + classnamestring + @"Script : MonoBehaviour
{

        ";




            var methods = @"
    void Awake()
    {
      
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

}    
";

            System.IO.File.WriteAllText(folder + @"\" + ClassNameFile, tempalteclass + buider + methods);



        }
        catch (System.Exception ex)
        {
            EditorUtility.DisplayDialog("Error", ex.Message + " " + ex.GetType().FullName + System.Environment.NewLine + " " + ex.StackTrace, "OK");

            return;
        }

    }


    private string capitlicefirstchar(string str) {
        if (string.IsNullOrEmpty(str)) {
            return string.Empty;
        }

        if (str.Length == 1)
            str = ""+char.ToUpper(str[0]);
        else if (str.Length > 1)
            str = "" + char.ToUpper(str[0]) + str.Substring(1);

        return str;
    }



}
#endif