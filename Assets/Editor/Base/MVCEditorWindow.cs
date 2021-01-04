using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MVCEditorWindow : EditorWindow
{
    public string mvcClassName = "";

    protected readonly string scrpitsTemplatesPath = "/Editor/ScrpitsTemplates/";
    protected readonly string mvcViewPath = "Assets/Editor";

    [MenuItem("MVC/创建")]
    static void CreateWindows()
    {
        EditorWindow.GetWindow(typeof(MVCEditorWindow));
    }


    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorUI.GUIText("创建MVC,输入MVC名称");
        mvcClassName = EditorUI.GUIEditorText(mvcClassName, 100);
        if (EditorUI.GUIButton("创建"))
        {
            CreateMVCClass(mvcClassName);
        }
        EditorGUILayout.EndVertical();
    }

    public void CreateMVCClass(string fileName)
    {
        //注意，Application.datapath会根据使用平台不同而不同  
        string viewPath = Application.dataPath + scrpitsTemplatesPath + "MVC_IView.txt";
        string viewScriptContent = File.ReadAllText(viewPath);

        viewScriptContent = ReplaceRole(viewScriptContent, fileName);

        FileUtil.CreateTextFile(mvcViewPath, fileName + ".cs", viewScriptContent);
        AssetDatabase.Refresh();
    }

    private string ReplaceRole(string scripteContent, string fileName)
    {
        //这里实现自定义的一些规则  
        scripteContent = scripteContent.Replace("#SCRIPTNAME#", fileName);
        scripteContent = scripteContent.Replace("#Author#", "AppleCoffee");
        scripteContent = scripteContent.Replace("#CreateTime#", System.DateTime.Now.ToString("yyyy-MM-dd-HH:mm:ss"));
        return scripteContent;
    }
}
