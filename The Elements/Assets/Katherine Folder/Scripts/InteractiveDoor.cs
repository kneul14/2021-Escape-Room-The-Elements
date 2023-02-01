using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : InteractiveObject
{
    //public Animator anim;
    public LayerMask DoorMask;
    public InteractiveKey interactiveKeyInstance;


    private void Start()
    {
      
    }
    public override void OnStartInteraction()
    {
        if (interactiveKeyInstance.GetComponent<Interaction>().hasKey != false)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f, DoorMask))
            {
                    Debug.Log("Door Open");
            }
                        
        }

    }
}