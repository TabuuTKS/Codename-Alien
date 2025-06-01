using System;
using UnityEngine;

public class SignBoard : MonoBehaviour
{
    [SerializeField] DailogueManager dailogueManager;
    [SerializeField] Dailogue dailogue;
    private bool isRead = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isRead)
        {
            dailogueManager.StartDailogue(dailogue);
            isRead = true;
        }
    }
}
