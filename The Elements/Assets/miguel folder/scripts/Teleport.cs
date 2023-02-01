using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    //this will store the player
    public GameObject fpscontroller;
    //this will store the teleport
    public GameObject teleport;
    //if this is true the teleport will destroy itself after used
    public bool DestroyAfterUse = false;
    //if this is true the teleport will teleport to other scene
    public bool TeleportToScene = false;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //check if this collider is touching something
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == fpscontroller.gameObject && TeleportToScene==false)
        {
            //Make the fps deactive, to fix a bug of moving the fps
            fpscontroller.gameObject.SetActive(false);
            //Make the fps go to the teleport position
            fpscontroller.transform.position = teleport.transform.position;
            //Make the fps deactive, to fix a bug of moving the fps
            fpscontroller.gameObject.SetActive(true);
            //if this is true the teleport will destroy itself after used
            if (DestroyAfterUse==true)
            {
                Destroy(this.gameObject);
            }
        }
        //if its time to teleporty to other scene
        else if(other.gameObject == fpscontroller.gameObject && TeleportToScene == true)
        {
            //go to lucas scene
            SceneManager.LoadScene("Lucas_Scene");
        }
    }
}
