using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        down.hit2.Play();
        if (collision.gameObject.CompareTag("vase"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.CompareTag("enemy"))
        {
            JoysticController.hp--;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            
        }
        
    }
}
