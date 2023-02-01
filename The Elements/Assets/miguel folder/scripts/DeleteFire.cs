using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFire : MonoBehaviour
{
    //this will store the fire 
    public GameObject fire;
    //this will start destroing the fire if true
    bool start_destroing_fire = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1f);
        //destroy the fire object
        Destroy(fire);
        

    }

    // Update is called once per frame
    void Update()
    {
        //if this bool is true, it will be when this object collide with the floor
        if(start_destroing_fire==true)
        {
            //call the ienumerator function to make the script wait 2 seconds to make the animation end
            StartCoroutine(ExampleCoroutine());
            
           
        }
        
    }

    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
        //if the object collide with the floor
        if(collision.gameObject.tag=="floor")
        {
            //plays the animation end the fire
            fire.gameObject.GetComponent<Animator>().Play("fireEnding");
            //this will make this object not move
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //warn the code to start destroing the fire
            start_destroing_fire = true;  
        }
       
    }
}
