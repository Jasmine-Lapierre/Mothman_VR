using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugCollider : MonoBehaviour
{

  public void OnTriggerEnter(Collider other)
    {
                    Debug.Log("collision");

        if(other.gameObject.layer == 7){
            Debug.Log("collision7");
            levelManager.Instance.addElement(other.gameObject.name);
        }
    }


}
