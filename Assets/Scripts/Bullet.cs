using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public  Rigidbody2D rb;

    public float speed;
    void OnTriggerEnter2D(Collider2D hitinfo)
    {
       if (hitinfo.tag == "walls") //eğer mermi duavar çarparsa mermi yok olur
       {
        Destroy(gameObject);
       }
        
        if (hitinfo.tag=="enemy") //eğer mermi düşmana çarparsa yok olur
        {
            Destroy(hitinfo.gameObject);
        }

        if (hitinfo.tag=="Player") //eğer mermi oyuncuya çarparsa yok olur
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


        rb.velocity = transform.right * speed; // mermiye yön ve ivme verir
    }
}
