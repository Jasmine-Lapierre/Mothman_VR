using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
     [Header("References")]
    [SerializeField] private GameObject[] floatsPrefabs;
    [SerializeField] private GameObject[] floatsJar;
    public static levelManager Instance;

    void Awake()
    {
        Instance = this;
    }

 IDictionary<string, GameObject> floatPrefabsStringToGameObject = new Dictionary<string, GameObject>();
 void Start(){

for (int i = 0;i < floatsPrefabs.Length; i++){

floatPrefabsStringToGameObject.Add(floatsJar[i].tag , floatsPrefabs[i]);
		foreach(KeyValuePair<string, GameObject> kvp in floatPrefabsStringToGameObject);
            
            }}

public void creationFloat(string floatsName)
    {
 GameObject floatElement = (GameObject) Instantiate(floatPrefabsStringToGameObject[floatsName]);
 floatElement.name = floatElement.name.Remove(floatElement.name.Length-7);

    }


public void addElement(string elementName){

GameObject MugTag = GameObject.FindGameObjectWithTag("mug");
Transform[] children = MugTag.GetComponentsInChildren<Transform>();
for(int i = 0; i < children.Length+1; i++){
    Debug.Log(MugTag.transform.GetChild(i).gameObject.name + "   " +elementName );
if(MugTag.transform.GetChild(i).gameObject.name == elementName){
   Debug.Log(MugTag.transform.GetChild(i).gameObject.name + " = " + elementName);
    MugTag.transform.GetChild(i).gameObject.SetActive(true);
} 
}
}}
