using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyScript : MonoBehaviour
{
    [SerializeField]
    GameObject trophy1;
    [SerializeField]
    GameObject trophy2;
    [SerializeField]
    GameObject trophy3;
    [SerializeField]
    GameObject trophy4;
    [SerializeField]
    GameObject fpscontroller;
    [SerializeField]
    GameObject trophyholder1;
    [SerializeField]
    GameObject trophyholder2;
    [SerializeField]
    GameObject trophyholder3;
    [SerializeField]
    GameObject trophyholder4;
    [SerializeField]
    GameObject teleport;
    //this will count the number of trophys moved
    int progress=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //if any trophy is child of fps dont let the player grab a trophy
        if (trophy1.gameObject.transform.IsChildOf(fpscontroller.transform) || trophy2.gameObject.transform.IsChildOf(fpscontroller.transform) || trophy3.gameObject.transform.IsChildOf(fpscontroller.transform) || trophy4.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            trophy1.transform.tag = "Untagged";
            trophy2.transform.tag = "Untagged";
            trophy3.transform.tag = "Untagged";
            trophy4.transform.tag = "Untagged";
        }
        //if no trophy is child of fps let the player grab a trophy
        else
        {
            trophy1.transform.tag = "interactive object";
            trophy2.transform.tag = "interactive object";
            trophy3.transform.tag = "interactive object";
            trophy4.transform.tag = "interactive object";
        }
        CheckTrophys();
        //if all trophys are moved
        if (progress>=4)
        {
            //here is the end of the puzzles
            //make the teleport go to the other scene
            teleport.GetComponent<Teleport>().TeleportToScene = true;
        }
    }
    //this will check if a throphy holder is being touched, if it is, it will make the throphy be moved there
    void CheckTrophys()
    {
        //if the trophy holder is being touched and i have the right trophy on hand, it will drop the trophy. deactivate it, and then move it to the trophy holder position, in the end it will advance the progress
        if (trophyholder1.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && trophy1.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            trophy1.gameObject.GetComponent<GrabObject>().dropObject();
            trophy1.gameObject.GetComponent<GrabObject>().enabled = false;
            trophy1.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            trophy1.transform.position = trophyholder1.transform.position - new Vector3(0.01f, 0.1f, 0.065f);
            progress = progress + 1;
        }
        //if the trophy holder is being touched and i have the right trophy on hand, it will drop the trophy. deactivate it, and then move it to the trophy holder position
        if (trophyholder2.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && trophy2.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            trophy2.gameObject.GetComponent<GrabObject>().dropObject();
            trophy2.gameObject.GetComponent<GrabObject>().enabled = false;
            trophy2.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            trophy2.transform.position = trophyholder2.transform.position - new Vector3(0.01f, 0.1f, 0.065f);
            progress = progress + 1;
        }
        //if the trophy holder is being touched and i have the right trophy on hand, it will drop the trophy. deactivate it, and then move it to the trophy holder position
        if (trophyholder3.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && trophy3.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            trophy3.gameObject.GetComponent<GrabObject>().dropObject();
            trophy3.gameObject.GetComponent<GrabObject>().enabled = false;
            trophy3.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            trophy3.transform.position = trophyholder3.transform.position - new Vector3(0.01f, 0.1f, 0.065f);
            progress = progress + 1;
        }
        //if the trophy holder is being touched and i have the right trophy on hand, it will drop the trophy. deactivate it, and then move it to the trophy holder position
        if (trophyholder4.GetComponent<Click_clickable_object>().is_being_touched_and_clicked == true && trophy4.gameObject.transform.IsChildOf(fpscontroller.transform))
        {
            trophy4.gameObject.GetComponent<GrabObject>().dropObject();
            trophy4.gameObject.GetComponent<GrabObject>().enabled = false;
            trophy4.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            trophy4.transform.position = trophyholder4.transform.position - new Vector3(0.01f, 0.1f, 0.065f);
            progress = progress + 1;
        }
    }
}
