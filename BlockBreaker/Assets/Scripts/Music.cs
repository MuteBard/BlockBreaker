using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    void Awake(){
        //find all game objects with this tag
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        //check the number of game objects with this tag to see if it is over 1
        if(obj.Length > 1)
            //if so then destroy this particular gameobject that this script is on
            Destroy(this.gameObject);
        //if not then stay alive
        DontDestroyOnLoad(this.gameObject);
    }
}
