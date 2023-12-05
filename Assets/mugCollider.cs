using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugCollider : MonoBehaviour
{

  public void OnTriggerEnter(Collider other)
    {
                   
        if(other.gameObject.tag=="reception"){
            levelManager.Instance.comparerDrinks();
        }
        if(other.gameObject.layer == 7){
            Debug.Log("collision7");
            Destroy(other.gameObject);

            levelManager.Instance.addElement(other.gameObject.name);
        }
        if(other.gameObject.tag =="trash"){
            levelManager.Instance.listofCurrentDrink.Clear();
            GameObject MugTag = GameObject.FindGameObjectWithTag("mug");
            Transform[] children = MugTag.GetComponentsInChildren<Transform>();
            for(int i = 0; i < children.Length; i++){
                MugTag.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


}
