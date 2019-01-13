using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound {

    public string name;

    public AudioClip clip;

    [Range(0f, 1.25f)]
    public float volume = 1;
    [Range(0f, 1.25f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
