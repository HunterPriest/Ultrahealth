using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public Action OnEnter;
    public Action OnExit;

    private void OnTriggerEnter(Collider other)
    {
        print("asdasd");
        OnEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit.Invoke();
    }
}