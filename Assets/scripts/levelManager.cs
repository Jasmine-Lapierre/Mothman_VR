using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = System.Random;
using System.ComponentModel;
public class levelManager : MonoBehaviour
{
     [Header("References")]
    [SerializeField] private GameObject[] floatsPrefabs;
    [SerializeField] private GameObject[] floatsJar;
public class Recette
{ 
    public string Name;
    public string Monster;
    public string Type;

    public Recette(string name, string monster, string type) => (Name, Monster, Type) = (name, monster, type);
}
public override string ToString()
{
    return "(" + name + "," + ")";
}
List<Recette> listofCurrentOrder = new List<Recette>();
public   List<Recette> listofCurrentDrink = new List<Recette>();

 IDictionary<string, string> Commande = new Dictionary<string, string>();

public List<Recette> creerRecette( string monstre){
List<Recette> listofRecettes = new List<Recette>();
List<Recette> listofRecettesSpepcialisee = new List<Recette>();
Debug.Log("First Step");
listofRecettes.AddRange(new List<Recette>
{
    
   /* new Recette("bone", "zombie", "float" ),
    new Recette("eye", "ghost","float" ),
    new Recette("blood","zombie", "liquid" ),
    new Recette("ectoplasm","ghost", "liquid" ),*/
    new Recette("liquide1test","zombie", "liquid" ),
    new Recette("liquid2Test","zombie", "liquid" ),
    new Recette("bone","zombie", "float" ),
    new Recette("eye","zombie", "float" ),
     new Recette("liquid1Ghost","ghost", "liquid" ),
    new Recette("liquid2Ghost","ghost", "liquid" ),
    new Recette("liquid3Ghost","ghost", "liquid" ),
    new Recette("float1Ghost","ghost", "float" ),
    new Recette("float2Ghost","ghost", "float" ),
    new Recette("float3Ghost","ghost", "float" ),

 });
for (int i = 0; i < listofRecettes.Count; i++){
    Debug.Log("Third Step");
 if(listofRecettes[i].Monster == monstre){
    Debug.Log(listofRecettes[i].Monster);
    listofRecettesSpepcialisee.Add(listofRecettes[i]);
    }
}
        return  listofRecettesSpepcialisee;
     }
public void CreerCommande(string monstre){
    
listofCurrentOrder.Clear();

List<Recette> listofLiquids = new List<Recette>();
List<Recette> listofEverythingelse = new List<Recette>();
listofLiquids.Clear();
listofEverythingelse.Clear();

List<Recette> RecettesSpecialisees = creerRecette(monstre);
for (int i = 0; i < RecettesSpecialisees.Count; i++){
 if(RecettesSpecialisees[i].Type == "liquid"){
    
    listofLiquids.Add(RecettesSpecialisees[i]);
    }
    else {
listofEverythingelse.Add(RecettesSpecialisees[i]);
    }
}

Random r = new System.Random();
/**/
for (int i = 0; i < listofEverythingelse.Count; i++){
    int index = r.Next(0,2);
    if (index==0){
      listofCurrentOrder.Add(listofEverythingelse[i]);
    }
}

    int affaireindex = r.Next(0,listofLiquids.Count());
    listofCurrentOrder.Add(listofLiquids[affaireindex]);


}
public void afficherCommande(List<Recette> commande){
for(int i =0; i<commande.Count; i++){
    Debug.Log(commande[i].Name + " ICI ICI ");
}

}

    public static levelManager Instance;
   // public static Recette commandeActuelle = new Recette();


    void Awake()
    {
        Instance = this;
    }

 IDictionary<string, GameObject> floatPrefabsStringToGameObject = new Dictionary<string, GameObject>();
 void Start(){
CreerCommande("zombie");


afficherCommande(listofCurrentOrder);



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
if(MugTag.transform.GetChild(i).gameObject.activeSelf ==false){

   listofCurrentDrink.AddRange(new List<Recette>
{
    new Recette(elementName,"","" ),

 });
afficherCommande(listofCurrentDrink);
   Debug.Log(MugTag.transform.GetChild(i).gameObject.name + " = " + elementName);
    MugTag.transform.GetChild(i).gameObject.SetActive(true);} else{
        afficherCommande(listofCurrentDrink);

    }
} 
}
}
public void addLiquid(string elementName){
List<Recette> isLiquid = new List<Recette>();
for(int i = 0; i<listofCurrentDrink.Count; i++){
if(listofCurrentDrink[i].Type =="liquid"){
  isLiquid.Add(listofCurrentDrink[i]);
}}
if(isLiquid == null || isLiquid.Count< 1){
{
listofCurrentDrink.AddRange(new List<Recette>
{
    new Recette(elementName,"","liquid" ),

 });
         afficherCommande(listofCurrentDrink);

}}

else{
            afficherCommande(listofCurrentDrink);

}}

public void comparerDrinks(){
    
    List<Recette> comparaisonlist = new List<Recette>();
    for(int i = 0; i<listofCurrentOrder.Count;i++){
        for(int index = 0; index<listofCurrentDrink.Count;index++){
            if(listofCurrentDrink[index].Name == listofCurrentOrder[i].Name){
                comparaisonlist.AddRange(new List<Recette>
{
    new Recette(listofCurrentDrink[index].Name,"","" ),

 });
 afficherCommande(comparaisonlist);
 Debug.Log("Voici un ingredient: " + listofCurrentDrink[index].Name);
                
            }
            else{Debug.Log("Pas un ingredient: " + listofCurrentDrink[index].Name);
            }
        }
    }





    if(comparaisonlist.Count == listofCurrentOrder.Count){
        Debug.Log("C'est pareil");
    }else{
        Debug.Log("C'est pas pareil");
    }
}
}
