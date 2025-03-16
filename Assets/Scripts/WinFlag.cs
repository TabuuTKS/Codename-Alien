using UnityEngine;

public class WinFlag : MonoBehaviour
{
    LevelEvents events;
    Player player;
    private void Awake()
    {
        events = GameObject.FindGameObjectWithTag("Event").GetComponent<LevelEvents>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.DisableMovements();
            events.win = true;
        }
    }
}
