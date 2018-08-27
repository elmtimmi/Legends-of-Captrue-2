using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class straße : MonoBehaviour
{
    public GameObject Straße;
    public GameObject mainCamera;
    private mainScript a;
    public int land1;
    public int land2;
    int mapDistance;
    // Use this for initialization
    void Start()
    {
        a = mainCamera.GetComponent<mainScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (a.map == 1)
        {
            mapDistance = 550;
        }
        if (a.map == 2)
        {
            mapDistance = 1450;
        }
        if (a.kampagneMap == 1)
        {
            mapDistance = 1150;
        }
        if (this.transform.name == "StraßenDouble(Clone)")
        {
            if(a.straße[land1] == 0)
            {
                a.Straßen[a.spielerLand[land2]] --;
                Debug.Log("AnderReihe: " + a.spielerLand[land2]);
                Destroy(this.gameObject);
            }
            if (a.straße[land2] == 0)
            {
                a.Straßen[a.spielerLand[land1]]--;
                Debug.Log("AnderReihe: " + a.spielerLand[land1]);
                Destroy(this.gameObject);
            }
        }
        if (this.transform.name == "Straße")
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                hit.point = new Vector3(hit.point.x, 0, hit.point.z);
            if (a.StraßenLand2 == 0)
            {
                transform.LookAt(hit.point);
            }
            if (a.StraßenLand1 == 0)
            {
                this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                if (a.anDerReihe == a.spielerLand[a.StraßenLand1] && a.zugGemacht == false)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
                    this.transform.position = new Vector3(a.StraßenLand1 % 100 * 100 - 50, 10, mapDistance - ((a.StraßenLand1 - a.StraßenLand1 % 100)));
                    if (a.spielerLand[a.StraßenLand2] == a.anDerReihe)
                    {
                        Debug.Log(a.StraßenLand2);
                        if (a.StraßenLand2 == a.StraßenLand1 - 100 || a.StraßenLand2 == a.StraßenLand1 + 1 || a.StraßenLand2 == a.StraßenLand1 - 1 || a.StraßenLand2 == a.StraßenLand1 + 100)
                        {
                            a.Straßen[a.anDerReihe]++;
                            Straße.GetComponent<straße>().land1 = a.StraßenLand1;
                            Straße.GetComponent<straße>().land2 = a.StraßenLand2;
                            transform.LookAt(new Vector3(a.StraßenLand2 % 100 * 100 - 50, 10, mapDistance - ((a.StraßenLand2 - a.StraßenLand2 % 100))));
                            Instantiate(Straße, this.transform.position - new Vector3(0, 10, 0), this.transform.rotation);
                            a.zugGemacht = true;
                            a.straße[a.StraßenLand1] += 1;
                            a.straße[a.StraßenLand2] += 1;
                            a.StraßenLand1 = 0;
                            a.StraßenLand2 = 0;
                        }
                    }
                }
                else
                {
                    a.StraßenLand1 = 0;
                    a.StraßenLand2 = 0;
                }
            }
        }
    }
}

