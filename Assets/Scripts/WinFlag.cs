using UnityEngine;

public class WinFlag : MonoBehaviour
{
    LevelEvents events;
    private void Awake()
    {
        events = GameObject.FindGameObjectWithTag("Event").GetComponent<LevelEvents>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            events.Win();
        }
    }
}
