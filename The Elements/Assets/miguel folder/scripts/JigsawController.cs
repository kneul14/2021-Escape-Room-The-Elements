using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawController : MonoBehaviour
{
    //this will store the fpscontroller and the safe
    public GameObject fpscontroller, safe;
    //this will store the initial jigsaw material
    Material jigsawMat;
    // Start is called before the first frame update
    void Start()
    {
        //store the initiaç jigsaw material
        jigsawMat = this.transform.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //if the jigsaw is a child of the fps controller
        if (this.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            //it will make the jigsaw untagged so that it turns red when hovered
            this.gameObject.tag = "Untagged";
            //it will restore its material
            this.transform.gameObject.GetComponent<MeshRenderer>().material = jigsawMat;


        }
        //if the safe is open
        else if(safe.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("safeopened"))
        {
            //change its tag to clickable object for it to be able to be grabbed
            this.gameObject.tag = "clickable object";
        }
    }

    public void OnTriggerStay(Collider other)
    {
       
        //if the user clicks mouse button AND has this object (jigsaw) on the hand And this object hitted a breakable wall
        if (Input.GetMouseButton(0) && this.gameObject.transform.IsChildOf(fpscontroller.transform) && other.transform.tag == "breakablewall")
        {
            //play the break wall animation
            other.gameObject.GetComponent<Animator>().Play("wallBreak");
            //make the jigsaw be dropped and never picked up again
            this.gameObject.GetComponent<GrabObject>().dropObject();
            this.gameObject.GetComponent<GrabObject>().enabled = false;
            this.gameObject.GetComponent<Click_clickable_object>().enabled = false;
        }
    }
}
