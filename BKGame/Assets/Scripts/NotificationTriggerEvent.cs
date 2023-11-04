using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationTriggerEvent : MonoBehaviour
{
    [Header("UI Content")]
    [SerializeField] private Text notificationTextUI;

    [Header("MessageCustomization")]
    [SerializeField] [TextArea] private string notificationMessage;

    [Header("Notification Removal")]
    [SerializeField] private bool removeAfterExit = false;
    [SerializeField] private bool disableAfterTimer = false;
    [SerializeField] float disableTimer = 1.0f;

    [Header("Notification Animation")]
    [SerializeField] private Animator notificationAnim;
    private BoxCollider objectCollider;

    private void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(EnableNotification());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && removeAfterExit)
        {
            RemoveNotification();
        }
    }

    IEnumerator EnableNotification()
    {
        notificationTextUI.text = notificationMessage;

        if (disableAfterTimer)
        {
            notificationAnim.Play("NotificationPopUp");
            Debug.Log("Start disable timer");
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void StartDisableTimer()
    {
        StartCoroutine(DisableNotificationAfterTimer());
    }

    IEnumerator DisableNotificationAfterTimer()
    {
        yield return new WaitForSeconds(disableTimer);
        Debug.Log("Pop Up will now disappear");
        RemoveNotification();
    }

    void RemoveNotification()
    {
        notificationAnim.Play("NotificationPopOut");
        gameObject.SetActive(false);
    }
}
