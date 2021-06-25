using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Test : BaseMonoBehaviour
{

    public AssetReference assetReference;

    private void OnGUI()
    {
        if (GUILayout.Button("输出"))
        {
        }
    }

    private void Start()
    {
        //单纯加载
        Addressables.LoadAssetAsync < GameObject >("Add").Completed+=data=> { LogUtil.Log("成功"); };
        //实例化
        //assetReference.InstantiateAsync().Completed += data => { LogUtil.Log("成功"); };
    }


}
