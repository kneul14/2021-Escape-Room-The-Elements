using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkCode : MonoBehaviour
{
    //this will store the input field
    public Text inputField;
    //this will store safe object
    public GameObject safe;
    //this will store fps controller
    public GameObject fps_controller;
    //this will store the code for the safe
    public string code;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void check_code_inputed()
    {
        //if the user inserted the  open safe code
        if(inputField.text==code)
        {
            //plays the animation open safe
            safe.gameObject.GetComponent<Animator>().Play("openSafe");
            //deletes the script clickable object from the safe
            safe.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            //enables the fps controller
            fps_controller.gameObject.GetComponent<MonoBehaviour>().enabled = true;
            //changes the tag from the safe for it to dont be red anymore when hovered
            safe.gameObject.tag = "Untagged";
            //disable the safe box collider for the remote to be able to get red when hovered
            safe.gameObject.GetComponent<BoxCollider>().enabled = false;
            //locks the cursor and then hides it
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //destroy gameobject
            Destroy(this.gameObject);
            Debug.Log("opensafe");
        }
    }
}
