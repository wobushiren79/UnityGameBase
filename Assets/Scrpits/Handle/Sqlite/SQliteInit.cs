using UnityEngine;
using UnityEditor;
using System.IO;

public class SQliteInit : BaseMonoBehaviour
{
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            //将第三方数据库拷贝至Android可找到的地方
            string appDBPath = Application.persistentDataPath + "/" + ProjectConfigInfo.DATA_BASE_INFO_NAME;
            //如果已知路径没有地方放数据库，那么我们从Unity中拷贝
            if (File.Exists(appDBPath))
            {
                File.Delete(appDBPath);
            }
            //用www先从Unity中下载到数据库
#pragma warning disable CS0618 // 类型或成员已过时
            WWW loadDB = new WWW("jar:file://" + Application.dataPath + "!/assets/SQLiteDataBase/" + ProjectConfigInfo.DATA_BASE_INFO_NAME);
#pragma warning restore CS0618 // 类型或成员已过时
            while (!loadDB.isDone) { }
            //拷贝至规定的地方
            File.WriteAllBytes(appDBPath, loadDB.bytes);
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            string appDBPath = Application.persistentDataPath + "/" + ProjectConfigInfo.DATA_BASE_INFO_NAME;
            if (File.Exists(appDBPath))
            {
                File.Delete(appDBPath);
            }
#pragma warning disable CS0618 // 类型或成员已过时
            WWW loadDB = new WWW("file://" + Application.streamingAssetsPath + "/SQLiteDataBase/" + ProjectConfigInfo.DATA_BASE_INFO_NAME);
#pragma warning restore CS0618 // 类型或成员已过时
            while (!loadDB.isDone) { }
            File.WriteAllBytes("file://" + appDBPath, loadDB.bytes);
        }
    }
}