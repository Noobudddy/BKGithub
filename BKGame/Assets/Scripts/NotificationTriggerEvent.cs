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

    [Header("Notification Animation")]
    [SerializeField] private Animator notificationAnim;
    private bool notificationAnimationPlayed = false;
    private BoxCollider objectCollider;

    private void Awake()
    {
        objectCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (notificationAnimationPlayed)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                RemoveNotification();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            notificationAnimationPlayed = true;
            EnableNotification();
        }
    }

    public void EnableNotification()
    {
        notificationAnim.Play("NotificationPopUp");
        notificationTextUI.text = notificationMessage;
    }

    void RemoveNotification()
    {
        notificationAnim.Play("NotificationPopOut");
        gameObject.SetActive(false);
    }
}
