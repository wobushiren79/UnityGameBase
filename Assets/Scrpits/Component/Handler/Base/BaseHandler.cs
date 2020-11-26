using UnityEngine;
using UnityEditor;

public class BaseHandler<T> : BaseObservable<IBaseObserver> where T : BaseManager
{
    protected T manager;

    protected virtual void Awake()
    {
        manager = CptUtil.AddCpt<T>(gameObject);
        AutoLinkHandler();
        AutoLinkManager();
    }

    /// <summary>
    /// 通过反射链接数据
    /// </summary>
    public void AutoLinkHandler()
    {
        ReflexUtil.AutoLinkData(this, "handler_");
    }

    /// <summary>
    /// 通过反射链接数据
    /// </summary>
    public void AutoLinkManager()
    {
        ReflexUtil.AutoLinkData(this, "manager_");
    }
}