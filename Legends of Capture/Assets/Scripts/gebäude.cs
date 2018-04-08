using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gebäude : MonoBehaviour
{
    public GameObject mainCamera;
    private mainScript a;
    public bool rathaus;
    public bool kaserne;
    public bool straße;
    public int land;
    public GameObject rathausMensch;
    public GameObject rathausOrk;
    public GameObject rathausElf;
    public GameObject rathausUntote;
    public GameObject KaserneMensch;
    public GameObject KaserneOrk;
    public GameObject KaserneElf;
    public GameObject KaserneUntote;
    public GameObject Kaserne;
    int mapDistance;
    public GameObject Rathaus;
    // Use this for initialization
    void Start()
    {
        a = mainCamera.GetComponent<mainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a.map == 1)
        {
            mapDistance = 550;
        }
        if (a.map == 2)
        {
            mapDistance = 1450;
        }
        if (this.transform.name != "Kaserne" && this.transform.name != "Rathaus" && this.transform.name != "Straße")
        {
            if (kaserne && a.kaserne[land] == 0)
            {
               Destroy(this.gameObject);
            }
            if (rathaus && a.rathaus[land] == 0)
            {
                Destroy(this.gameObject);
            }
            if (straße && a.straße[land] == 0)
            {
                a.Straßen[a.spielerLand[land]] --;
                Debug.Log("AnderReihe: " + a.spielerLand[land]);
               // Destroy(this.gameObject);
            }
        }

        else if (a.gebäude != 0 && !a.zugGemacht)
        {
            if (this.transform.name == "Rathaus" && rathaus && a.gebäude == 1)
            {
                if (a.rasse[a.anDerReihe - 1] == 0)
                {
                    Rathaus = rathausMensch;
                }
                if (a.rasse[a.anDerReihe - 1] == 1)
                {
                    Rathaus = rathausOrk;
                }
                if (a.rasse[a.anDerReihe - 1] == 2)
                {
                    Rathaus = rathausUntote;
                }
                if (a.rasse[a.anDerReihe - 1] == 3)
                {
                    Rathaus = rathausElf;
                }
                land = a.getLand();
                if (a.spielerLandWählen <= a.spieler && a.spielerLand[a.getLand()] == 0 && a.getLand() != 0 && a.landAuswählen)
                {
                    if (a.rasse[a.spielerLandWählen - 1] == 0)
                    {
                        Rathaus = rathausMensch;
                    }
                    if (a.rasse[a.spielerLandWählen - 1] == 1)
                    {
                        Rathaus = rathausOrk;
                    }
                    if (a.rasse[a.spielerLandWählen - 1] == 2)
                    {
                        Rathaus = rathausUntote;
                    }
                    if (a.rasse[a.spielerLandWählen - 1] == 3)
                    {
                        Rathaus = rathausElf;
                    }
                    Rathaus.GetComponent<gebäude>().mainCamera = mainCamera;
                    Rathaus.GetComponent<gebäude>().land = land;
                    Instantiate(Rathaus, new Vector3(land % 100 * 100 - 50, 6, mapDistance - ((a.land - a.land % 100))), this.transform.rotation);
                    a.rathaus[land] = 1;
                    a.anDerReihe++;
                }
                if (land != 0 && a.rathaus[land] == 0 && a.spielerLand[land] == a.anDerReihe)
                {
                    Rathaus.GetComponent<gebäude>().mainCamera = mainCamera;
                    Rathaus.GetComponent<gebäude>().land = land;
                    Instantiate(Rathaus, new Vector3(land % 100 * 100 - 50, 6, mapDistance - ((a.land - a.land % 100))), this.transform.rotation);
                    a.rathaus[land] = 1;
                    a.zugGemacht = true;
                }
            }
            if (this.transform.name == "Kaserne" && kaserne && a.gebäude == 2)
            {
                if (a.rasse[a.anDerReihe - 1] == 0)
                {
                    Kaserne = KaserneMensch;
                }
                if (a.rasse[a.anDerReihe - 1] == 1)
                {
                    Kaserne = KaserneOrk;
                }
                if (a.rasse[a.anDerReihe - 1] == 2)
                {
                    Kaserne = KaserneUntote;
                }
                if (a.rasse[a.anDerReihe - 1] == 3)
                {
                    Kaserne = KaserneElf;
                }
                land = a.getLand();
                if (land != 0 && a.kaserne[land] < 4 && a.spielerLand[land] == a.anDerReihe)
                {
                    Kaserne.GetComponent<gebäude>().mainCamera = mainCamera;
                    Kaserne.GetComponent<gebäude>().land = land;
                    if (a.kaserne[land] == 0)
                    {
                        Instantiate(Kaserne, new Vector3(land % 100 * 100 - 75, 1, mapDistance - ((a.land - a.land % 100) - 25)), this.transform.rotation);
                    }
                    if (a.kaserne[land] == 1)
                    {
                        Instantiate(Kaserne, new Vector3(land % 100 * 100 - 25, 1, mapDistance - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, 90, 0));
                    }
                    if (a.kaserne[land] == 2)
                    {
                        Instantiate(Kaserne, new Vector3(land % 100 * 100 - 25, 1, mapDistance - 50 - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, 180, 0));
                    }
                    if (a.kaserne[land] == 3)
                    {
                        Instantiate(Kaserne, new Vector3(land % 100 * 100 - 75, 1, mapDistance - 50 - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, -90, 0));
                    }
                    a.kaserne[land]++;
                    a.zugGemacht = true;
                }
            }
        }
    }
}

