using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update



    public Transform firePoint;
    public GameObject bulletPrefab;

    public Player playerHealth;

    public float bulletForce = 20f;

    public bool ishooting=false;
    void Start()
    {
       
    }

    // Update is called once per frame
    
    
    void Update()
    {
       playerHealth.playerammotext.text="Mermi : " + playerHealth.playerammo.ToString();
    }


   public void Shoot() //ateş etmek için
    {
        
        if ( playerHealth.playerammo > 0)
        {
            ishooting=true;

           GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
           Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

           rb.AddForce(firePoint.right * bulletForce , ForceMode2D.Impulse); 

           
        }
        
        
            if (ishooting && playerHealth.playerammo > 0 )
        {
            playerHealth.playerammo = playerHealth.playerammo -1;
        }
        
    }
}
