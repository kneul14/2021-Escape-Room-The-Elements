using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvasCode : MonoBehaviour
{
    //variables
    public Text imputField;
    public string code;
    public GameObject playr;
    public GameObject bookshelf;
    public GameObject wallcode;

    public void checkCode()
    {
        //if the text inserted is equal to the code pre selected
        if(imputField.text == code)
        {
            //Debug.Log("correct code");
            bookshelf.gameObject.GetComponent<Animator>().Play("bookshelf");
            wallcode.gameObject.tag = "Untagged";
            wallcode.gameObject.GetComponent<Click_clickable_object>().enabled = false;
            playr.gameObject.GetComponent<MonoBehaviour>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.gameObject.active = false;
        }
    }
}
