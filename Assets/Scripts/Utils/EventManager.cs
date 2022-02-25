using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class CustomEvent : UnityEvent<EventData> {}
public class EventData{}

public class EventDataInt : EventData
{
    public int value;
}

public class EventDataStr : EventData
{
    public string value;
}

public class EventManager : Singleton<EventManager> {

    private Dictionary <string, CustomEvent> eventDictionary = new Dictionary<string, CustomEvent>();

    public void StartListening (string eventName, UnityAction<EventData> listener)
    {
        CustomEvent thisEvent = null;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.AddListener (listener);
        } 
        else
        {
            thisEvent = new CustomEvent();
            thisEvent.AddListener (listener);
            eventDictionary.Add (eventName, thisEvent);
        }
    }

    public void StopListening (string eventName, UnityAction<EventData> listener)
    {
        CustomEvent thisEvent = null;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            thisEvent.RemoveListener (listener);
        }
    }

    public void TriggerEvent (string eventName, EventData data)
    {
        CustomEvent thisEvent = null;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            InvokeEvent(eventName, data);
        }
    }

    public void TriggerEvent (string eventName)
    {
        CustomEvent thisEvent = null;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            InvokeEvent(eventName, null);
        }
    }

    public void TriggerEvent (string eventName, string val)
    {
        CustomEvent thisEvent = null;
        EventDataStr data = new EventDataStr();
        data.value = val;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            InvokeEvent(eventName, data);
        }
    }

    public void TriggerEvent (string eventName, int val)
    {
        CustomEvent thisEvent = null;
        EventDataInt data = new EventDataInt();
        data.value = val;
        if (eventDictionary.TryGetValue (eventName, out thisEvent))
        {
            InvokeEvent(eventName, data);
        }
    }

    public void InvokeEvent(string eventName, EventData data)
    {
        CustomEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(data);
        }
    }
}