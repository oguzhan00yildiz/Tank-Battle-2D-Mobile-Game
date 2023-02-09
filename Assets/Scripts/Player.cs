using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int playerammo;

    public int playerhealth;

    public Text playerammotext;

    public Text playerhealthtext;

    public GameObject panel;
    public GameObject panelendgame;

    public GameObject UIpanel;

    public GameObject MainMenuPanel;

    public Shooting Pshoot;

    int levelcount=0;

    void OnTriggerEnter2D(Collider2D hitinfo)
    {

        if (hitinfo.gameObject.tag == "bullet") // eğer mermi oyuncuya çarparsa oyuncunun canı azalır
        {
            

             
            
            
                if (playerhealth > 0)
                {
               playerhealth = playerhealth -1;

            }
            
           
            
           
        }

        if (hitinfo.gameObject.tag == "ammobox") //eğer oyuncu mermi kutusu alırsa  + 5 mermi eklenir
        {
            playerammo = playerammo+5;

            Destroy(hitinfo.gameObject);
        }

        if (hitinfo.gameObject.tag == "sign1" ) //oyun sonu için diğer levela geçmek için 
        {
            
           SceneManager.LoadScene("Level1"); 
           
        }

        if (hitinfo.gameObject.tag == "sign2" )
        {
           
           SceneManager.LoadScene("Level2");
            
        }
    }

    

   public void restartgame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // oyunu yeniden başlatmak için
    }

    public void startthegame()  //oyunu başlatır
    {
        SceneManager.LoadScene(0);

        MainMenuPanel.SetActive(false);

    }

    public void quitthegame()  //oyunu kapatır
    {

        Application.Quit();
    }


    void Start()
    {

        
        

    }

    void Update()
    {

         if (playerhealth == 0)         //eğer can 0 düşerse ölme paneli açılıyor.
            {
                panel.SetActive(true);
                UIpanel.SetActive(false);
            }  
        playerhealthtext.text = "CAN : " + playerhealth.ToString();

        playerammotext.text="Mermi : " + playerammo.ToString();

        

         levelcount=SceneManager.GetActiveScene().buildIndex;
        
    }

    
}
