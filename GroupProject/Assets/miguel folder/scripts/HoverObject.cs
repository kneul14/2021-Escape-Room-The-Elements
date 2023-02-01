using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverObject : MonoBehaviour
{
    //this bool will control if the player already saw a controlable object, i check this, because of the console errors, it will appear one if i try to access old_hit, without assigning one
    bool has_seen_one_clickable_object=false;
    //this will save the old color, for when the player no longer hovers the object
    bool save_old_color = true;
    //this will have the rycasted object
    RaycastHit hit;
    //this will save the old raycast
    RaycastHit old_hit;
    //this will save the camera that is being used
    public Camera CameraCenter;
    //this will save the old material
    Material old_material;
    //this will save the border material, used to paint objects hovered
    public Material Border;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //this will get the center of the camera
        Vector3 camera_center = CameraCenter.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, CameraCenter.nearClipPlane));
        //this will check what object as been raycasted
        if (Physics.Raycast(camera_center, this.transform.forward, out hit, 1000))
        {
            //this will check if the object raycasted is a clickable object
            if (hit.transform.tag == "clickable object")
            {
                //this will warn the computer that we already saw a clickable object
                has_seen_one_clickable_object = true;
                //will check if there is the need to save the old material, i have this if, because this can only run one time, and run again when we are already not overing this object and hover it again
                if (save_old_color ==true)
                {
                    //will equal the old hit to the actual hit
                    old_hit = hit;
                    //if the hitted object is a border enable the mesh
                    if (old_hit.transform.name == "Border")
                    {
                        old_hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                    }
                    //save on the old material variable the actual material
                    old_material = hit.transform.gameObject.GetComponent<MeshRenderer>().material;
                }
                //tell the code to not comeback here until hovering an object again
                save_old_color = false;
                //change the material
                hit.transform.gameObject.GetComponent<MeshRenderer>().material = Border;
                show_on_canvas();
            }
            //if is no longer seying an clickable object
            else if(has_seen_one_clickable_object==true)
            {
                //warn the code that he can save the old color again
                save_old_color = true;
                //tem um try porque aqui é normal aparecer um erro quando se apaga o comando por exmplo, ele vai ver q o old_hit ja nao existe, basta olhar pra outro objeto q isso desaparece
                try
                {
                    //if he didnt hit anything
                    if (old_hit.transform.name != null)
                    {   //check if the old object is a border if it is deactivate the mesh
                        if (old_hit.transform.name == "Border")
                        {
                            old_hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                        }
                        //change the material of the object
                        old_hit.transform.gameObject.GetComponent<MeshRenderer>().material = old_material;

                    }
                }
                catch
                {

                }
               
            }

            //this will make an object interactive without getting red
            if (hit.transform.tag == "interactive object")
            {
                show_on_canvas();
            }
        }

    }
    void show_on_canvas()
    {
        //if user clicks on mouse
        if (Input.GetMouseButton(0))
        {
            //if object clicked is a clickable object
            if(hit.transform.gameObject.GetComponent<Click_clickable_object>()==true)
            {
                //tell the code that the object is being clicked
                hit.transform.gameObject.GetComponent<Click_clickable_object>().is_being_touched_and_clicked = true;
                
            }
            //if the object has the functionality of a control remote
            else if (hit.transform.gameObject.GetComponent<ControleRemoteScript>() == true)
            {
                //tell the remote that it is clicked
                hit.transform.gameObject.GetComponent<ControleRemoteScript>().is_it_clicked = true;
            }
          
        }
        else
        {
            if (hit.transform.gameObject.GetComponent<ControleRemoteScript>() == true)
            {
                //tell the code that the remote is not being touched
                hit.transform.gameObject.GetComponent<ControleRemoteScript>().is_it_clicked = false;
            }
           
        }
        
       
    }

    

}
