using UnityEditor;
using UnityEngine;

public class BaseUIItem<T> : BaseMonoBehaviour where T : BaseUIComponent
{
    public T uiComponent;
}