using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoff : MonoBehaviour
{
    private bool verify;
    
    public void On(GameObject lantern)
    {
        verify = !verify;
        lantern.SetActive(verify);
    }
}
