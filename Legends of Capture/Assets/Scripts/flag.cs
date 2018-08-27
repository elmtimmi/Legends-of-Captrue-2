using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flag : MonoBehaviour
{

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
        if (a.spielerLand[z * 100 + x] == 0)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        if (a.spielerLand[z * 100 + x] == 1)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (a.spielerLand[z * 100 + x] == 2)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (a.spielerLand[z * 100 + x] == 3)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (a.spielerLand[z * 100 + x] == 4)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }
    public void map()
    {
        if (this.transform.name == "Flag")
        {
            if (a.map == 1)
            {
                for (int i = 1; i < 6; i++)
                {
                    for (int t = 1; t < 6; t++)
                    {
                        x = t;
                        z = 6 - i;
                        Instantiate(this, new Vector3(t * 100 - 45, 20, i * 100 - 35), this.transform.rotation);
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
                        Instantiate(this, new Vector3(t * 100 - 45, 20, i * 100 - 35), this.transform.rotation);
                    }
                }
            }
            if (a.kampagneMap == 1)
            {
                for (int i = 1; i < 13; i++)
                {
                    for (int t = 1; t < 8; t++)
                    {
                        x = t;
                        z = 13 - i;
                        Instantiate(this, new Vector3(t * 100 - 45, 20, i * 100 - 135), this.transform.rotation);
                    }
                }
            }
        }
    }
}
