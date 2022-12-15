using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class mousePosition 
{
    
    private static Vector3 clickPosition;// Start is called before the first frame update
   

    public static Vector3 getPosition(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3 posUp;
        Vector3 position = new Vector3(0,0,0);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
                    posUp = new Vector3(hit.point.x,10f,hit.point.z);
                    position = hit.point;
            }
        return position;
    }
}
