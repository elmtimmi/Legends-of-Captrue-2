using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pfeil : MonoBehaviour
{
    public GameObject mainCamera;
    private mainScript a;
    // Use this for initialization
    void Start()
    {
        a = mainCamera.GetComponent<mainScript>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            hit.point = new Vector3(hit.point.x, 0, hit.point.z);
        if (a.verteidigungsLand == a.angriffsLand) {
            transform.LookAt(hit.point);
        }
        if (a.angriffsLand == 0)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        }
        else
        {
            if (a.anDerReihe == a.spielerLand[a.angriffsLand] && a.zugGemacht == false && a.spielerLand[a.angriffsLand] != 0)
            {
                this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                if (a.map == 1)
                {
                    this.transform.position = new Vector3(a.angriffsLand % 100 * 100 - 50, 10, 550 - ((a.angriffsLand - a.angriffsLand % 100)));
                }
                if(a.map == 2)
                {
                    this.transform.position = new Vector3(a.angriffsLand % 100 * 100 - 50, 10, 1450 - ((a.angriffsLand - a.angriffsLand % 100)));
                }
                if (a.kampagneMap == 1)
                {
                    this.transform.position = new Vector3(a.angriffsLand % 100 * 100 - 50, 10, 1150 - ((a.angriffsLand - a.angriffsLand % 100)));
                }
            }
            else if(!a.KIamZug)
            {
                    a.angriffsLand = 0;
                    a.verteidigungsLand = 0;
            }
        }
        if (a.verteidigungsLand != a.angriffsLand && a.anDerReihe == a.spielerLand[a.angriffsLand] || a.zugGemacht)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            if (a.angreifen)
            {
                if (!a.bogenschützenAngriff && !a.KIamZug)
                {
                    a.angriffsLand = 0;
                   a.verteidigungsLand = 0;
                }
                else
                {
                    if (!a.zugGemacht && a.spielerLand[a.verteidigungsLand] != 0 && a.bogenschützen[a.angriffsLand] > 0 && !a.KIamZug)
                    {
                        a.verteidigungsLand = 0;
                        this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                        transform.LookAt(hit.point);
                    }
                }
            }
            if (a.verschieben && !a.KIamZug)
            {
               a.verteidigungsLand = a.angriffsLand;
            }
        }
    }
}
