using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reiter : MonoBehaviour {
    public GameObject mainCamera;
    private mainScript a;
    public int z;
    public int x;
    bool einmal;
    // Use this for initialization
    void Start()
    {
        a = mainCamera.GetComponent<mainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (a.landAuswählen && !einmal)
        {
            einmal = true;
            map();
        }
        GetComponent<TextMesh>().text = "" + a.reiter[z * 100 + x];
        this.GetComponent<MeshRenderer>().enabled = true;
        if (GetComponent<TextMesh>().text == "0")
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void map()
    {
        if (this.transform.name == "Reiter")
        {
            if (a.map == 1)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int t = 1; t < 6; t++)
                    {
                        x = t;
                        z = 6 - i;
                        Instantiate(this, new Vector3(t * 100 - 80, 10, i * 100 - 25), this.transform.rotation);
                    }
                }
            }
            if (a.map == 2)
            {
                for (int i = 1; i < 15; i++)
                {
                    for (int t = 1; t < 14; t++)
                    {
                        x = t;
                        z = 15 - i;
                        Instantiate(this, new Vector3(t * 100 - 80, 10, i * 100 - 25), this.transform.rotation);
                    }
                }
            }
        }
    }
}