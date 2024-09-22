using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;

    private void OnTriggerEnter(Collider other)
    {
        OnEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit.Invoke();
    }
}