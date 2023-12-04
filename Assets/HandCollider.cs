using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollider : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding!");
        if(other.gameObject.layer == 6){
            levelManager.Instance.creationFloat(other.gameObject.tag);
        }
    }
}
