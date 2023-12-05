using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugCollider : MonoBehaviour
{

  public void OnTriggerEnter(Collider other)
    {
                   

        if(other.gameObject.layer == 7){
            Debug.Log("collision7");
            levelManager.Instance.addElement(other.gameObject.name);
        }
        if(other.gameObject.tag =="trash"){
            GameObject MugTag = GameObject.FindGameObjectWithTag("mug");
            Transform[] children = MugTag.GetComponentsInChildren<Transform>();
            for(int i = 0; i < children.Length; i++){
                MugTag.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


}
