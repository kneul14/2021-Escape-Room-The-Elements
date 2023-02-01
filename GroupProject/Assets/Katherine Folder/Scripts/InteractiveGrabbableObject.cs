using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveGrabbableObject : InteractiveObject
{
    public GameObject lever;
    public Rigidbody rb;
    public Collider coll;

    public LeverScript leverScriptInstance;
    public Interaction interactionInstance;

    public override void OnStartInteraction()
    {
        Debug.Log(gameObject.name);

        if (Interaction.grabbedObject == null)
        {
            Interaction.grabbedObject = gameObject;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }

    }

    public override void OnEndInteraction()
    {
        GetComponent<Collider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    /*check lever script if a bool is true and if true lever is pressed come down*/

    public void Update()
    {

        if (interactionInstance.GetComponent<Interaction>().leverPressed != false)
        {
            this.rb.useGravity = true;
        }

        /*if (leverScriptInstance.GetComponent<LeverScript>().isLeverPulled != false)               //This just wouldn't work no matter what I tried.
        {
           //this.rb.useGravity = true;
        }*/

    }

}
