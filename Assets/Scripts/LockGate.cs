using UnityEngine;

public class LockGate : MonoBehaviour
{
    [SerializeField] Dailogue NoKeyDailogue;
    [SerializeField] DailogueManager dailogueManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (PlayerPrefs.keys > 0)
            {
                PlayerPrefs.SubtractKey();
                Destroy(gameObject);
            }
            else {
                dailogueManager.StartDailogue(NoKeyDailogue);
            }
        }   
    }
}
