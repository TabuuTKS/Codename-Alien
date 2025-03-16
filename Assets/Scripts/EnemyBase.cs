using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBase : MonoBehaviour
{
    public int Damage = 2;
    public bool isStaticTrap;
    Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //direction of our collison
            Vector2 collisionDirection = (collision.transform.position - transform.position).normalized;
            //detects if y position  of collison is greater than x.
            //if y position is +ve then the player jumped on top of enemy else player got hit from bottom
            if ((Mathf.Abs(collisionDirection.y) > Mathf.Abs(collisionDirection.x)) 
                && collisionDirection.y > 0 && !isStaticTrap)
            {
                player.HitEnemyUsingJump();
                Destroy(this.gameObject);
            }
            else
            {
                player.Hurt(Damage);
            }
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        
    }
}
