using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
     Vector2 Direction;
    
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public Transform Shootpoint;
    
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
       
        
            
            if(Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;  //zamanalyıcıyla düşman ateş ettirmek için
                
                shoot();

            }
            
        

        
    }

    public void shoot()
    {
        
        GameObject BulletIns = Instantiate(bullet, Shootpoint.position, Shootpoint.rotation);  //düşmanı atteş ettirmek için
        
        
    }

    void OnCollisionEnter2D(Collision2D hitinfo)
    {

        if (hitinfo.gameObject.tag == "bullet")   //eğer mermi düşmana çarparsa düşman yok olur
        {
            

            Destroy(this.gameObject);
        }

    }

}
