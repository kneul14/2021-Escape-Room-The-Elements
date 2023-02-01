using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_clickable_object : MonoBehaviour
{
    //stores if a object is being touched
    public bool is_being_touched_and_clicked=false;
    //this will save the canvas to be show
    public GameObject canvas_to_be_showned;
    //this will make the canvas be open until esc
    public bool stay_open_until_esc_button;
    //this will store fps controller
    public GameObject fps_controller;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this will call the funtion to cancel the canvas
       cancel_canvas();
        //if is being touched is true show the canvas if its not dont show
       if(is_being_touched_and_clicked==true)
       {
            canvas_to_be_showned.gameObject.active = true;
           
       }
       if (is_being_touched_and_clicked == false)
       {
            canvas_to_be_showned.gameObject.active = false;
            

        }
    }

    void cancel_canvas()
    {
        //this will check if the canvas is open 
        if(stay_open_until_esc_button==false)
        {
            if (Input.GetMouseButton(0))
            {
            }
            else
            {   
                //if no one touched the mouse say that the object is not clicked
                
                is_being_touched_and_clicked = false;
            }
        }
        else
        {
            //if its being clicked disable the fps controller and enable the mouse
            if(is_being_touched_and_clicked == true)
            {
            
                fps_controller.gameObject.GetComponent<MonoBehaviour>().enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
            //if someone clicked esc enable fps, and lock cursor
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                
              
                fps_controller.gameObject.GetComponent<MonoBehaviour>().enabled = true;
                is_being_touched_and_clicked = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        
        
        
    }
}
