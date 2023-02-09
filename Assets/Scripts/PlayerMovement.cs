using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
    private float angle;
    
    Vector2 movement;
    Vector2 mousePosition;
    Vector2 lookDirection;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float rotationspeed;

    [SerializeField] private Transform Guntransform;
    [SerializeField] private Camera cam;

    private Vector2 movementdirection;
    
    public Animator animatorrt;

    public Animator animatorlt;

    public SimpleTouchController leftcontroller;

    public SimpleTouchController rightcontroller;

    
    
    void Update()
    {
        

        movement.x= leftcontroller.GetTouchPosition.x;  //ekrandaki joystiğe göre tankı haraket ettirir

        movement.y = leftcontroller.GetTouchPosition.y;

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        

        movementdirection = new Vector2 (movement.x,movement.y);
        movementdirection.Normalize();

        if (movement.x !=0 ||movement.y !=0)
        {
        
         animatorrt.SetBool("ismoving",true);  //palet animasyonunu çalıştırır

         animatorlt.SetBool("ismoving",true); 
        }
        else
        {
           animatorlt.SetBool("ismoving",false); 
           animatorrt.SetBool("ismoving",false); 
        }
        
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed* Time.fixedDeltaTime); //tankı hareket etttirmek için
        
        

        angle = Mathf.Atan2(rightcontroller.GetTouchPosition.y, rightcontroller.GetTouchPosition.x) * Mathf.Rad2Deg;
    
        Guntransform.rotation =Quaternion.Euler(0,0,angle-90); //silahı hareket ettirmek için
        
        Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementdirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed*Time.deltaTime);
    }
}
