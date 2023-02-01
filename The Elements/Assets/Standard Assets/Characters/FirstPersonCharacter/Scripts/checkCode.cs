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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void check_code_inputed()
    {
        //if the user inserted 1428 open safe
        if(inputField.text=="1428")
        {
            safe.gameObject.GetComponent<Animator>().Play("openSafe");
            
            Destroy(this.gameObject);
            Debug.Log("opensafe");
        }
    }
}
