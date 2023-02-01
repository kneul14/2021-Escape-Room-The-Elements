using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleRemoteScript : MonoBehaviour
{

  
    //this variable is changed by the HoverObject script
    public bool is_it_clicked = false;
    //this will store th fps controller
    public GameObject fpscontroller;
    //this will store the object that is going to be dropped
    public GameObject ObjectDropped;
    //this will store the fire
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the object was clicked
        if (is_it_clicked == true)
        {
            // this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
            //this will disable the fire collider
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            //this will make the remote a child of the fps controller
            this.transform.SetParent(fpscontroller.transform);
            //this will change the remote localposition o be on front of the camera
            this.transform.localPosition = new Vector3(-0.0979991f, -0.216f, 0.59f);
            //this will change its rotation
            this.transform.localRotation = Quaternion.Euler(216.39f, 0, 0);
            //if the user clicks on the button E
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                //make the object drop
                ObjectDropped.gameObject.GetComponent<MeshCollider>().enabled = true;
                ObjectDropped.gameObject.GetComponent<Rigidbody>().useGravity = true;
                Destroy(this.gameObject);
            }

        }
    }

   
}
