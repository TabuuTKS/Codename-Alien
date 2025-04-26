using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.localScale = new Vector3(transform.localScale.x,transform.localScale.y,transform.localScale.z * (-1));
            collision.gameObject.GetComponent<Player>().GravitySwitching();
        }
    }
}
