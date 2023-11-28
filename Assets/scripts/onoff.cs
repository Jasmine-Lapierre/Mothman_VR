using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onoff : MonoBehaviour
{
    AudioSource source;
    private bool verify;
    
    public void On(GameObject lantern)
    {
        verify = !verify;
        lantern.SetActive(verify);
        source = GetComponent<AudioSource>();
        source.Play();
    }
}
