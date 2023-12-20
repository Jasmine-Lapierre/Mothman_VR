using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class menuControl : MonoBehaviour
{
    public GameObject myGameObject;
        public void jouer()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void quitterPartie()
    {
        Application.Quit();
    }

    public void ouvrirConsignes()
    {   
        if(myGameObject.name == "Consignes"){
        myGameObject.SetActive(true);
        }
    }

    public void fermerConsignes()
    {   
        if(myGameObject.name == "Consignes"){
        myGameObject.SetActive(false);
        }
    }

}
 