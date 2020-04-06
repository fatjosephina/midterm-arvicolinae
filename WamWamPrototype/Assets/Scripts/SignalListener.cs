using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignalListener : MonoBehaviour
{
    public Signal healthSignal;
    public UnityEvent healthSignalEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
