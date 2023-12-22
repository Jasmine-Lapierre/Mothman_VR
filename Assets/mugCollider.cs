using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mugCollider : MonoBehaviour
{
  public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + "AFFAIRE QUI AMRHCE PAS");
                   
        if(other.gameObject.tag=="reception"){
            levelManager.Instance.comparerDrinks();
        }
        if(other.gameObject.layer == 7){
            AudioSource audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            Debug.Log("collision7");
            Destroy(other.gameObject);

        Debug.Log(other + "AFFAIRE QUI AMRHCE PAS ????????????????");

            levelManager.Instance.addElement(other.gameObject.name);
        }
        if(other.gameObject.tag =="trash"){
            levelManager.Instance.IsLiquidwhar = false;
            levelManager.Instance.listofCurrentDrink.Clear();
            GameObject MugTag = GameObject.FindGameObjectWithTag("mug");
             GameObject liquide = GameObject.FindGameObjectWithTag("liquide");
    Destroy(liquide);
            Transform[] children = MugTag.GetComponentsInChildren<Transform>(true);
            for(int i = 0; i < children.Length; i++){
                MugTag.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }


}
