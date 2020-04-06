using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Health Signal")]
public class Signal : ScriptableObject
{
    public List<SignalListener> signalListeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = signalListeners.Count - 1; i >= 0; i--)
        {
            signalListeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        signalListeners.Add(listener);
    }

    public void DeregisterListener(SignalListener listener)
    {
        signalListeners.Remove(listener);
    }
}
