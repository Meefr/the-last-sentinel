using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music_off : MonoBehaviour
{
    public AudioSource a;
    // Start is called before the first frame update
    public void Stopsound()
    {
        a.Pause();
    }
    public void playsound()
    {
        a.Play();
    }
}
