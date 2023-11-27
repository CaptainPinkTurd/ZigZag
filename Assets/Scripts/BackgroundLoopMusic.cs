using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoopMusic : MonoBehaviour
{
    private static BackgroundLoopMusic instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else //if the first instance of the background music already exist, then destroy the game object of the new one on awake
        {
            Destroy(gameObject); 
        }
        DontDestroyOnLoad(gameObject); //don't destroy the game object of all the instances that's still available (meaning the first one  
    }
}
