using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//make this script require the click clickable object script because it depends on him, because clickable object script, will tell us if our object was touched
[RequireComponent(typeof(Click_clickable_object))]
public class GrabObject : MonoBehaviour
{
    //this will store the initial position
    Vector3 initialpos;
    //this will store the initial rotation
    Quaternion inirot;
    //this will store the position of the object when grabbed
    public Vector3 localposition_of_grabbed;
    //this will store the rotation of the object when grabbed
    public Vector3 localrotation_of_grabbed;
    //this will store the fps controller
    public GameObject fpscontroller;
    //this will fix a bug, for the hammer, because in this code the box collider is disabled when the object is holded, and for the objects who uses triggers we need to activate their collider, for example the hammer.
    public bool EnableCollider = false;
    // Start is called before the first frame update
    void Start()
    {
        initialpos = this.gameObject.transform.position;
        inirot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true)
        {
            //if its not an object like a hammer
            if (EnableCollider == false)
            {
                //this will disable the collider
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            //this will make the object a child of the fps controller
            this.transform.SetParent(fpscontroller.transform);
            //this will change the localposition o be on front of the camera
            this.transform.localPosition = localposition_of_grabbed;
            //this will change its rotation
            this.transform.localRotation = Quaternion.Euler(localrotation_of_grabbed);


        }
        if (Input.GetMouseButton(1) && fpscontroller.transform.Find(this.gameObject.name))
        {
            this.transform.SetParent(null);
            this.gameObject.transform.position = initialpos;
            //this will store the initial rotation
            this.transform.rotation = inirot;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        //if the user clicks on the button E
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    public void dropObject()
    {
        this.transform.SetParent(null);
        this.gameObject.transform.position = initialpos;
        //this will store the initial rotation
        this.transform.rotation = inirot;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
