using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canvas : MonoBehaviour
{
    public GameObject mainCamera;
    private mainScript a;
    public bool anDerReihe;
    public Text text;
    public bool angreifen;
    public bool bauen;
    public bool verschieben;
    public bool gold;
    public bool länder;
    public bool rathäuser;
    public bool ausbilden;
    public bool truppenAusgewählt;
    public bool zeit;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    public bool spieler1;
    public bool spieler2;
    public bool spieler3;
    public bool spieler4;
    public bool verloren;
    public bool gewonnen;
    public bool runde;
    public GameObject panel;
    public int verlorenAnzeigen;
    public bool überspringen;
    // Use this for initialization
    void Start()
    {
        a = mainCamera.GetComponent<mainScript>();
        if (anDerReihe || gold || rathäuser || länder || zeit || spieler1 || spieler2 || spieler3 || spieler4 || runde)
        {
            text = GetComponent<Text>();
        }
        if (spieler1)
        {
            text.text = "Spieler1";
        }
        if (spieler2)
        {
            text.text = "Spieler2";
        }
        if (spieler3)
        {
            text.text = "Spieler3";
        }
        if (spieler4)
        {
            text.text = "Spieler4";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (verloren)
        {
            panel.gameObject.SetActive(false);
            if (a.los)
            {
                for (int i = 0; i < a.spieler + 1; i++)
                {
                    a.rathäuser[i] = 0;
                    for (int c = 1; c < 15; c++)
                    {
                        for (int t = 1; t < 15; t++)
                        {
                            if (a.spielerLand[c * 100 + t] == i)
                            {
                                if (a.rathaus[c * 100 + t] != 0)
                                {
                                    a.rathäuser[i]++;
                                }
                            }
                        }
                    }
                    if (a.spielerVerloren[i] == 1 && i > 0)
                    {
                        panel.gameObject.SetActive(true);
                    }
                    if (a.spielerVerloren[i] == 1)
                    {
                        if (i == 1)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler1 + " hat verloren!";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 2)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler2 + " hat verloren!";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 3 && a.spieler > 2)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler3 + " hat verloren!";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 4 && a.spieler > 3)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler4 + " hat verloren!";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        verlorenAnzeigen = a.spieler + 1;
                    }
                    else
                    {
                        if (verlorenAnzeigen <= 0)
                        {
                            if (a.spielerVerloren[i] == 2)
                            {
                                this.transform.position = new Vector3(Screen.width * 2, Screen.height / 2, 0);
                            }
                            if (a.spielerVerloren[i] == 0 && a.los)
                            {
                                if (a.rathäuser[i] == 0)
                                {
                                  //  a.spielerVerloren[i] = 1;
                                }
                            }
                        }
                        else
                        {
                            verlorenAnzeigen--;
                        }
                    }
                }
            }
        }
        if (gewonnen && a.los)
        {
            int spielerLeben = 0;
            for (int i = 1; i < a.spieler + 1; i++)
            {
                if (a.spielerVerloren[i] == 0)
                {
                    spielerLeben++;
                }
            }
            if (spielerLeben == 1)
            {
                for (int i = 0; i < a.spieler + 1; i++)
                {
                    if (a.spielerVerloren[i] == 0)
                    {
                        panel.gameObject.SetActive(true);
                        if (i == 1)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler1 + " hat Gewonnen";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 2)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler2 + " hat Gewonnen";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 3)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler3 + " hat Gewonnen";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                        if (i == 4)
                        {
                            this.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = a.spieler4 + " hat Gewonnen";
                            this.transform.position = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                        }
                    }
                }
            }
            else
            {
                this.transform.position = new Vector3(Screen.width * 2, Screen.height / 2, 0);
            }
        }
        if (spieler1 || spieler2 || spieler3 || spieler4)
        {
            if (spieler1)
            {
                a.spieler1 = text.text;
            }
            if (spieler2)
            {
                a.spieler2 = text.text;
            }
            if (spieler3)
            {
                a.spieler3 = text.text;
            }
            if (spieler4)
            {
                a.spieler4 = text.text;
            }
        }
        if (gold)
        {
            text.text = "Gold: " + a.gold[a.anDerReihe];
        }
        if (länder)
        {
            text.text = "Länder: " + a.länder[a.anDerReihe];
        }
        if (rathäuser)
        {
            text.text = "Rathäuser: " + a.rathäuser[a.anDerReihe];
        }
        if (zeit)
        {
            secondsCount += Time.deltaTime;
            text.text = hourCount + ":" + minuteCount + ":" + (int)secondsCount;
            if (secondsCount < 10)
            {
                text.text = hourCount + ":" + minuteCount + ":0" + (int)secondsCount;
            }
            if (minuteCount < 10)
            {
                text.text = hourCount + ":0" + minuteCount + ":" + (int)secondsCount;
                if (secondsCount < 10)
                {
                    text.text = hourCount + ":0" + minuteCount + ":0" + (int)secondsCount;
                }
            }
            if (hourCount < 10)
            {
                text.text = "0" + hourCount + ":" + minuteCount + ":" + (int)secondsCount;
                if (minuteCount < 10)
                {
                    text.text = "0" + hourCount + ":0" + minuteCount + ":" + (int)secondsCount;
                    if (secondsCount < 10)
                    {
                        text.text = "0" + hourCount + ":0" + minuteCount + ":0" + (int)secondsCount;
                    }
                }else if (secondsCount < 10)
                {
                    text.text = "0" + hourCount + minuteCount + ":0" + (int)secondsCount;
                }

            }
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }
            else if (minuteCount >= 60)
            {
                hourCount++;
                minuteCount = 0;
            }
        }
        if (anDerReihe)
        {
            if (a.anDerReihe == 1)
            {
                text.text = a.spieler1;
                text.text += " (rot)";
            }
            if (a.anDerReihe == 2)
            {
                text.text = a.spieler2;
                text.text += " (blau)";
            }
            if (a.anDerReihe == 3)
            {
                text.text = a.spieler3;
                text.text += " (grün)";
            }
            if (a.anDerReihe == 4)
            {
                text.text = a.spieler4;
                text.text += " (schw.)";
            }
        }
        if (runde)
        {
            text.text = "Runde: " + a.runde;
        }
        if (angreifen)
        {
            this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 7, 0);
            this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.5f, 0);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(4).gameObject.SetActive(false);

            if (!a.angreifen && !a.bauen && !a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
            }
            if (a.angreifen)
            {
                if (!a.aGewonnen)
                {
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                }
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                if (!a.bogenschützenAngriff && !a.standardAngriff)
                {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.position = this.gameObject.transform.GetChild(1).transform.position - new Vector3(0, Screen.height / 10f, 0);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.transform.position = this.gameObject.transform.GetChild(2).transform.position - new Vector3(0, Screen.height / 10f, 0);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
                    if (a.rasse[a.anDerReihe - 1] == 3)
                    {
                        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(3).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.transform.position = this.gameObject.transform.GetChild(3).transform.position - new Vector3(0, Screen.height / 7f, 0);
                        this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 3.95f, 0);
                        this.gameObject.transform.GetChild(3).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.25f, 0);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.transform.position = this.gameObject.transform.GetChild(2).transform.position - new Vector3(0, Screen.height / 10f, 0);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.position = this.gameObject.transform.GetChild(1).transform.position - new Vector3(0, Screen.height / 15f, 0);
                    }
                    if (a.rasse[a.anDerReihe - 1] == 2)
                    {
                        this.gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.transform.position = this.gameObject.transform.GetChild(4).transform.position - new Vector3(0, Screen.height / 7f, 0);
                        this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 3.95f, 0);
                        this.gameObject.transform.GetChild(4).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.25f, 0);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.transform.position = this.gameObject.transform.GetChild(2).transform.position - new Vector3(0, Screen.height / 10f, 0);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.transform.position = this.gameObject.transform.GetChild(1).transform.position - new Vector3(0, Screen.height / 15f, 0);
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(4).gameObject.SetActive(false);

                    }
                }
                else
                {
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
                }
                if (a.bogenschützenAngriff)
                {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                }
                if (a.standardAngriff)
                {
                    if (a.verteidigungsLand != 0 && a.angriffsLand != a.verteidigungsLand)
                    {
                        // a.plündderLand = a.verteidigungsLand;
                    }
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                    if (a.aGewonnen)
                    {
                        if (!a.gebäudeErhalten && !a.gebäudePlündern)
                        {
                            if (a.kaserne[a.plündderLand] + a.rathaus[a.plündderLand] + a.kaserne[a.zweitesAngriffsLand] + a.rathaus[a.zweitesAngriffsLand] > 0)
                            {
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 5, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.5f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Plündern: " + ((a.rathaus[a.plündderLand] * 20 + a.kaserne[a.plündderLand] * 15) + (a.rathaus[a.zweitesAngriffsLand] * 20 + a.kaserne[a.zweitesAngriffsLand] * 15)) + "G";
                            }
                        }
                        if (a.gebäudePlündern)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 5, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Geplündert";
                        }
                        if (a.gebäudeErhalten)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 5, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Erhalten";
                        }
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    }
                }
            }
            if (a.bauen || a.verschieben || a.ausbilden)
            {
                this.transform.position = new Vector3(10000, 90, 0);
            }
            if (a.angreifen && a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
            }
        }
        if (ausbilden)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(4).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(5).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(6).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(7).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(8).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(9).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(10).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(11).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(12).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(13).gameObject.SetActive(false);
            this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.55f, 0);
            if (a.ausbilden && !a.zugGemacht)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                if (a.ausbilLand == 0)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    this.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Platz: " + (a.bogiesAusbilden * 2 + a.babosAusbilden + a.reiterAusbilden * 2) + "/" + a.kaserne[a.ausbilLand] * 3;
                    this.transform.GetChild(3).gameObject.GetComponent<Text>().text = "Bogenschützen: " + a.bogiesAusbilden;
                    this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(6).gameObject.SetActive(true);
                    this.transform.GetChild(6).gameObject.GetComponent<Text>().text = "Babaren: " + a.babosAusbilden;
                    this.gameObject.transform.GetChild(7).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(8).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(9).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(10).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(11).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(12).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(9).gameObject.GetComponent<Text>().text = "Reiter: " + a.reiterAusbilden;
                    if (a.rasse[a.anDerReihe - 1] == 0)
                    {
                        this.gameObject.transform.GetChild(12).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (a.bogiesAusbilden * 15 + a.babosAusbilden * 10 + a.reiterAusbilden * 25) + "G";
                    }
                    if (a.rasse[a.anDerReihe - 1] == 1)
                    {
                        this.gameObject.transform.GetChild(12).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (a.bogiesAusbilden * 15 + a.babosAusbilden * 10 + a.reiterAusbilden * 20) + "G";
                    }
                    if (a.rasse[a.anDerReihe - 1] == 2)
                    {
                        this.gameObject.transform.GetChild(12).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (a.bogiesAusbilden * 15 + a.babosAusbilden * 7 + a.reiterAusbilden * 25) + "G";
                    }
                    if (a.rasse[a.anDerReihe - 1] == 3)
                    {
                        this.gameObject.transform.GetChild(12).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "" + (a.bogiesAusbilden * 12 + a.babosAusbilden * 10 + a.reiterAusbilden * 25) + "G";
                    }
                }
            }
            if (a.ausbilden && a.zugGemacht)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                this.gameObject.transform.GetChild(13).gameObject.SetActive(true);
            }
            if (a.bauen || a.verschieben || a.angreifen)
            {
                this.transform.position = new Vector3(10000, 90, 0);
            }
        }
        if (bauen)
        {
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(7).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(2).gameObject.SetActive(false);

            if (!a.angreifen && !a.bauen && !a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.35f, 0);
            }
            if (a.bauen)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                if (!a.bauenZufällig && !a.bauenGezielt)
                {
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 7, 0);
                    this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.5f, 0);
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
                else
                {
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                }
                if (a.bauenGezielt)
                {
                    this.gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    if (a.rasse[a.anDerReihe - 1] == 0)
                    {
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rathaus: 20G";
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Kaserne: 25G";
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Straße: 15G";
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Rathaus: 30G";
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Kaserne: 40G";
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = "Straße: 25G";
                    }
                    if (a.gebäude == 0)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(true);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
                        if (a.rasse[a.anDerReihe - 1] != 0)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 3.5f, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.5f, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).transform.position = this.transform.position - new Vector3(0, Screen.height / 1.95f, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
                        }
                        else
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
                            if (a.spezialfähigkeitFrei[a.anDerReihe] == 1)
                            {
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(true);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 4.75f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 3.5f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.75f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.275f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).transform.position = this.transform.position - new Vector3(0, Screen.height / 1.93f, 0);
                            }
                            else
                            {
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 3.5f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.75f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).transform.position = this.transform.position - new Vector3(0, Screen.height / 2.275f, 0);
                                this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).transform.position = this.transform.position - new Vector3(0, Screen.height / 1.93f, 0);
                            }
                        }
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
                        this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(4).gameObject.SetActive(false);
                        if (a.gebäude == 1)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(1).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        }
                        if (a.gebäude == 2)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).gameObject.SetActive(true);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        }
                        if (a.gebäude == 3)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).gameObject.SetActive(true);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(3).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        }
                        if (a.gebäude == 4)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(true);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(7).gameObject.SetActive(true);
                        }
                        if (a.gebäude == 5)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(true);
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                        }
                        if (a.zugGemacht)
                        {
                            this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(7).gameObject.SetActive(false);
                        }
                    }
                }
                else
                {
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(5).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(1).gameObject.transform.GetChild(6).gameObject.SetActive(false);
                }
                if (a.bauenZufällig)
                {
                    this.gameObject.transform.GetChild(2).transform.position = this.transform.position - new Vector3(0, Screen.height / 10, 0);
                    this.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                    this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                    if (!a.einmalGebäude)
                    {
                        a.einmalGebäude = true;
                        a.gebäude = Random.Range(1, 5);
                        if (a.gebäude == 1)
                        {
                            a.Rathaustatistik[a.anDerReihe]++;
                        }
                        if (a.gebäude == 2)
                        {
                            a.KasernenStatistik[a.anDerReihe]++;
                        }
                        if (a.gebäude == 3)
                        {
                            a.StraßenStatistik[a.anDerReihe]++;
                        }
                        if (a.gebäude == 4)
                        {
                            a.gebäude = 6;
                            a.NietenStatistik[a.anDerReihe]++;
                        }
                    }
                    this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(2).gameObject.SetActive(false);
                    this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                    if (a.gebäude == 1)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Du hast ein Rathaus\ngewürfelt";
                    }
                    if (a.gebäude == 2)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Du hast eine Kaserne\ngewürfelt";
                    }
                    if (a.gebäude == 3)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Du hast ein Straße\ngewürfelt";
                    }
                    if (a.gebäude == 6)
                    {
                        this.gameObject.transform.GetChild(2).gameObject.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Du hast eine Niete\ngewürfelt";
                    }
                }
            }
            if (a.angreifen || a.verschieben || a.ausbilden)
            {
                this.transform.position = new Vector3(10000, 90, 0);
            }
        }
        if (verschieben)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
            if (!a.angreifen && !a.bauen && !a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.15f, 0);
            }
            if (a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                if (!a.zugGemacht)
                {
                    if (a.angriffsLand == 0)
                    {
                        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        this.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wähle das Land aus, vom dem du deine Truppen verschieben möchtest";
                    }
                    else
                    {
                        this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                        this.transform.GetChild(1).gameObject.GetComponent<Text>().text = "Wähle das Land aus, in das du deine Truppen verschieben möchtsest";
                    }
                }
            }
            if (a.angreifen || a.bauen || a.ausbilden)
            {
                this.transform.position = new Vector3(10000, 90, 0);
            }
            if (a.angreifen && a.verschieben)
            {
                this.transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.65f, 0);
            }
        }
        if (überspringen)
        {
            if (a.isPause && a.los)
            {
                this.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * 0.6f, 0);
            }
            else
            {
                this.transform.position = new Vector3(Screen.width * 50f, Screen.height * 0.65f, 0);
            }
        }
    }
}
