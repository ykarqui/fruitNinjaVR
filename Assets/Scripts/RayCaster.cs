using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour
{
    
    // Use this for initialization  
    void Start () {  
              
    }  
          
    // Update is called once per frame  
    void Update () {
        float xDirection = Input.GetAxis ("Mouse X");
        float yDirection = Input.GetAxis ("Mouse Y");  
      
        transform.Rotate (-yDirection, xDirection, 0);
        CheckIfRayCastHit ();  
    }
        
    void CheckIfRayCastHit (){
        RaycastHit hit;
        Vector3 adj = new Vector3(0f, -1f, 0f);
        Ray destoyRay = new Ray(transform.position, Vector3.forward);
            
        Debug.DrawRay(transform.position + adj, transform.forward*1000, Color.red);
        if (Physics.Raycast (transform.position + adj, transform.forward, out hit) && Input.GetMouseButtonDown(0)){
            print (hit.collider.gameObject.name +"has been destroyed!");
            Destroy (hit.collider.gameObject);  
        }
    }  
}
