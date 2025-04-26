using System;
using NUnit.Framework;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float dir = -1f;
    [SerializeField] float Speed = 2f;
    void Update()
    {
        transform.position += new Vector3(dir * Speed,0,0) * Time.deltaTime;
    }

    public void destroyBullit()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("OBs"))
        {
            destroyBullit();
        }       
    }
}
