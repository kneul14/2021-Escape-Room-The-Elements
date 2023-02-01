using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakWallPuzzleController : MonoBehaviour
{
    
    //this will store the bucket, hammer, brush
    public GameObject Bucket, hammer, brush,brushdipped, fpscontroller, paintingCanvas,Safe;
   
    //this will store the progression, if its one the brush has already been dipped on the bucket
    int progression;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        //this will check if the hammer has already opened the bucket
        if (hammer.GetComponent<HammerController>().has_opened_bucket == true)
        {
            //make hammer not grabbable again
            hammer.transform.tag = "Untagged";
            //make object be dropped
            hammer.GetComponent<GrabObject>().dropObject();
            //make brush grabbable 
            brush.transform.tag = "clickable object";
            //dipping pencil functionality
            check_brush();       
        }
        if(progression==1)
        {
            //call the fucntion that will tell the code to the player
            paint_canvas();
        }
    }

    //this will check if the brush has already been dipped on the bucket
    void check_brush()
    {
       
        //if the player is holding the brush and bucket is being touched
        if (fpscontroller.gameObject.transform.Find(brush.gameObject.name) && Bucket.GetComponent<Click_clickable_object>().is_being_touched_and_clicked==true && progression <1)
        {
            //this will be one to tell the code that the brush has been dipped.
            progression = 1;
            /*for me to make the brush be blue, with paint, i spent 1 hour trying to do the correct thing, only change the material, but it has some kind of bug, so i
            have another brush already blue, and what i do is unparent it disable the old brush and activate the new brush
             */
            brushdipped.transform.parent = null;
            
            brushdipped.transform.parent = fpscontroller.transform;
            brushdipped.transform.position = brush.transform.position;
            brushdipped.transform.rotation = brush.transform.rotation;
            
            brush.gameObject.SetActive(false);
            brushdipped.gameObject.GetComponent<MeshRenderer>().enabled=true;
            brushdipped.gameObject.GetComponent<BoxCollider>().enabled = true;
            
            
        }
    }

    //this will paint the canvas
    void paint_canvas()
    {
        //this will remove the brush collider when the fps controller is holding it, i do this so that the raycast continues to work even with the brush on the hand
        if (fpscontroller.gameObject.transform.Find(brushdipped.gameObject.name)==true)
        {
            brushdipped.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        //this will enable the box collider of the brush, when the fps controller no longer has the brush on the hand, i do this so that the user can reuse the brush even when he drops it
        else
        {
            brushdipped.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        //if the player is holding the brush and painting canvas is being touched
        if (fpscontroller.gameObject.transform.Find(brushdipped.gameObject.name) && paintingCanvas.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && progression == 1)
        {
            //set the painting code enabled
            paintingCanvas.transform.GetChild(0).gameObject.SetActive(true);
            //drop the brushes even the invisible one
            brushdipped.gameObject.GetComponent<GrabObject>().dropObject();
            brushdipped.transform.tag="Untagged";
            brush.gameObject.GetComponent<GrabObject>().dropObject();
            //make safe clickable
            Safe.transform.tag = "clickable object";
            

        }   
    }
}
