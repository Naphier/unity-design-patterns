using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ObservParam
{
    public object data;
    public object key;
}

public class Observer
{
    public static Dictionary<object, Dictionary<Action<ObservParam>, BaseBehaviour>> observList = new Dictionary<object, Dictionary<Action<ObservParam>, BaseBehaviour>>();

    public static void AddListener(object key, BaseBehaviour obj, Action<ObservParam> callback)
    {
        if (!observList.ContainsKey(key))
        {
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = new Dictionary<Action<ObservParam>, BaseBehaviour>();
            actions.Add(callback, obj);
            observList.Add(key, actions);
        }
        else
        {
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = observList[key];
            actions.Add(callback, obj);
        }
    }

    public static void SendMessage(object key)
    {
        if (observList.ContainsKey(key))
        {
            ObservParam observParam = new ObservParam();
            observParam.data = null;
            observParam.key = key;
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = observList[key];

            for (int i = 0; i < actions.Count; i++)
            {
                BaseBehaviour tmpBehavior = actions.Values.ElementAt(i);
                tmpBehavior.OnHandlerMessage(observParam, actions.Keys.ElementAt(i));
            }
        }
    }

    public static void SendMessage(object key, object param)
    {
        if (observList.ContainsKey(key))
        {
            ObservParam observParam = new ObservParam();
            observParam.data = param;
            observParam.key = key;
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = observList[key];

            for (int i = 0; i < actions.Count; i++)
            {
                BaseBehaviour tmpBehavior = actions.Values.ElementAt(i);
                tmpBehavior.OnHandlerMessage(observParam, actions.Keys.ElementAt(i));
            }
        }
    }

    public static void RemoveListener(object key, BaseBehaviour obj, Action<ObservParam> callback)
    {
        if (observList.ContainsKey(key))
        {
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = observList[key];
            for (int i = 0; i < actions.Count; i++)
            {
                if (actions.Keys.ElementAt(i) == callback && actions.Values.ElementAt(i) == obj)
                {
                    actions.Remove(callback);
                }
            }
        }
    }

    public static void RemoveAllListeners(BaseBehaviour obj)
    {
        foreach (KeyValuePair<object, Dictionary<Action<ObservParam>, BaseBehaviour>> item in observList)
        {
            Dictionary<Action<ObservParam>, BaseBehaviour> actions = item.Value;
            if (actions.ContainsValue(obj))
            {
                for (int i = 0; i < actions.Count; i++)
                {
                    if (actions.Values.ElementAt(i) == obj)
                    {
                        actions.Remove(actions.Keys.ElementAt(i));
                    }
                }
            }
        }
    }
}