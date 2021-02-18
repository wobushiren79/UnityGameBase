﻿using UnityEngine;
using UnityEditor;

public class GameCommonInfo
{
    //游戏用户ID
    public static string GameUserId;
    //游戏设置
    public static GameConfigBean GameConfig;
    //随机种子
    public static int RandomSeed = 1564;

    // 预加载场景名字
    public static ScenesChangeBean ScenesChangeData = new ScenesChangeBean();

    private static GameConfigController mGameConfigController;


    public static void ClearData()
    {
        GameUserId = null;
        ScenesChangeData = new ScenesChangeBean();
    }

    static GameCommonInfo()
    {
        GameConfig = new GameConfigBean();
        mGameConfigController = new GameConfigController(null, new GameConfigCallBack());
        mGameConfigController.GetGameConfigData();
    }

    /// <summary>
    /// 随机化种子
    /// </summary>
    public static void InitRandomSeed()
    {
        Random.InitState(RandomSeed);
    }

    public static void SaveGameConfig()
    {
        mGameConfigController.SaveGameConfigData(GameConfig);
    }

    public class GameConfigCallBack : IGameConfigView
    {
        public void GetGameConfigFail()
        {

        }

        public void GetGameConfigSuccess(GameConfigBean configBean)
        {
            GameConfig = configBean;
        }

        public void SetGameConfigFail()
        {

        }

        public void SetGameConfigSuccess(GameConfigBean configBean)
        {

        }
    }

}