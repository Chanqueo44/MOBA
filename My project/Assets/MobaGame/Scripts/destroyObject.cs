using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float lifeTime=0;
    void Start(){
        Destroy(gameObject, lifeTime);
    }
}
