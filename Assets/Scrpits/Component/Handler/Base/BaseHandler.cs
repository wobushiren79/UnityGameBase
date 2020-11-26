using UnityEngine;
using UnityEditor;

public class BaseHandler<T> : BaseObservable<IBaseObserver> where T : BaseManager
{
    protected T manager;

    protected virtual void Awake()
    {
        manager = CptUtil.AddCpt<T>(gameObject);
        AutoLinkHandler();
    }
    /// <summary>
    /// 通过反射链接UI控件
    /// </summary>
    public void AutoLinkHandler()
    {
        ReflexUtil.AutoLinkData(this, "handler_");
    }

}