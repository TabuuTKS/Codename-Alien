using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().coin.Play();
            GameObject.FindGameObjectWithTag("Event").GetComponent<LevelEvents>().coins+=5;
            Destroy(this.gameObject);
        }
        
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
