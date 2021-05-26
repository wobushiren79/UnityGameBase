using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : BaseMonoBehaviour, ISheet1View
{

    public TestScriptableObject testScriptable;

    public void GetSheet1Fail(string failMsg, Action action)
    {
    }

    public void GetSheet1Success<T>(T data, Action<T> action)
    {
        action?.Invoke(data);
    }

    private void OnGUI()
    {

        if (GUILayout.Button("输出"))
        {
            LogUtil.Log("testScriptable:" + testScriptable.data);
        }
    }

    private void Start()
    {
        Sheet1Controller sheet1Controller = new Sheet1Controller(this, this);
        sheet1Controller.GetAllSheet1Data((listData) =>
        {
            for (int i = 0; i < listData.Count; i++)
            {
                LogUtil.Log("listData:" + listData[i].id + " " + listData[i].name);
            }
        });
    }

    public class TestData
    {

        public string data1;
        public int data2;
    }
}
