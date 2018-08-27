﻿using System.Collections;
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
    bool einmalKampagne;
    public GameObject Rathaus;
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
                a.Straßen[a.spielerLand[land]]--;
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
                if (!a.los && a.kampagneMap == 0 || !a.los)
                {
                    land = a.getLand();
                }
                else
                {
                    land = a.land;
                }
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
                    Instantiate(Rathaus, new Vector3(land % 100 * 100 - 50, 6, mapDistance - ((land - land % 100))), this.transform.rotation);
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
                if (!a.los && a.kampagneMap == 0)
                {
                    land = a.getLand();
                }
                else
                {
                    land = a.land;
                }
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
            if (a.los && !einmalKampagne && a.kampagneMap == 1)
            {
                a.babaren[903] = 3;
                a.babaren[905] = 3;
                a.babaren[703] = 10;
                a.babaren[705] = 10;
                a.bogenschützen[401] = 5;
                a.bogenschützen[402] = 5;
                a.bogenschützen[406] = 5;
                a.bogenschützen[407] = 5;
                a.babaren[401] = 3;
                a.babaren[402] = 3;
                a.babaren[406] = 3;
                a.babaren[407] = 3;
                a.babaren[202] = 10;
                a.babaren[206] = 10;
                einmalKampagne = true;
                if (rathausMensch != null)
                {
                    Rathaus = rathausMensch;

                    for (int i = 0; i < 7; i++)
                    {
                        land = 101 + i;
                        a.land = 101 + i;
                        RathausBauen();
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        land = 201 + i;
                        a.land = 201 + i;
                        RathausBauen();
                    }
                    for (int i = 0; i < 7; i++)
                    {
                        land = 301 + i;
                        a.land = 301 + i;
                        RathausBauen();
                    }
                    for (int i = 0; i < 2; i++)
                    {
                        land = 401 + i;
                        a.land = 401 + i;
                        RathausBauen();
                    }
                    for (int i = 5; i < 7; i++)
                    {
                        land = 401 + i;
                        a.land = 401 + i;
                        RathausBauen();
                    }
                    for (int i = 0; i < 3; i++)
                    {
                        land = 701 + i;
                        a.land = 701 + i;
                        RathausBauen();
                    }
                    for (int i = 4; i < 7; i++)
                    {
                        land = 701 + i;
                        a.land = 701 + i;
                        RathausBauen();
                    }
                    for (int i = 1; i < 3; i++)
                    {
                        land = 801 + i;
                        a.land = 801 + i;
                        RathausBauen();
                    }
                    for (int i = 4; i < 6; i++)
                    {
                        land = 801 + i;
                        a.land = 801 + i;
                        RathausBauen();
                    }
                    for (int i = 1; i < 3; i++)
                    {
                        land = 901 + i;
                        a.land = 901 + i;
                        RathausBauen();
                    }
                    for (int i = 4; i < 6; i++)
                    {
                        land = 901 + i;
                        a.land = 901 + i;
                        RathausBauen();
                    }
                }
                if (Kaserne != null)
                {
                    Kaserne = KaserneMensch;
                    land = 703;
                    a.land = 703;
                    KaserneBauen();
                    land = 705;
                    a.land = 705;
                    KaserneBauen();
                    land = 202;
                    a.land = 202;
                    KaserneBauen();
                    land = 202;
                    a.land = 202;
                    KaserneBauen();
                    land = 206;
                    a.land = 206;
                    KaserneBauen();
                }
            }
        }
    }
    public void RathausBauen()
    {
        if (a.rasse[a.anDerReihe - 1] == 0 || einmalKampagne)
        {
            Rathaus = rathausMensch;
        }else
        if (a.rasse[a.anDerReihe - 1] == 1)
        {
            Rathaus = rathausOrk;
        }else
        if (a.rasse[a.anDerReihe - 1] == 2)
        {
            Rathaus = rathausUntote;
        }else
        if (a.rasse[a.anDerReihe - 1] == 3)
        {
            Rathaus = rathausElf;
        }
        GameObject Rathauss = null;
        Rathaus.GetComponent<gebäude>().land = land;
        Rathauss = Instantiate(Rathaus, new Vector3(land % 100 * 100 - 50, 6, mapDistance - ((a.land - a.land % 100))), this.transform.rotation);
        a.rathaus[land] = 1;
        Rathauss.GetComponent<gebäude>().mainCamera = mainCamera;
    }
    public void KaserneBauen()
    {
        GameObject Karsernee = null;
        Kaserne.GetComponent<gebäude>().mainCamera = mainCamera;
        Kaserne.GetComponent<gebäude>().land = land;
        Karsernee = Instantiate(Kaserne, new Vector3(land % 100 * 100 - 75, 1, mapDistance - ((a.land - a.land % 100) - 25)), this.transform.rotation);
        Karsernee = Instantiate(Kaserne, new Vector3(land % 100 * 100 - 25, 1, mapDistance - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, 90, 0));
        Karsernee = Instantiate(Kaserne, new Vector3(land % 100 * 100 - 25, 1, mapDistance - 50 - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, 180, 0));
        Karsernee = Instantiate(Kaserne, new Vector3(land % 100 * 100 - 75, 1, mapDistance - 50 - ((a.land - a.land % 100) - 25)), Quaternion.Euler(0, -90, 0));
        a.kaserne[land] = 4;
        Karsernee.GetComponent<gebäude>().mainCamera = mainCamera;
    }
}

