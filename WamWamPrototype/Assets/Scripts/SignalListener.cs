using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal healthSignal;
    public UnityEvent healthSignalEvent;

    public void OnSignalRaised()
    {
        healthSignalEvent.Invoke();
    }

    private void OnEnable()
    {
        healthSignal.RegisterListener(this);
    }

    private void OnDisable()
    {
        healthSignal.DeregisterListener(this);
    }
}
