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
    [SerializeField] private GameObject[] menuItems;

    [SerializeField] private GameObject[] prefabAnimation;
    public GameObject positonmug;
   public bool IsLiquidwhar = false;
    public GameObject prefabLiquide;

    public string monstre;
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

public List<Recette> creerRecette(string monstre){
    
List<Recette> listofRecettes = new List<Recette>();
List<Recette> listofRecettesSpepcialisee = new List<Recette>();
listofRecettes.AddRange(new List<Recette>
{
    new Recette("eyeball", "zombie", "float" ),
    new Recette("brain", "zombie","float" ),
    new Recette("blood","zombie", "liquid" ),
    new Recette("flesh","zombie", "liquid" ),
    new Recette("bone","zombie", "liquid" ),
    new Recette("lantern","mothman", "float" ),
    new Recette("lightbulb","mothman", "float" ),
    new Recette("lighterFluid","mothman", "liquid" ),
    new Recette("cocoonNectar","mothman", "liquid" ),
    new Recette("chlorophyll","mothman", "liquid" ),
    new Recette("ectoplasm","ghost", "float" ),
     new Recette("ectoplasmJuice","ghost", "liquid" ),
    new Recette("ouijaPlanchette","ghost", "float" ),
    new Recette("booJuice","ghost", "liquid" ),
    new Recette("poltergeistSyrup","ghost", "liquid" ),
 });
for (int i = 0; i < listofRecettes.Count; i++){
 if(listofRecettes[i].Monster == monstre){
    Debug.Log(listofRecettes[i].Monster);
    listofRecettesSpepcialisee.Add(listofRecettes[i]);
    }
}
        return  listofRecettesSpepcialisee;
     }

public void CacherCreature(){
    foreach(GameObject Creature in prefabAnimation){
        Creature.SetActive(false);
    }
}
public void CreerCommande(){
    CacherCreature();
    Animator affaireAnimer = prefabAnimation[2].GetComponent<Animator>();
    affaireAnimer.Play("ghostAnim");

    Random r = new System.Random();
    int indexMonstre = r.Next(0,3);
    Debug.Log(indexMonstre +  " Voici l'index");
    switch (indexMonstre)
    {
        case 0:
        prefabAnimation[2].SetActive(true);
        monstre="mothman";
        break;
        case 1:
        prefabAnimation[2].SetActive(true);
        monstre="zombie";
        break;
        case 2: 
        prefabAnimation[2].SetActive(true);
        monstre="ghost";
        break;
        
        default:
        Debug.Log("bug creation de recette");
        break;
    }
    
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

//Random r = new System.Random();
/**/
for (int i = 0; i < listofEverythingelse.Count; i++){
    int index = r.Next(0,2);
    if (index==0){
    afficherCommandeMenu(listofEverythingelse[i].Name);
Debug.Log( listofEverythingelse[i].Name + "voici le nom d'un ingrédient");
      listofCurrentOrder.Add(listofEverythingelse[i]);
    }
}

    int affaireindex = r.Next(0,listofLiquids.Count());
    listofCurrentOrder.Add(listofLiquids[affaireindex]);
      afficherCommandeMenu(listofLiquids[affaireindex].Name);
    Debug.Log(listofLiquids[affaireindex].Name + " Voici le nom du liquide");

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
    CacherCreature();
CreerCommande();
       /* GameObject monstreActuel = GameObject.FindGameObjectWithTag("monstreClient");
        Animator monstreAnimationActuel = monstreActuel.GetComponent<Animator>();
        monstreAnimationActuel.Play("entree"); */


afficherCommande(listofCurrentOrder);



for (int i = 0;i < floatsPrefabs.Length; i++){

floatPrefabsStringToGameObject.Add(floatsJar[i].tag , floatsPrefabs[i]);
		foreach(KeyValuePair<string, GameObject> kvp in floatPrefabsStringToGameObject){
            Debug.Log(kvp.Value + " index:" + i);


        };
            }}

public void creationFloat(string floatsName)
    {
 GameObject floatElement = (GameObject) Instantiate(floatPrefabsStringToGameObject[floatsName]);
 floatElement.name = floatElement.name.Remove(floatElement.name.Length-7);

    }

public void afficherCommandeMenu(string elementName){
    GameObject MenuTag = GameObject.FindGameObjectWithTag("menu");
Transform[] children = MenuTag.GetComponentsInChildren<Transform>(true);
Debug.Log(children + "Longueur " +children.Length );
for(int i = 0; i < children.Length-1; i++){
    Debug.Log(MenuTag.transform.GetChild(i).gameObject.name + " ?????  " +elementName );
if(MenuTag.transform.GetChild(i).gameObject.name == elementName){
if(MenuTag.transform.GetChild(i).gameObject.activeSelf ==false){

   Debug.Log(MenuTag.transform.GetChild(i).gameObject.name + " = " + elementName);
    MenuTag.transform.GetChild(i).gameObject.SetActive(true);} 

}

}}
public void addElement(string elementName){

 GameObject MugTag = GameObject.FindGameObjectWithTag("mug");
Transform[] children = MugTag.GetComponentsInChildren<Transform>(true);
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
    MugTag.transform.GetChild(i).gameObject.SetActive(true);} 
    else{
        afficherCommande(listofCurrentDrink);

    }
} 
}
}
public void changeLiquidColor(string Couleur){

if(!IsLiquidwhar){
    IsLiquidwhar = true;
    GameObject[] MugTagArr;
//string[] rgba = Couleur.Split(",");

 MugTagArr = GameObject.FindGameObjectsWithTag("mug");

GameObject liquide = Instantiate(prefabLiquide , MugTagArr[0].transform, worldPositionStays:false);
/*Debug.Log("VOICI le saffaires COULEUR "+ rgba[0]+" "+rgba[1]+" "+rgba[2]);*/
 Color newCol;
if(ColorUtility.TryParseHtmlString(Couleur, out newCol)){

liquide.GetComponent<Renderer>().material.color = newCol;

}
//liquide.GetComponent<Renderer>().material.color = new Color(float.Parse(rgba[0]),float.Parse(rgba[1]),float.Parse(rgba[2]));

}}

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



          GameObject[] MugTagArr;
       MugTagArr = GameObject.FindGameObjectsWithTag("mug");

    if(comparaisonlist.Count == listofCurrentOrder.Count){
        Debug.Log("C'est pareil");
        CreerCommande();
        MugTagArr[0].transform.position = positonmug.transform.position;
       /* GameObject monstreActuel = GameObject.FindGameObjectWithTag("monstreClient");
        Animator monstreAnimationActuel = monstreActuel.GetComponent<Animator>();
        monstreAnimationActuel.Play("sortie"); */

    }else{
        Debug.Log("C'est pas pareil");
                MugTagArr[0].transform.position = positonmug.transform.position;

    }
}
}
