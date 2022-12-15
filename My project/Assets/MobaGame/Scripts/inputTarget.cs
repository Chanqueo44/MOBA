using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputTarget : MonoBehaviour
{
    public Entity selectedEntity;
    public bool heroPlayer;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        selectedEntity = GameObject.FindObjectOfType<Entity>();
    }

    // Update is called once per frame

    
    void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out hit, Mathf.Infinity)){
                if(hit.collider.GetComponent<Targetable>() != null){
                    selectedEntity.GetComponent<Combat>().targetedEntity = hit.collider.gameObject;
                }
                else if(hit.collider.gameObject.GetComponent<Targetable>() == null){
                    selectedEntity.GetComponent<Combat>().targetedEntity = null;   
                }
            }
        }
    }
}
