using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null; //Static instance of GameManager which allows it to be accessed by any other script.

    public InteracableObject[] interacableObject;

    public bool interact = false;

    //Awake is always called before any Start functions
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

    }

    public InteracableObject FindObject(string ObjectName)
    {
        InteracableObject _object = null;
        for(int i = 0;i < interacableObject.Length; i++)
        {
            if (interacableObject[i]._name == ObjectName)
                _object = interacableObject[i];
        }
        return _object;
    }

}
