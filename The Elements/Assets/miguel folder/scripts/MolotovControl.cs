using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovControl : MonoBehaviour
{
    //this will store the initial position
    Vector3 inipos;
    //this will store the initial rotation
    Quaternion inirot;
    //this will store the fps controller
    public GameObject fpscontroller;
    //this will store the cloth
    public GameObject cloth;
    //this will store the molotov
    public GameObject molotov;
    //this will store the candleholder
    public GameObject candle_holder;
    //this will store the fire from the molotov
    public GameObject fire;
    //this variable will store the bookshelfs to be burned
    public GameObject bookshelfs;
    //this will store the bookshelf normal material
    Material bookshelfInitMat;
    bool molotovTrow = false;
    public GameObject bookshelfFire;
    bool DeleteEverything = false;
    // Start is called before the first frame update
    void Start()
    {
        //this will store the initial position of the candle
        inipos = candle_holder.transform.position;
        //this will store the initial rotation of the candle
        inirot = candle_holder.transform.rotation;
        //this will store the bookshelf init material, this will be useful when checking if the player is looking at the bookshelf
        bookshelfInitMat = bookshelfs.gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (DeleteEverything == false)
        {
            //if the user already grabbed the cloth, make the molotov change tag, for it to turn red when placing the mouse hover
            if (fpscontroller.transform.Find(cloth.name))
            {
                //change molotov tag to clickable object for it to turn red when user is looking at it
                molotov.tag = "clickable object";
            }
            //if the user already put the cloth inside the bottle, make the molotov change tag, for it to not turn red when placing the mouse hover, will change this when the candle turns the fire on
            else if (molotov.transform.Find(cloth.name) && !fpscontroller.transform.Find(candle_holder.name))
            {
                //change molotov tag to clickable object for it to turn red when user is looking at it
                molotov.tag = "Untagged";
                candle_holder.tag = "clickable object";
            }
            //if the user already holds the candle, make the molotov change tag, for it to turn red when placing the mouse hover
            else if (fpscontroller.transform.Find(candle_holder.name))
            {
                //change molotov tag to clickable object for it to turn red when user is looking at it
                molotov.tag = "clickable object";

            }
            if (!molotov.transform.Find(cloth.name) && !fpscontroller.transform.Find(cloth.name))
            {
                //change molotov tag to clickable object for it to turn red when user is looking at it
                molotov.tag = "Untagged";
            }
            if (molotov.transform.Find(cloth.name) && fire.active == true)
            {
                //change molotov tag to clickable object for it to turn red when user is looking at it
                molotov.tag = "clickable object";
                bookshelfs.transform.tag = "clickable object";
            }
        }
        BurnBookshelf();

    }

    //check if this collider is touching something
    public void OnTriggerStay(Collider other)
    {
        //if this object is colliding with the player
        if (other.tag == "Player")
        {
            //if the player already is holding the cloth, and being touched
            if (fpscontroller.transform.Find(cloth.name) && molotov.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true)
            {
                //make the cloth leave the fps controller "hands", by no longer being is child
                cloth.transform.parent = null;
                //make cloth be molotov child
                cloth.transform.parent = molotov.transform;
                //make cloth position be 0,0,0 
                cloth.transform.localPosition = new Vector3(0, 0, 0);
                //make cloth rotation be 0,0,0
                cloth.transform.localRotation = Quaternion.Euler(0, 0, 0);
                //change the cloth scale , i change this because on the table its bigger for it to be easiear to spot, and like this the cloth is on top of the bottle 
                cloth.transform.localScale = new Vector3(1, 1, 1);
            }
            //if the user is holding the candle and the molotov is being touched and cloth is in molotov
            if (molotov.transform.Find(cloth.name) && molotov.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && fpscontroller.transform.Find(candle_holder.name))
            {
                //activate fire
                fire.gameObject.SetActive(true);
                //make the candle leave the fps controller "hands", by no longer being is child
                candle_holder.transform.parent = null;
                //make the candle move to the initial position
                candle_holder.transform.position = inipos;
                //make the candle rotate to the initial rotation
                candle_holder.transform.rotation = inirot;
                //change candle tag to untagged for it to not turn red when user is looking at it
                candle_holder.tag = "Untagged";
                //deactivate its scripts because we arot going to use it again
                candle_holder.gameObject.GetComponent<GrabObject>().enabled = false;
                candle_holder.gameObject.GetComponent<Click_clickable_object>().enabled = false;
                //change molotov tag
                molotov.tag = "clickable object";
                //activate the molotov gtrab script
                molotov.GetComponent<GrabObject>().enabled = true;
            }


        }
    }

    //this will make the burning of the bookshelf
    void BurnBookshelf()
    {
        if (DeleteEverything == false)
        {
            //if the bookshelfs are being looked at, and user clicks mouse one, and the molotov is don, and a child of the first person
            if (bookshelfs.gameObject.GetComponent<MeshRenderer>().material != bookshelfInitMat && Input.GetMouseButton(0)
            && molotov.transform.Find(cloth.name) && fire.active == true
            && fpscontroller.transform.Find(molotov.name))
            {
                //tell the code that the molotov has been trowned
                molotovTrow = true;

                Debug.Log("molotov trowned");
            }

            //if the molotov has been trowned
            if (molotovTrow == true)
            {
                //remove the molotov from fpsplayer
                molotov.transform.SetParent(null);
                //make molotov move to bookshelf
                
                //activate the fire
                bookshelfFire.SetActive(true);
                


            }
        }
        //if the molotov has been trowned
        if (molotovTrow == true)
        {
            try
            {
                molotov.transform.position = Vector3.MoveTowards(molotov.transform.position, bookshelfs.transform.position, 0.4f);
            }
            catch
            {

            }
            //call the coroutine
            StartCoroutine(ExampleCoroutine());
        }
    }

    IEnumerator ExampleCoroutine()
    {
       DeleteEverything = true;
        molotov.gameObject.GetComponent<MeshRenderer>().enabled = false;
        cloth.gameObject.GetComponent<MeshRenderer>().enabled = false;
        
        bookshelfFire.transform.SetParent(null);
       //yield on a new YieldInstruction that waits for 5 seconds.
       yield return new WaitForSeconds(2f);
        
       
        //destroy the fire object
        Destroy(bookshelfs);
       //plays the animation end the fire
       bookshelfFire.gameObject.GetComponent<Animator>().Play("fireEnding");
        //yield on a new YieldInstruction that waits for 5 seconds. }
       

        yield return new WaitForSeconds(1f);
        Destroy(molotov.gameObject);
        //destroy the fire object
        Destroy(bookshelfFire);
        
        Destroy(this.gameObject);



    }
}
