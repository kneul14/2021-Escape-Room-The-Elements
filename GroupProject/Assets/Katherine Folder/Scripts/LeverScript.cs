using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : InteractiveObject
{
    public Animator anim; //Reference to the animator
    
    public Interaction interactionInstance;
    
    public bool isLeverPulled = false;

    public override void OnStartInteraction()
    {
        Debug.Log(gameObject.name);

    }

    public void Update()
    {
        if (interactionInstance.GetComponent<Interaction>().leverPressed != false)
        {
            /*//Debug.Log("The Lever is pressed");
            anim.SetBool("isPulled", true);
            anim.SetTrigger("pullDown");*/

            this.gameObject.GetComponent<Animator>().Play("Lever trigger");

            isLeverPulled = true;                        
        }               

    }
       
}
