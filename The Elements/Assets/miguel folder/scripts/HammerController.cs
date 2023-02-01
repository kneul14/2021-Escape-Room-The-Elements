using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    //this will store the bucket gameobject
    public GameObject bucket;
    //this will store the fpscontroller
    public GameObject fpscontroller;
    //this will store the initial rotation
    public Vector3 inirotation;
    //this will check if the bucket is opened, and in BreakWallPuzzleController will use this script to check if the bucket is open
    public bool has_opened_bucket=false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this will check if the user click the mouse button, and if thge hammer is a child of fps controller, i do this so that the hammer swings
        if (Input.GetMouseButton(0) && this.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            //plays the animation to swing hammer
            this.gameObject.GetComponent<Animator>().Play("HammerSwing");
        }
        //this will check if the hammer is a child of the fps controller
        if (this.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            //this will activate the animator
            this.gameObject.GetComponent<Animator>().enabled = true;
            //this will change the hammer tag to untagged, so now the hammer isnt red, and the animator is actoive for the swinging
            this.gameObject.transform.tag = "Untagged";
        }
        //if the hammer inst being held by the user
        else
        {
            //change the hammer tag to clickable object, now its possible to grab it and it turns red when hovered
            this.gameObject.transform.tag = "clickable object";
            //this will rotate to the initial rotation, so that when the hammer is not held anymore, trhe hammer stays with the initial rotation
            this.gameObject.transform.rotation = Quaternion.Euler(inirotation);
            //this will desable the animator, so now the hammer isnt swinging anymore
            this.gameObject.GetComponent<Animator>().enabled = false;
        }
    }


    //this will check if the hammer is colliding with something
    public void OnTriggerStay(Collider other)
    {
        //if the bucket is not opened
        if (has_opened_bucket == false)
        {
            //if the object collided is a bucket and the player pressed mouse button 0
            if (other.gameObject == bucket.gameObject && Input.GetMouseButton(0))
            {
                //tell the code that the bucket is opened, and it wont repeat this code anymore, i do this because of the animation code bellow, if i didnt do this it would repeat the aniumation every time it touches the bucket
                has_opened_bucket = true;
                
                //plays the animation to open the bucket
                bucket.gameObject.GetComponent<Animator>().Play("Bucket");

            }
        }
    }
}
