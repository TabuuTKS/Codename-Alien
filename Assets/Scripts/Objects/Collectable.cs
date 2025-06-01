using UnityEngine;

public class Collectable : MonoBehaviour
{
    enum CollectableType {
        COIN,
        KEY
    }

    [SerializeField] CollectableType Type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().coin.Play();
            switch(Type) {
                case CollectableType.COIN:
                    PlayerPrefs.AddCoin();
                    break;
                case CollectableType.KEY:
                    PlayerPrefs.AddKey();
                    break;
            }
            Destroy(this.gameObject);
        }
        
    }
}
