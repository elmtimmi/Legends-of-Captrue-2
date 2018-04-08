using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begrenzung : MonoBehaviour {
    public GameObject mainCamera;
    private mainScript a;
    public Material green;
    // Use this for initialization
    void Start () {
        a = mainCamera.GetComponent<mainScript>();
    }

    // Update is called once per frame
    void Update () {
        if (a.los && a.pc)
        {
            gameObject.GetComponent<Renderer>().material = green;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
