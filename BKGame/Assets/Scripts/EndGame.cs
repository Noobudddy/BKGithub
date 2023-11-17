using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    public void Endgame()
    {
        Application.Quit();
    }
}
