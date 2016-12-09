using System;
using System.Collections.Generic;
using System.Linq;

namespace NG.Patterns.Structure.ObserverPattern
{
    public class ObservParam
    {
        public object data;
        public object key;
    }

    public class Observer : Singleton<Observer>
    {
        public Dictionary<object, Dictionary<Action<ObservParam>, BaseBehaviour>> observList = new Dictionary<object, Dictionary<Action<ObservParam>, BaseBehaviour>>();

        public void AddListener(object key, BaseBehaviour obj, Action<ObservParam> callback)
        {
            if (!observList.ContainsKey(key))
            {
                Dictionary<Action<ObservParam>, BaseBehaviour> actions = new Dictionary<Action<ObservParam>, BaseBehaviour>();
                actions.Add(callback, obj);
                observList.Add(key, actions);
            }
            else
            {
                observList[key].Add(callback, obj);
            }
        }

        public void SendMessage(object key)
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

        public void SendMessage(object key, object param)
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

        public void RemoveListener(object key, BaseBehaviour obj, Action<ObservParam> callback)
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

        public void RemoveAllListeners(BaseBehaviour obj)
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
}

