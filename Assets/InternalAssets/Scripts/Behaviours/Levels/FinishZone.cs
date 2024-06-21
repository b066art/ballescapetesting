using System;
using UnityEngine;
using UnityEngine.Events;

public class FinishZone : MonoBehaviour
{   
    [SerializeField] string tagFilter;
    [SerializeField] UnityEvent onTriggerEnter;

    private bool isFinished = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!String.IsNullOrEmpty(tagFilter) && !other.gameObject.CompareTag(tagFilter)) return;
        if (!isFinished)
        {
            isFinished = true;
            onTriggerEnter.Invoke();
        }
    }
}
