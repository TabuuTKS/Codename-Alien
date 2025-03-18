using UnityEngine;

public class DeathGround : MonoBehaviour
{
    [SerializeField] LevelEvents events;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            events.GameOver();
        }
    }
}
