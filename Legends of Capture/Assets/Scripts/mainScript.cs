using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//sdk: https://forum.unity.com/threads/where-is-the-android-sdk-located.467686/
// ordner: C:\Users\Tim\Downloads\tools_r25.2.5-windows
// jdk: C:/Program Files/Java/jdk-9.0.1
public class mainScript : MonoBehaviour
{
    public bool pc;
    public Rigidbody rb;
    int speed = 120;
    public int anDerReihe;
    public int spieler;
    public string spieler1;
    public string spieler2;
    public string spieler3;
    public string spieler4;
    public int land;
    public bool los;
    public int map;
    public bool landAuswählen;
    public float[] babaren;
    public float[] bogenschützen;
    public float[] reiter;
    public int[] spielerLand;
    public int[] rathaus;
    public int[] kaserne;
    public int[] straße;
    public int[] gold;
    public int[] länder;
    public int[] rathäuser;
    public int[] rasse;
    public int[] mauerLand;
    public bool angreifen;
    public bool bauen;
    public bool verschieben;
    public bool ausbilden;
    public bool standardAngriff;
    public bool bogenschützenAngriff;
    public int angriffsLand;
    public int verteidigungsLand;
    public int StraßenLand1;
    public int StraßenLand2;
    public bool zugGemacht;
    public int[] spielerVerloren;
    public int[] spezialfähigkeitFrei;
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public GameObject canvasstatistik;
    public GameObject mauer;
    public GameObject Mauer;
    public int spielerLandWählen;
    bool einmal;
    int voherigerAngreifer;
    Vector3 position1;
    Vector3 position2;
    Vector3 position3;
    Vector3 position4;
    bool einmalWechseln;
    bool einmalRathausTruppe;
    public float VBogies;
    public float VBabos;
    public int VReiter;
    public bool aGewonnen;
    public bool bauenZufällig;
    public bool bauenGezielt;
    public int gebäude;
    public bool einmalGebäude;
    public int Zuffalspreis;
    public int ausbilLand;
    public int bogiesAusbilden;
    public int babosAusbilden;
    public int reiterAusbilden;
    public bool einmalAusbilden;
    public int altesLand;
    public bool gebäudePlündern;
    public bool gebäudeErhalten;
    public int plündderLand;
    public bool goldbekommen;
    public bool zweiZüge;
    bool einmalCamera;
    public int einmalRot;
    public string[] rassen;
    public bool gecklickt;
    public bool pfeihagel;
    public bool clonen;
    public int reiterVerschoben;
    public int reiterLand;
    public int zweiterAngriff;
    public float stayBabos;
    public float stayBogies;
    public int speicherVerteidigungsLand;
    public bool reiterBeschwören;
    public bool isPause;
    public bool regeln;
    public int runde;
    public Vector3 mausPosition;
    public int zweitesAngriffsLand;
    public int doppelKlick;
    public int[] landNichtAngreifen;
    public int zahlAngriff;
    public bool mauergebaut;
    public int merkeLand;
    public bool statistik;
    public GameObject map1;
    public GameObject map2;
    // Statistik Arrays
    public int[] Kasernen;
    public int[] Straßen;
    public int[] Rathaustatistik;
    public int[] KasernenStatistik;
    public int[] StraßenStatistik;
    public int[] NietenStatistik;
    public int[] gewonnendeAngriffe;
    public int[] verlorendeAngriffe;
    public int[] Bogenschützenangriffe;
    public int[] BogenschützenangriffTote;
    public int[] Angrifftote;
    public int[] gestorbeneTruppen;
    public int[] ausgebildeteTruppen;

    void Start()
    {
        babaren = new float[1414];
        bogenschützen = new float[1414];
        reiter = new float[1414];
        spielerLand = new int[1414];
        rathaus = new int[1414];
        kaserne = new int[1414];
        straße = new int[1414];
        mauerLand = new int[1414];
        rasse = new int[5];
        rassen = new string[5];
        gold = new int[5];
        länder = new int[5];
        rathäuser = new int[5];
        Kasernen = new int[5];
        Straßen = new int[5];
        spezialfähigkeitFrei = new int[5];
        spielerVerloren = new int[5];
        landNichtAngreifen = new int[3];
        rathäuser = new int[5];
        rb = this.GetComponent<Rigidbody>();
        spieler = 2;
        anDerReihe = 1;
        spielerLandWählen = 1;
        position1 = new Vector3(230, 160, 25);
        position2 = new Vector3(230, 160, 25);
        position3 = new Vector3(230, 160, 25);
        position4 = new Vector3(230, 160, 25);

        Rathaustatistik = new int[5];
        KasernenStatistik = new int[5];
        StraßenStatistik = new int[5];
        NietenStatistik = new int[5];
        gewonnendeAngriffe = new int[5];
        verlorendeAngriffe = new int[5];
        Bogenschützenangriffe = new int[5];
        BogenschützenangriffTote = new int[5];
        Angrifftote = new int[5];
        gestorbeneTruppen = new int[5];
        ausgebildeteTruppen = new int[5];
        canvasstatistik.gameObject.SetActive(false);

    }

    // Update is called once per frame
    private void Awake()
    {
        Zuffalspreis = 10;
        map = 1;
    }
    private void FixedUpdate()
    {
        doppelKlick++;
    }
    void Update()
    {
        Debug.Log("getland: " + getLand());
        rassen[0] = "Mensch";
        rassen[1] = "Ork";
        rassen[2] = "Untote";
        rassen[3] = "Elf";
        if (!los)
        {
            this.transform.rotation = Quaternion.Euler(90, 0, 0);
            if (map == 1)
            {
                map1.SetActive(true);
                map2.SetActive(false);
                this.transform.position = new Vector3(340, 500, 260);
            }
            if (map == 2)
            {
                map2.SetActive(true);
                map1.SetActive(false);
                this.transform.position = new Vector3(this.transform.position.x, 500, this.transform.position.z);
            }
            gebäude = 1;
            canvas1.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(true);
            canvas3.gameObject.SetActive(false);
            //canvas2.transform.GetChild(9).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = rassen[rasse[0]];
            //  canvas2.transform.GetChild(10).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = rassen[rasse[1]];
            ////  canvas2.transform.GetChild(11).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = rassen[rasse[2]];
            //  canvas2.transform.GetChild(12).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = rassen[rasse[3]];
            for (int i = 0; i < 4; i++)
            {
                if (canvas2.transform.GetChild(9 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Mensch")
                {
                    rasse[i] = 0;
                }
                if (canvas2.transform.GetChild(9 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Ork")
                {
                    rasse[i] = 1;
                }
                if (canvas2.transform.GetChild(9 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Untote")
                {
                    rasse[i] = 2;
                }
                if (canvas2.transform.GetChild(9 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Elf")
                {
                    rasse[i] = 3;
                }
                if (canvas2.transform.GetChild(9 + i).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text == "Zufällig" && !landAuswählen)
                {
                    rasse[i] = Random.Range(0, 4);
                }
            }
            if (spieler > 2)
            {
                canvas2.transform.GetChild(4).gameObject.SetActive(true);
                canvas2.transform.GetChild(6).gameObject.SetActive(false);
                canvas2.transform.GetChild(11).gameObject.SetActive(true);

            }
            else
            {
                canvas2.transform.GetChild(4).gameObject.SetActive(false);
                canvas2.transform.GetChild(6).gameObject.SetActive(true);
                canvas2.transform.GetChild(11).gameObject.SetActive(false);
                canvas2.transform.GetChild(12).gameObject.SetActive(false);

            }
            if (spieler > 3)
            {
                canvas2.transform.GetChild(5).gameObject.SetActive(true);
                canvas2.transform.GetChild(7).gameObject.SetActive(false);
                canvas2.transform.GetChild(8).gameObject.SetActive(true);
                canvas2.transform.GetChild(12).gameObject.SetActive(true);
            }
            else
            {
                canvas2.transform.GetChild(5).gameObject.SetActive(false);
                canvas2.transform.GetChild(7).gameObject.SetActive(true);
                canvas2.transform.GetChild(8).gameObject.SetActive(false);
                canvas2.transform.GetChild(12).gameObject.SetActive(false);

            }
            if (landAuswählen)
            {
                if (spieler1 == "")
                {
                    spieler1 = "Spieler1";
                }
                if (spieler2 == "")
                {
                    spieler2 = "Spieler2";
                }
                if (spieler3 == "")
                {
                    spieler3 = "Spieler3";
                }
                if (spieler4 == "")
                {
                    spieler4 = "Spieler4";
                }
                canvas2.gameObject.SetActive(false);
                canvas3.gameObject.SetActive(true);
                if (spielerLandWählen == 1)
                {
                    canvas3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = spieler1;
                }
                if (spielerLandWählen == 2)
                {
                    canvas3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = spieler2;
                }
                if (spielerLandWählen == 3)
                {
                    canvas3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = spieler3;
                }
                if (spielerLandWählen == 4)
                {
                    canvas3.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>().text = spieler4;
                }
                if (getLand() != 0 && spielerLand[getLand()] == 0)
                {
                    anDerReihe = spielerLandWählen;
                    zugGemacht = false;
                    spielerLand[getLand()] = spielerLandWählen;
                    land = getLand();
                    gebäude = 1;
                    spielerLandWählen++;
                    if (spielerLandWählen == spieler + 1)
                    {
                        los = true;
                    }
                }
            }
        }
        else
        {
            canvas3.gameObject.SetActive(false);
            canvas2.gameObject.SetActive(false);
            canvas1.gameObject.SetActive(true);
            if (!einmalCamera)
            {
                gebäude = 0;
                zugGemacht = false;
                this.transform.position = new Vector3(230, 160, 180);
                einmalCamera = true;
                anDerReihe = 1;
                this.transform.rotation = Quaternion.Euler(55, 0, 0);

            }
            if (Input.GetMouseButtonDown(0) && ausbilLand == 0 && Input.touchCount != 2)
            {

                if (doppelKlick < 10)
                {
                    //         this.transform.position = new Vector3(this.transform.position.x, 160, this.transform.position.z);
                    //    Camera.main.orthographicSize = 5;
                }
                doppelKlick = 0;
            }
            // If there are two touches on the device...
            if (Input.touchCount == 2)
            {
                // Store both touches.
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                // Find the position in the previous frame of each touch.
                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                // Find the magnitude of the vector (the distance) between the touches in each frame.
                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                // Find the difference in the distances between each frame.
                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                if (transform.position.y <= 500 && transform.position.y >= 100)
                {
                    this.transform.position += new Vector3(0, deltaMagnitudeDiff * 0.5f, 0);
                }
                if (transform.position.y > 500)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 500, this.transform.position.z);
                }
                if (transform.position.y < 100)
                {
                    this.transform.position = new Vector3(this.transform.position.x, 100, this.transform.position.z);
                }
            }
        }
        for (int s = 1; s < 5; s++)
        {
            Kasernen[s] = 0;
            länder[s] = 0;
            for (int i = 1; i < 14; i++)
            {
                for (int t = 1; t < 13; t++)
                {
                    if (spielerLand[i * 100 + t] == s)
                    {
                        länder[s]++;
                        if (rathaus[i * 100 + t] != 0)
                        {
                            rathäuser[s]++;
                               Debug.Log("hi: " + rathäuser[s] + "   " + s);
                        }
                        if (kaserne[i * 100 + t] != 0)
                        {
                            Kasernen[s]++;
                        }
                    }
                }
            }
            if (spielerVerloren[s] == 0 && rathäuser[s] == 0 && los)
            {
                spielerVerloren[s] = 1;
                Debug.Log("hi: " + rathäuser[s] + "   " + s);
            }
        }
        if (rathäuser[anDerReihe] == 1 && einmalRot == 0)
        {
            einmalRot = 1;
        }
        if (einmalRot == 1)
        {
            einmalRot = 2;
            anDerReihe = 1;
        }
        if (los && einmalCamera)
        {
            if (rathäuser[anDerReihe] == 0)
            {
                if (spieler > anDerReihe)
                {
                    anDerReihe++;
                }
                else
                {
                    anDerReihe = 1;
                }
            }
        }
        if (!goldbekommen)
        {
            if (spielerVerloren[anDerReihe] == 0)
            {
                if (anDerReihe == 1 && spielerVerloren[1] == 0)
                {
                    runde++;
                }
                else if (anDerReihe == 2 && spielerVerloren[2] == 0 && spielerVerloren[1] != 0)
                {
                    runde++;
                }
                else if (anDerReihe == 3 && spielerVerloren[3] == 0 && spielerVerloren[1] != 0 && spielerVerloren[2] != 0)
                {
                    runde++;
                }
                goldbekommen = true;
                gold[anDerReihe] += 10 + (länder[anDerReihe] / 5) * 10 + rathäuser[anDerReihe] * 2;
            }

        }
        canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).gameObject.SetActive(false);
        if (ausbilden)
        {
            if (spielerLand[getLand()] == anDerReihe && reiterBeschwören && !zugGemacht)
            {
                reiter[getLand()] += 3;
                zugGemacht = true;
            }
            if (spielerLand[getLand()] == anDerReihe && kaserne[getLand()] != 0 && ausbilLand == 0)
            {
                ausbilLand = getLand();
            }
            if (rasse[anDerReihe - 1] == 1 && ausbilLand == 0)
            {
                canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).gameObject.SetActive(true);
                if (!zugGemacht)
                {
                    canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.55f, 0);
                    canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).gameObject.transform.GetChild(1).gameObject.SetActive(true);
                }
                if (reiterBeschwören)
                {
                    canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).transform.position = new Vector3(Screen.width * 0.125f, Screen.height * 0.75f, 0);
                    canvas1.gameObject.transform.GetChild(10).gameObject.transform.GetChild(14).gameObject.transform.GetChild(1).gameObject.SetActive(false);
                }
            }
        }
        if (bauen && !zugGemacht && gebäude == 3)
        {
            if (StraßenLand1 == 0)
            {
                StraßenLand1 = getLand();
            }
            else
            {
                StraßenLand2 = getLand();
            }
        }
        else
        {
            StraßenLand1 = 0;
            StraßenLand2 = 0;
        }
        if (bauen && gebäude == 4)
        {
            if (!gecklickt)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    if (!mauergebaut)
                    {
                        Mauer = Instantiate(mauer, new Vector3(0, 0, 0), Quaternion.identity);
                        mauergebaut = true;
                    }
                Mauer.transform.position = new Vector3(hit.point.x, 0, hit.point.z);
                if (Input.GetMouseButtonDown(1))
                {
                    Mauer.transform.Rotate(0, 90, 0);
                }
                if (Input.GetMouseButtonUp(0) && !gecklickt && mauerLand[getLand()] == 0 && spielerLand[getLand()] == anDerReihe && Input.touchCount != 2)
                {
                    zugGemacht = true;
                    if (map == 1)
                    {
                        Mauer.transform.position = new Vector3(getLand() % 100 * 100 - 50, 0, 550 - ((getLand() - getLand() % 100)));
                    }
                    if (map == 2)
                    {
                        Mauer.transform.position = new Vector3(getLand() % 100 * 100 - 50, 0, 1450 - ((getLand() - getLand() % 100)));
                    }
                    if (Mauer.transform.eulerAngles.y > -2 && Mauer.transform.eulerAngles.y < 2) // oben, 1
                    {
                        Mauer.transform.position += new Vector3(0, 0, 50);
                        mauerLand[getLand()] = 1;
                        gecklickt = true;
                        Mauer.GetComponent<mauer>().gebaut = true;
                    }
                    if (Mauer.transform.eulerAngles.y > 89 && Mauer.transform.eulerAngles.y < 91)// rechts, 2
                    {
                        mauerLand[getLand()] = 2;
                        Mauer.transform.position += new Vector3(50, 0, 0);
                        gecklickt = true;
                        Mauer.GetComponent<mauer>().gebaut = true;
                    }
                    if (Mauer.transform.eulerAngles.y > 179 && Mauer.transform.eulerAngles.y < 181)// unten, 3
                    {
                        Mauer.transform.position += new Vector3(0, 0, -50);
                        mauerLand[getLand()] = 3;
                        gecklickt = true;
                        Mauer.GetComponent<mauer>().gebaut = true;
                    }
                    if (Mauer.transform.eulerAngles.y < 271 && (Mauer.transform.eulerAngles.y > 269)) // links, 4
                    {
                        mauerLand[getLand()] = 4;
                        Mauer.transform.position += new Vector3(-50, 0, 0);
                        gecklickt = true;
                        Mauer.GetComponent<mauer>().gebaut = true;
                    }
                    Mauer.GetComponent<mauer>().mainCamera = this.gameObject;
                    Mauer.GetComponent<mauer>().land = getLand();
                    Mauer.GetComponent<mauer>().spieler = anDerReihe;
                }
            }
        }
        if (gebäude == 6)
        {
            if (Input.GetMouseButtonDown(0) && Input.touchCount != 2)
            {
                zugGemacht = true;
            }
        }
        if (standardAngriff)
        {
            if (angriffsLand == 0)
            {
                angriffsLand = getLand();
            }
            else
            {
                verteidigungsLand = getLand();
            }
            if (!zugGemacht || zweiterAngriff == 0)
            {
                if (landNichtAngreifen[0] != angriffsLand && landNichtAngreifen[1] != angriffsLand && landNichtAngreifen[2] != angriffsLand || zweiterAngriff != 0)
                {
                    if (angriffsLand != verteidigungsLand && spielerLand[angriffsLand] == anDerReihe && spielerLand[verteidigungsLand] != anDerReihe)
                    {
                        if (verteidigungsLand == angriffsLand - 100 && mauerLand[angriffsLand] != 1 && mauerLand[verteidigungsLand] != 3 || verteidigungsLand == angriffsLand + 1 && mauerLand[angriffsLand] != 2 && mauerLand[verteidigungsLand] != 4 || verteidigungsLand == angriffsLand - 1 && mauerLand[angriffsLand] != 4 && mauerLand[verteidigungsLand] != 2 || verteidigungsLand == angriffsLand + 100 && mauerLand[angriffsLand] != 3 && mauerLand[verteidigungsLand] != 1)
                        {
                            if (bogenschützen[angriffsLand] == 0 && babaren[angriffsLand] == 0 && reiter[angriffsLand] == 0 && rathaus[verteidigungsLand] == 1)
                            {
                                verteidigungsLand = angriffsLand;
                            }
                            else
                            {
                                if (zahlAngriff > 2)
                                {
                                    zahlAngriff = 2;
                                }
                                landNichtAngreifen[zahlAngriff] = verteidigungsLand;
                                zahlAngriff++;
                                speicherVerteidigungsLand = verteidigungsLand;
                                if (clonen)
                                {
                                    babaren[angriffsLand] *= 2;
                                }
                                if (zweiterAngriff > 0)
                                {
                                    stayBabos = babaren[angriffsLand];
                                    stayBogies = bogenschützen[angriffsLand];
                                    bogenschützen[angriffsLand] = 0;
                                    babaren[angriffsLand] = 0;
                                }
                                if (rathaus[verteidigungsLand] != 0 && !einmalRathausTruppe)
                                {
                                    babaren[verteidigungsLand]++;
                                    einmalRathausTruppe = true;
                                    zugGemacht = true;
                                }
                                if (bogenschützen[verteidigungsLand] == 0 && babaren[verteidigungsLand] == 0 && reiter[verteidigungsLand] == 0 && verteidigungsLand != angriffsLand)
                                {
                                    bogenschützen[verteidigungsLand] = bogenschützen[angriffsLand];
                                    babaren[verteidigungsLand] = babaren[angriffsLand];
                                    reiter[verteidigungsLand] = reiter[angriffsLand];
                                    spielerLand[verteidigungsLand] = anDerReihe;
                                    AngriffBeenden();
                                    bogenschützen[angriffsLand] = 0;
                                    babaren[angriffsLand] = 0;
                                    reiter[angriffsLand] = 0;
                                    aGewonnen = true;
                                    straße[verteidigungsLand] = 0;
                                    plündderLand = verteidigungsLand;
                                    if (clonen)
                                    {
                                        babaren[verteidigungsLand] /= 2;
                                    }
                                }
                                if (bogenschützen[angriffsLand] + babaren[angriffsLand] + reiter[angriffsLand] == bogenschützen[verteidigungsLand] + babaren[verteidigungsLand] + reiter[verteidigungsLand])
                                {
                                    bogenschützen[angriffsLand] = 0;
                                    babaren[angriffsLand] = 0;
                                    reiter[angriffsLand] = 0;
                                    bogenschützen[verteidigungsLand] = 0;
                                    babaren[verteidigungsLand] = 0;
                                    reiter[verteidigungsLand] = 0;
                                    zugGemacht = true;
                                    plündderLand = verteidigungsLand;
                                }
                                if (bogenschützen[angriffsLand] == 0 && babaren[angriffsLand] == 0 && reiter[angriffsLand] == 0 && bogenschützen[verteidigungsLand] + babaren[verteidigungsLand] + reiter[angriffsLand] != 0)
                                {
                                    verteidigungsLand = angriffsLand;
                                }
                                if (bogenschützen[angriffsLand] + babaren[angriffsLand] + reiter[angriffsLand] != 0 && bogenschützen[verteidigungsLand] + babaren[verteidigungsLand] + reiter[verteidigungsLand] != 0)
                                {
                                    if (bogenschützen[angriffsLand] + babaren[angriffsLand] + reiter[angriffsLand] > bogenschützen[verteidigungsLand] + babaren[verteidigungsLand] + reiter[verteidigungsLand])
                                    {
                                        plündderLand = verteidigungsLand;
                                        aGewonnen = true;
                                        straße[verteidigungsLand] = 0;
                                    }
                                    if (bogenschützen[angriffsLand] + babaren[angriffsLand] + reiter[angriffsLand] != bogenschützen[verteidigungsLand] + babaren[verteidigungsLand] + reiter[verteidigungsLand])
                                    {
                                        VBogies = bogenschützen[verteidigungsLand];
                                        VBabos = babaren[verteidigungsLand];
                                        if (aGewonnen)
                                        {
                                            if (reiter[verteidigungsLand] % 2 != 0)
                                            {
                                                reiter[verteidigungsLand]--;
                                                if (Random.Range(0, 2) == 1)
                                                {
                                                    VBogies++;
                                                }
                                                else
                                                {
                                                    VBabos++;
                                                }
                                            }
                                            bogenschützen[angriffsLand] -= reiter[verteidigungsLand] / 2;
                                            babaren[angriffsLand] -= reiter[verteidigungsLand] / 2;
                                            reiter[verteidigungsLand] = 0;
                                            if ((((babaren[angriffsLand] + bogenschützen[angriffsLand]) - (VBogies + VBabos)) % 2) != 0)
                                            {
                                                int random = Random.Range(0, 2);
                                                if (random == 1)
                                                {
                                                    VBabos -= 1;
                                                    babaren[angriffsLand] -= 1;
                                                }
                                                else
                                                {
                                                    VBabos -= 1;
                                                    bogenschützen[angriffsLand] -= 1;
                                                }
                                            }
                                            if ((VBogies + VBabos) % 2 != 0)
                                            {
                                                if (VBabos != 0)
                                                {
                                                    VBabos--;
                                                }
                                                else
                                                {
                                                    VBogies--;
                                                }
                                                bogenschützen[verteidigungsLand] = bogenschützen[angriffsLand] - (VBogies + VBabos) / 2;
                                                babaren[verteidigungsLand] = (babaren[angriffsLand] - (VBogies + VBabos) / 2) - 1;
                                            }
                                            else
                                            {
                                                bogenschützen[verteidigungsLand] = bogenschützen[angriffsLand] - (VBogies + VBabos) / 2;
                                                babaren[verteidigungsLand] = babaren[angriffsLand] - (VBogies + VBabos) / 2;
                                            }
                                        }
                                        else
                                        {
                                            /// Debug.Log("babaren[verteidigungsLand] : " + babaren[verteidigungsLand] + " bogenschützen[verteidigungsLand]: " + bogenschützen[verteidigungsLand]);
                                            if (reiter[angriffsLand] % 2 != 0 && reiter[angriffsLand] != 0)
                                            {
                                                reiter[angriffsLand]--;
                                                if (Random.Range(0, 2) == 1)
                                                {
                                                    babaren[angriffsLand]++;
                                                }
                                                else
                                                {
                                                    bogenschützen[angriffsLand]++;
                                                }
                                            }
                                            bogenschützen[verteidigungsLand] -= reiter[angriffsLand] / 2;
                                            babaren[verteidigungsLand] -= reiter[angriffsLand] / 2;
                                            //  Debug.Log("babaren[verteidigungsLand] : " + babaren[verteidigungsLand] + " bogenschützen[verteidigungsLand]: " + bogenschützen[verteidigungsLand]);
                                            reiter[angriffsLand] = 0;
                                            if (((babaren[angriffsLand] + bogenschützen[angriffsLand]) - (VBogies + VBabos)) % 2 != 0)
                                            {
                                                int random = Random.Range(0, 2);
                                                if (random == 1)
                                                {
                                                    babaren[verteidigungsLand]--;
                                                    babaren[angriffsLand] -= 1;
                                                }
                                                else
                                                {
                                                    babaren[verteidigungsLand]--;
                                                    bogenschützen[angriffsLand] -= 1;
                                                }
                                            }
                                            if ((bogenschützen[angriffsLand] + babaren[angriffsLand]) % 2 != 0 && bogenschützen[angriffsLand] + babaren[angriffsLand] != 0)
                                            {
                                                if (babaren[angriffsLand] != 0)
                                                {
                                                    babaren[angriffsLand]--;
                                                    babaren[verteidigungsLand]--;
                                                }
                                                else
                                                {
                                                    bogenschützen[angriffsLand]--;
                                                    bogenschützen[verteidigungsLand]--;
                                                }
                                            }
                                            bogenschützen[verteidigungsLand] = (bogenschützen[verteidigungsLand] - (bogenschützen[angriffsLand] + babaren[angriffsLand]) / 2);
                                            babaren[verteidigungsLand] = (babaren[verteidigungsLand] - (babaren[angriffsLand] + bogenschützen[angriffsLand]) / 2);
                                        }
                                        zugGemacht = true;
                                        if (aGewonnen)
                                        {
                                            reiter[verteidigungsLand] = reiter[angriffsLand];
                                        }
                                        while (bogenschützen[verteidigungsLand] < 0)
                                        {
                                            bogenschützen[verteidigungsLand]++;
                                            babaren[verteidigungsLand]--;
                                        }
                                        while (babaren[verteidigungsLand] < 0)
                                        {
                                            bogenschützen[verteidigungsLand]--;
                                            babaren[verteidigungsLand]++;
                                        }
                                        while (bogenschützen[verteidigungsLand] < 0)
                                        {
                                            reiter[verteidigungsLand]--;
                                            bogenschützen[verteidigungsLand]++;
                                        }
                                        bogenschützen[angriffsLand] = 0;
                                        babaren[angriffsLand] = 0;
                                        reiter[angriffsLand] = 0;
                                    }
                                }
                                if (zweiterAngriff > 0)
                                {
                                    bogenschützen[angriffsLand] = stayBogies;
                                    babaren[angriffsLand] = stayBabos;
                                    zweiterAngriff = 2;
                                }
                                if (aGewonnen)
                                {
                                    reiterLand = speicherVerteidigungsLand;
                                    spielerLand[verteidigungsLand] = anDerReihe;
                                    if (clonen)
                                    {
                                        babaren[verteidigungsLand] /= 2;
                                        babaren[verteidigungsLand] = Mathf.Round(babaren[verteidigungsLand]);
                                    }
                                    if (reiter[reiterLand] != 0 && zweitesAngriffsLand == 0)
                                    {
                                        zweitesAngriffsLand = reiterLand;
                                    }
                                }
                            }
                        }
                        else
                        {
                            verteidigungsLand = angriffsLand;
                        }
                    }
                    else if (spielerLand[verteidigungsLand] == anDerReihe)
                    {
                        verteidigungsLand = angriffsLand;
                    }
                }
                else
                {
                    angriffsLand = 0;
                }
            }
            if (zweiterAngriff == 0 && aGewonnen && reiter[reiterLand] != 0)
            {
                zugGemacht = false;
                aGewonnen = false;
                angriffsLand = reiterLand;
                zweiterAngriff = 1;
                verschieben = true;
                reiterVerschoben = 1;
            }
            else
            if (zweiterAngriff == 1 && getLand() == verteidigungsLand && !zugGemacht && !Input.GetMouseButtonUp(0))
            {
                zugGemacht = true;
                angreifen = true;
                standardAngriff = true;
                plündderLand = reiterLand;
                aGewonnen = true;
            }
        }
        else
        {
            if (zweiterAngriff != 0)
            {
                //    zugGemacht = true;
                //   angreifen = true;
                //  standardAngriff = true;
            }
        }
        if (bogenschützenAngriff)
        {
            if (angriffsLand == 0)
            {
                angriffsLand = getLand();
            }
            else
            {
                verteidigungsLand = getLand();
            }
            if (bogenschützen[angriffsLand] == 0)
            {
                angriffsLand = 0;
            }
            if (!zugGemacht)
            {
                if (landNichtAngreifen[0] != angriffsLand && landNichtAngreifen[1] != angriffsLand && landNichtAngreifen[2] != angriffsLand)
                {
                    if (angriffsLand != verteidigungsLand && spielerLand[angriffsLand] == anDerReihe && spielerLand[verteidigungsLand] != anDerReihe)
                    {
                        if (verteidigungsLand == angriffsLand - 100 || verteidigungsLand == angriffsLand + 1 || verteidigungsLand == angriffsLand - 1 || verteidigungsLand == angriffsLand + 100 && spielerLand[verteidigungsLand] != 0)
                        {
                            if (zahlAngriff > 2)
                            {
                                zahlAngriff = 2;
                            }
                            landNichtAngreifen[zahlAngriff] = verteidigungsLand;
                            zahlAngriff++;
                            float toteGegner;
                            if (!pfeihagel)
                            {
                                toteGegner = Mathf.Round(Random.Range(0, 0.70f * bogenschützen[angriffsLand]));
                            }
                            else
                            {
                                toteGegner = bogenschützen[angriffsLand];
                            }
                            Debug.Log(toteGegner);
                            if (toteGegner % 2 != 0)
                            {
                                int ran = Random.Range(1, 3);
                                if (ran == 1)
                                {
                                    bogenschützen[verteidigungsLand] -= 1f;
                                    toteGegner--;
                                }
                                else
                                {
                                    babaren[verteidigungsLand] -= 1;
                                    toteGegner--;
                                }
                            }
                            bogenschützen[verteidigungsLand] -= toteGegner / 2;
                            babaren[verteidigungsLand] -= toteGegner / 2;
                            while (bogenschützen[verteidigungsLand] < 0)
                            {
                                bogenschützen[verteidigungsLand]++;
                                babaren[verteidigungsLand]--;
                            }
                            while (babaren[verteidigungsLand] < 0)
                            {
                                babaren[verteidigungsLand]++;
                                bogenschützen[verteidigungsLand]--;
                            }
                            while (bogenschützen[verteidigungsLand] < 0)
                            {
                                bogenschützen[verteidigungsLand]++;
                                reiter[verteidigungsLand]--;
                            }
                            if (babaren[verteidigungsLand] < 0)
                            {
                                babaren[verteidigungsLand] = 0;
                            }
                            if (bogenschützen[verteidigungsLand] < 0)
                            {
                                bogenschützen[verteidigungsLand] = 0;
                            }
                            if (reiter[verteidigungsLand] < 0)
                            {
                                reiter[verteidigungsLand] = 0;
                            }
                            // babaren[verteidigungsLand] = Mathf.Round(babaren[verteidigungsLand]);
                            //  bogenschützen[verteidigungsLand] = Mathf.Round(bogenschützen[verteidigungsLand]);
                            zugGemacht = true;
                        }
                        else
                        {
                            verteidigungsLand = angriffsLand;
                        }
                    }
                }
                else
                {
                    angriffsLand = 0;
                }
            }
        }
        if (verschieben)
        {
            if (angriffsLand == 0)
            {
                angriffsLand = getLand();
            }
            else
            {
                verteidigungsLand = getLand();
            }
            if (!zugGemacht || reiterVerschoben == 0)
            {
                if (landNichtAngreifen[0] != angriffsLand && landNichtAngreifen[1] != angriffsLand && landNichtAngreifen[2] != angriffsLand || reiter[reiterLand] != 0)
                {
                    if (reiterVerschoben == 0 && zugGemacht)
                    {
                        zugGemacht = false;
                        angriffsLand = reiterLand;
                        if (reiter[reiterLand] != 0)
                        {
                            verteidigungsLand = reiterLand;
                            reiterVerschoben = 1;
                        }
                        else
                        {
                            angriffsLand = 0;
                            reiterVerschoben = 2;
                            zugGemacht = true;
                        }
                    }
                    if (reiterVerschoben == 1 && !zugGemacht && getLand() == angriffsLand && !Input.GetMouseButtonUp(0) && pc || reiterVerschoben == 1 && !zugGemacht && getLand() == angriffsLand && Input.GetMouseButtonUp(0) && !pc)
                    {
                        //  reiterLand = 0;
                    }
                    if (angriffsLand != verteidigungsLand && spielerLand[angriffsLand] == anDerReihe && spielerLand[verteidigungsLand] == anDerReihe)
                    {
                        if (reiterVerschoben == 0)
                        {
                            babaren[verteidigungsLand] += babaren[angriffsLand];
                            babaren[angriffsLand] = 0;
                            bogenschützen[verteidigungsLand] += bogenschützen[angriffsLand];
                            bogenschützen[angriffsLand] = 0;
                        }
                        if (zahlAngriff > 2)
                        {
                            zahlAngriff = 2;
                        }
                        landNichtAngreifen[zahlAngriff] = verteidigungsLand;
                        zahlAngriff++;
                        reiter[verteidigungsLand] += reiter[angriffsLand];
                        reiter[angriffsLand] = 0;
                        if (reiter[verteidigungsLand] != 0)
                        {
                            reiterLand = verteidigungsLand;
                        }
                        zugGemacht = true;
                    }
                    else
                    {
                        if (verteidigungsLand != angriffsLand)
                        {
                            verteidigungsLand = angriffsLand;
                        }
                        if (reiterVerschoben == 1 && reiter[reiterLand] != 0)
                        {
                            angreifen = true;
                            standardAngriff = true;
                            zweiterAngriff = 2;
                        }
                    }
                }
                else
                {
                    angriffsLand = 0;
                }
            }
        }
        else
        {
            if (reiterVerschoben != 0)
            {
                //  verschieben = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            regeln = false;
        }
        if (isPause)
        {
            Time.timeScale = 0.0F;
            canvas4.gameObject.SetActive(true);
            if (!regeln)
            {
                canvas4.gameObject.transform.GetChild(1).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(2).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(3).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(4).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(5).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(6).gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.70f, 0);
                canvas4.gameObject.transform.GetChild(7).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(8).gameObject.transform.position = new Vector3(Screen.width * 0.615f, Screen.height * 0.83f, 0);
            }
            else
            {
                canvas4.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(2).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(3).gameObject.SetActive(true);
                canvas4.gameObject.transform.GetChild(4).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(5).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(6).gameObject.transform.position = new Vector3(Screen.width / 2, Screen.height * 0.85f, 0);
                canvas4.gameObject.transform.GetChild(7).gameObject.SetActive(false);
                canvas4.gameObject.transform.GetChild(8).gameObject.transform.position = new Vector3(Screen.width * 0.885f, Screen.height * 0.8f, 0);
            }

        }
        else
        {
            Time.timeScale = 1.0F;
            canvas4.gameObject.SetActive(false);
        }
        if (pc)
        {
            rb.velocity = new Vector3(0, 0, 0);
            if (Input.GetKey("w"))
            {
                rb.velocity += new Vector3(0, 0, speed);
            }
            if (Input.GetKey("s"))
            {
                rb.velocity += new Vector3(0, 0, -speed);
            }
            if (Input.GetKey("a"))
            {
                rb.velocity += new Vector3(-speed, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                rb.velocity += new Vector3(speed, 0, 0);
            }
            if (Input.mousePosition.y > Screen.height * 0.95f)
            {
                rb.velocity = new Vector3(0, 0, speed);
            }
            if (Input.mousePosition.y < Screen.height * 0.05f)
            {
                rb.velocity = new Vector3(0, 0, -speed);
            }
            if (Input.mousePosition.x < Screen.width * 0.025f)
            {
                rb.velocity = new Vector3(-speed, 0, rb.velocity.z);
            }
            if (Input.mousePosition.x > Screen.width * 0.95f)
            {
                rb.velocity = new Vector3(speed, 0, rb.velocity.z);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            if (Input.GetMouseButtonDown(0) && Input.touchCount != 2)
            {
                mausPosition = Input.mousePosition;
            }
            else if (los && angriffsLand == 0 && gebäude == 0 || gebäude != 0 && zugGemacht)
            {
                {
                    if (Input.GetMouseButton(0) && Input.touchCount != 2)
                    {
                        if (map == 1)
                        {
                            this.transform.position -= new Vector3(Input.mousePosition.x - mausPosition.x, 0, Input.mousePosition.y - mausPosition.y) * 0.2f;
                        }
                        if (map == 2)
                        {
                            this.transform.position -= new Vector3(Input.mousePosition.x - mausPosition.x, 0, Input.mousePosition.y - mausPosition.y) * 0.4f;
                        }
                        mausPosition = Input.mousePosition;
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    merkeLand = getLand();
                }
                if (Input.GetMouseButton(0) && merkeLand == getLand())
                {
                    if (Input.mousePosition.y > Screen.height * 0.75f)
                    {
                        rb.velocity = new Vector3(0, 0, speed);
                    }
                    if (Input.mousePosition.y < Screen.height * 0.25f)
                    {
                        rb.velocity = new Vector3(0, 0, -speed);
                    }
                    if (Input.mousePosition.x < Screen.width * 0.25f)
                    {
                        rb.velocity = new Vector3(-speed, 0, rb.velocity.z);
                    }
                    if (Input.mousePosition.x > Screen.width * 0.75f)
                    {
                        rb.velocity = new Vector3(speed, 0, rb.velocity.z);
                    }
                }
            }
            if (map == 1)
            {
                speed = 120;
                if (this.transform.position.z < -50)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -50);
                }
                if (this.transform.position.z > 350)
                {
                    this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 350);
                }
                if (this.transform.position.x > 350)
                {
                    this.transform.position = new Vector3(350, this.transform.position.y, this.transform.position.z);
                }
                if (this.transform.position.x < 75)
                {
                    this.transform.position = new Vector3(75, this.transform.position.y, this.transform.position.z);
                }
            }
            if(map == 2)
            {
                speed = 200;
            }
        }
        if (!einmalWechseln)
        {
            if (position1 != new Vector3(0, 0, 0) && anDerReihe == 1)
            {
                this.transform.position = position1;
            }
            if (position2 != new Vector3(0, 0, 0) && anDerReihe == 2)
            {
                this.transform.position = position2;
            }
            if (position3 != new Vector3(0, 0, 0) && anDerReihe == 3)
            {
                this.transform.position = position3;
            }
            if (position4 != new Vector3(0, 0, 0) && anDerReihe == 4)
            {
                this.transform.position = position4;
            }
            einmalWechseln = true;
        }
        if (zugGemacht)
        {
            if (!zweiZüge && reiter[reiterLand] == 0 || angreifen && zweiterAngriff == 2 && !zweiZüge)
            {
                if (angreifen && kaserne[plündderLand] + rathaus[plündderLand] + kaserne[zweitesAngriffsLand] + rathaus[zweitesAngriffsLand] > 0 && gebäudePlündern || !angreifen && reiterLand == 0 || angreifen && kaserne[plündderLand] + rathaus[plündderLand] + kaserne[zweitesAngriffsLand] + rathaus[zweitesAngriffsLand] > 0 && gebäudeErhalten || angreifen && kaserne[plündderLand] + rathaus[plündderLand] + kaserne[zweitesAngriffsLand] + rathaus[zweitesAngriffsLand] == 0)
                {
                    gebäudeErhalten = false;
                    gebäudePlündern = false;
                    plündderLand = 0;
                    aGewonnen = false;
                    zugGemacht = false;
                    zweiZüge = true;
                    gecklickt = false;
                    zweitesAngriffsLand = 0;
                    if (angreifen)
                    {
                        verteidigungsLand = 0;
                        Angreifen();
                        zweiterAngriff = 0;
                    }
                    if (verschieben)
                    {
                        reiterVerschoben = 0;
                        Verschieben();
                    }
                    if (bauen)
                    {
                        Bauen();
                        gebäude = 0;
                        bauenZufällig = true;
                    }
                    if (ausbilden)
                    {
                        Ausbilden();
                    }
                }
            }
        }
        if (statistik)
        {
           // this.transform.position = new Vector3(2000, 160, 180);
            canvas1.gameObject.SetActive(false);
        }
    }
    public int getLand()
    {
        if (Input.GetMouseButtonDown(0) && pc || zweiterAngriff != 1 && !pc && Input.GetMouseButtonDown(0) && reiterVerschoben != 1 && Input.touchCount != 2 && !bauen || angriffsLand != 0 && Input.GetMouseButtonUp(0) && Input.touchCount != 2 || los && Input.GetMouseButtonUp(0) && Input.touchCount != 2)
        {
            if (Input.mousePosition.x > Screen.width * 0.3f || !los)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                      Debug.Log(hit.point);
                    if (map == 1)
                    {
                        if (hit.point.z > 0)
                        {
                            land = 500;
                        }
                        if (hit.point.z > 100)
                        {
                            land = 400;
                        }
                        if (hit.point.z > 200)
                        {
                            land = 300;
                        }
                        if (hit.point.z > 300)
                        {
                            land = 200;
                        }
                        if (hit.point.z > 400)
                        {
                            land = 100;
                        }
                        if (hit.point.z > 500 || hit.point.z < 0)
                        {
                            land = 0;
                        }
                    }
                if (map == 2)
                {
                    if (hit.point.z > 0)
                    {
                        land = 1400;
                    }
                    if (hit.point.z > 100)
                    {
                        land = 1300;
                    }
                    if (hit.point.z > 200)
                    {
                        land = 1200;
                    }
                    if (hit.point.z > 300)
                    {
                        land = 1100;
                    }
                    if (hit.point.z > 400)
                    {
                        land = 1000;
                    }
                    if (hit.point.z > 500)
                    {
                        land = 900;
                    }
                    if (hit.point.z > 600)
                    {
                        land = 800;
                    }
                    if (hit.point.z > 700)
                    {
                        land = 700;
                    }
                    if (hit.point.z > 800)
                    {
                        land = 600;
                    }
                    if (hit.point.z > 900)
                    {
                        land = 500;
                    }
                    if (hit.point.z > 1000)
                    {
                        land = 400;
                    }
                    if (hit.point.z > 1100)
                    {
                        land = 300;
                    }
                    if (hit.point.z > 1200)
                    {
                        land = 200;
                    }
                    if (hit.point.z > 1300)
                    {
                        land = 100;
                    }
                    if (hit.point.z > 1400 || hit.point.z < 0)
                    {
                        land = 0;
                    }
                }
                if (land != 0)
                {
                    if (map == 2)
                    {
                        if (hit.point.x > 1200)
                        {
                            land += 13;
                        }
                        else if (hit.point.x > 1100)
                        {
                            land += 12;
                        }
                        else if (hit.point.x > 1000)
                        {
                            land += 11;
                        }
                        else if (hit.point.x > 900)
                        {
                            land += 10;
                        }
                        else if (hit.point.x > 800)
                        {
                            land += 9;
                        }
                        else if (hit.point.x > 700)
                        {
                            land += 8;
                        }
                        else if (hit.point.x > 600)
                        {
                            land += 7;
                        }
                        else if (hit.point.x > 500)
                        {
                            land += 6;
                        }
                        else if (hit.point.x > 400)
                        {
                            land += 5;
                        }
                        else if (hit.point.x > 300)
                        {
                            land += 4;
                        }
                        else if (hit.point.x > 200)
                        {
                            land += 3;
                        }
                        else if (hit.point.x > 100)
                        {
                            land += 2;
                        }
                        else if (hit.point.x > 0)
                        {
                            land += 1;
                        }
                        if (hit.point.x > 1300 || hit.point.x < 0 || land == 303 || land == 304 || land == 307 || land == 310 || land == 311 || land == 403 || land == 407 || land == 411 || land == 506 || land == 507 || land == 508 || land == 703 || land == 704 || land == 710 || land == 711 || land == 803 || land == 804 || land == 810 || land == 811 || land == 1006 || land == 1007 || land == 1008 || land == 1103 || land == 1107 || land == 1111 || land == 1203 || land == 1204 || land == 1207 || land == 1210 || land == 1211)
                        {
                            land = 0;
                        }
                    }
                    if (map == 1)
                    {
                        if (hit.point.x > 400)
                        {
                            land += 5;
                        }
                        else if (hit.point.x > 300)
                        {
                            land += 4;
                        }
                        else if (hit.point.x > 200)
                        {
                            land += 3;
                        }
                        else if (hit.point.x > 100)
                        {
                            land += 2;
                        }
                        else if (hit.point.x > 0)
                        {
                            land += 1;
                        }
                        if (hit.point.x > 500 || hit.point.x < 0)
                        {
                            land = 0;
                        }
                    }
                }
            }
        }
        else
        {
            if (!bogenschützenAngriff)
            {
                land = 0;
            }
        }
        return land;
    }
    public void nächsterSpieler()
    {
        if (anDerReihe == 1)
        {
            position1 = this.transform.position;
        }
        if (anDerReihe == 2)
        {
            position2 = this.transform.position;
        }
        if (anDerReihe == 3)
        {
            position3 = this.transform.position;
        }
        if (anDerReihe == 4)
        {
            position4 = this.transform.position;
        }
        anDerReihe++;
        if (anDerReihe > spieler)
        {
            anDerReihe = 1;
        }
        zugGemacht = false;
        angreifen = false;
        bauen = false;
        verschieben = false;
        ausbilden = false;
        standardAngriff = false;
        bogenschützenAngriff = false;
        angriffsLand = 0;
        aGewonnen = false;
        verteidigungsLand = 0;
        einmal = false;
        einmalWechseln = false;
        einmalRathausTruppe = false;
        bauenGezielt = false;
        bauenZufällig = false;
        einmalGebäude = false;
        gebäude = 0;
        ausbilLand = 0;
        einmalAusbilden = false;
        bogiesAusbilden = 0;
        babosAusbilden = 0;
        reiterAusbilden = 0;
        altesLand = 0;
        gebäudePlündern = false;
        gebäudeErhalten = false;
        plündderLand = 0;
        goldbekommen = false;
        gecklickt = false;
        pfeihagel = false;
        clonen = false;
        reiterVerschoben = 0;
        reiterLand = 0;
        zweiterAngriff = 0;
        speicherVerteidigungsLand = 0;
        reiterBeschwören = false;
        zweitesAngriffsLand = 0;
        zweiZüge = false;
        landNichtAngreifen[0] = 0;
        landNichtAngreifen[1] = 0;
        landNichtAngreifen[2] = 0;
        zahlAngriff = 0;
        mauergebaut = false;
    }
    public void Angreifen()
    {
        if (!zugGemacht)
        {
            angreifen = !angreifen;
            land = 0;
            standardAngriff = false;
            bogenschützenAngriff = false;
            pfeihagel = false;
            angriffsLand = 0;
            reiterLand = 0;
        }
    }
    public void Bauen()
    {
        if (!zugGemacht && gebäude == 0 || zweiZüge)
        {
            bauen = !bauen;
            land = 0;
            bauenGezielt = false;
            mauergebaut = false;
            bauenGezielt = false;
            bauenZufällig = false;
            einmalGebäude = false;
            gebäude = 0;
        }
    }
    public void Verschieben()
    {
        if (!zugGemacht)
        {
            verschieben = !verschieben;
            land = 0;
            angriffsLand = 0;
            reiterLand = 0;
            verteidigungsLand = 0;
        }
    }
    public void Ausbilden()
    {
        if (!zugGemacht)
        {
            ausbilden = !ausbilden;
            ausbilLand = 0;
        }
    }
    public void StandardAngriff()
    {
        if (!zugGemacht)
        {
            standardAngriff = !standardAngriff;
            angriffsLand = 0;
        }
    }
    public void BogenschützenAngriff(bool Pfeilhagel)
    {
        if (!zugGemacht)
        {
            if (Pfeilhagel)
            {
                pfeihagel = true;
            }
            bogenschützenAngriff = !bogenschützenAngriff;
            angriffsLand = 0;
        }
    }
    public void AngriffBeenden()
    {

        zugGemacht = true;
    }
    public void BauenGezielt()
    {
        if (!zugGemacht)
        {
            bauenGezielt = !bauenGezielt;
        }
    }
    public void BauenZufällig()
    {
        if (gebäude == 0)
        {
            if (gold[anDerReihe] >= Zuffalspreis)
            {
                gold[anDerReihe] -= Zuffalspreis;
                bauenZufällig = true;
            }
        }
        else
        {
            if (!zugGemacht)
            {
                zugGemacht = true;
                bauen = false;
                bauenZufällig = false;
                gebäude = 0;
            }
        }
    }
    public void baue(int zahl)
    {
        if (gebäude == 0)
        {
            if (zahl == 1 && gold[anDerReihe] >= 30 || zahl == 2 && gold[anDerReihe] >= 40 || zahl == 3 && gold[anDerReihe] >= 25 || zahl == 4 && gold[anDerReihe] >= 100 || zahl == 5 && gold[anDerReihe] >= 150 || rasse[anDerReihe - 1] == 0 && zahl == 1 && gold[anDerReihe] >= 20 || rasse[anDerReihe - 1] == 0 && zahl == 2 && gold[anDerReihe] >= 25 || rasse[anDerReihe - 1] == 0 && zahl == 3 && gold[anDerReihe] >= 15)
            {
                if (zahl == 1)
                {
                    if (rasse[anDerReihe - 1] != 0)
                    {
                        gold[anDerReihe] -= 30;
                    }
                    else
                    {
                        gold[anDerReihe] -= 20;
                    }
                }
                if (zahl == 2)
                {
                    if (rasse[anDerReihe - 1] != 0)
                    {
                        gold[anDerReihe] -= 40;
                    }
                    else
                    {
                        gold[anDerReihe] -= 25;
                    }
                }
                if (zahl == 3)
                {
                    if (rasse[anDerReihe - 1] != 0)
                    {
                        gold[anDerReihe] -= 25;
                    }
                    else
                    {
                        gold[anDerReihe] -= 15;
                    }
                }
                if (zahl == 4)
                {
                    gold[anDerReihe] -= 100;
                }
                if (zahl == 5)
                {
                    gold[anDerReihe] -= 150;
                }
                gebäude = zahl;
            }
        }
    }

    public void BogiesAusbilden(int zahl)
    {
        if (zahl == 1 && bogiesAusbilden * 2 + babosAusbilden + reiterAusbilden * 2 <= kaserne[ausbilLand] * 3 - 2)
        {
            bogiesAusbilden++;
        }
        if (zahl == -1 && bogiesAusbilden > 0)
        {
            bogiesAusbilden--;
        }
    }
    public void BabosAusbilden(int zahl)
    {
        if (zahl == 1 && bogiesAusbilden * 2 + babosAusbilden + reiterAusbilden * 2 <= kaserne[ausbilLand] * 3 - 1)
        {
            babosAusbilden++;
        }
        if (zahl == -1 && babosAusbilden > 0)
        {
            babosAusbilden--;
        }
    }
    public void ReiterAusbilden(int zahl)
    {
        if (zahl == 1 && bogiesAusbilden * 2 + babosAusbilden + reiterAusbilden * 2 <= kaserne[ausbilLand] * 3 - 2)
        {
            reiterAusbilden++;
        }
        if (zahl == -1 && reiterAusbilden > 0)
        {
            reiterAusbilden--;
        }
    }
    public void truppenAusbilden()
    {
        if (gold[anDerReihe] >= (bogiesAusbilden * 15 + babosAusbilden * 10 + reiterAusbilden * 25) && rasse[anDerReihe - 1] == 0 || rasse[anDerReihe - 1] == 1 && gold[anDerReihe] >= (bogiesAusbilden * 15 + babosAusbilden * 10 + reiterAusbilden * 20) || rasse[anDerReihe - 1] == 2 && gold[anDerReihe] >= (bogiesAusbilden * 15 + babosAusbilden * 7 + reiterAusbilden * 25) || rasse[anDerReihe - 1] == 3 && gold[anDerReihe] >= (bogiesAusbilden * 12 + babosAusbilden * 10 + reiterAusbilden * 25))
        {
            if (rasse[anDerReihe - 1] == 0)
            {
                gold[anDerReihe] -= (bogiesAusbilden * 15 + babosAusbilden * 10 + reiterAusbilden * 25);
            }
            if (rasse[anDerReihe - 1] == 1)
            {
                gold[anDerReihe] -= (bogiesAusbilden * 15 + babosAusbilden * 10 + reiterAusbilden * 20);
            }
            if (rasse[anDerReihe - 1] == 2)
            {
                gold[anDerReihe] -= (bogiesAusbilden * 15 + babosAusbilden * 7 + reiterAusbilden * 25);
            }
            if (rasse[anDerReihe - 1] == 3)
            {
                gold[anDerReihe] -= (bogiesAusbilden * 12 + babosAusbilden * 10 + reiterAusbilden * 25);
            }
            bogenschützen[ausbilLand] += bogiesAusbilden;
            babaren[ausbilLand] += babosAusbilden;
            reiter[ausbilLand] += reiterAusbilden;
            zugGemacht = true;
        }
    }
    public void GebäudePlündern()
    {
        gebäudePlündern = true;
        gold[anDerReihe] += (rathaus[plündderLand] * 20 + kaserne[plündderLand] * 15) + (rathaus[zweitesAngriffsLand] * 20 + kaserne[zweitesAngriffsLand] * 15);
        rathaus[plündderLand] = 0;
        kaserne[plündderLand] = 0;
        kaserne[zweitesAngriffsLand] = 0;
        rathaus[zweitesAngriffsLand] = 0;
    }
    public void GebäudeErhalten()
    {
        gebäudeErhalten = true;
    }
    public void länderAuswählen()
    {
        landAuswählen = true;
    }
    public void SpielerPlus(bool plus)
    {
        if (plus)
        {
            spieler++;
        }
        else
        {
            spieler = 2;
        }
    }
    public void SpielerVerloren()
    {

        for (int i = 0; i < spieler +1 ; i++)
        {
            if (spielerVerloren[i] == 1)
            {
                spielerVerloren[i] = 2;
            }
        }
    }
    public void SpielerGewonnen()
    {
        Application.LoadLevel(0);
    }
    public void Pfeilhagel()
    {
        if(gold[anDerReihe] >= 100)
        {
            gold[anDerReihe] -= 100;
        }
        else
        {
            bogenschützenAngriff = !bogenschützenAngriff;
            pfeihagel = false;
        }
    }
    public void Clonen()
    {
        if(gold[anDerReihe] >= 100)
        {
            gold[anDerReihe] -= 100;
            clonen = true;
        }
        else
        {
            standardAngriff = !standardAngriff;
            clonen = false;
        }
    }
    public void ReiterBeschwören()
    {
        if (gold[anDerReihe] >= 100 && !zugGemacht && !reiterBeschwören)
        {
            gold[anDerReihe] -= 100;
            reiterBeschwören = true;
        }
    }
    public void Regeln()
    {
        regeln = !regeln;
    }
    public void Menu()
    {
        Application.LoadLevel(0);
    }
    public void zurück()
    {
        if (regeln)
        {
            regeln = !regeln;
        }
        else
        {
            isPause = false;
        }
    }
    public void Close()
    {
        regeln = false;
        isPause = false;
        Time.timeScale = 1.0F;
    }
    public void pause()
    {
        isPause = true;
        regeln = false;
    }
    public void überspringen()
    {
        zugGemacht = false;
        zweiZüge = false;
    }
    public void mauerDrehen()
    {
        Mauer.transform.Rotate(0, 90, 0);
    }
    public void Statistik()
    {
        statistik = !statistik;
        if (statistik)
        {
            canvasstatistik.gameObject.SetActive(true);
        }
        else
        {
            canvasstatistik.gameObject.SetActive(false);
        }
    }
    public void nächsteMap()
    {
        map++;
        if(map == 3)
        {
            map = 1;
        }
    }
    public void OnGUI()
    {
        GUI.color = Color.black;
        if (statistik)
        {
            GUIStyle customLabel = new GUIStyle("label");
            customLabel.fontSize = 30;
            GUI.Label(new Rect(Screen.width * 0.5f  - 50, Screen.height * 0.05f, Screen.height * 1f, Screen.width * 0.5f), "Statistik" , customLabel);
            customLabel.fontSize = 20;
            GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.3f, Screen.height * 1f, Screen.width * 1f), spieler1, customLabel);
            GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.4f, Screen.height * 1f, Screen.width * 1f), spieler2, customLabel);
            if (spieler > 2)
            {
                GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.5f, Screen.height * 1f, Screen.width * 1f), spieler3, customLabel);
                if (spieler > 3)
                {
                    GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.6f, Screen.height * 1f, Screen.width * 1f), spieler4, customLabel);
                }
            }
            GUI.Label(new Rect(Screen.width * 0.19f, Screen.height * 0.22f, Screen.height * 1f, Screen.width * 1f), "Gold", customLabel);
            GUI.Label(new Rect(Screen.width * 0.25f, Screen.height * 0.22f, Screen.height * 1f, Screen.width * 1f), "Länder", customLabel);
            GUI.Label(new Rect(Screen.width * 0.31f, Screen.height * 0.2f, Screen.height * 1f, Screen.width * 1f), "Rathäuser\n(gewürfelt)", customLabel);
            GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.2f, Screen.height * 1f, Screen.width * 1f), "Kasernen\n(gewürfelt)", customLabel);
            GUI.Label(new Rect(Screen.width * 0.485f, Screen.height * 0.2f, Screen.height * 1f, Screen.width * 1f), "Straßen\n(gewürfelt)", customLabel);
            GUI.Label(new Rect(Screen.width * 0.57f, Screen.height * 0.2f, Screen.height * 1f, Screen.width * 1f), "Nieten\n(gewürfelt)", customLabel);
            for (int i = 1; i < 5; i++)
            {
                if (spieler == 3 && i < 4 || spieler > 3 && i != 4 || spieler == 2 && i < 3 ||spieler == 4)
                {
                    GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "" + gold[i], customLabel);
                    GUI.Label(new Rect(Screen.width * 0.25f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "" + länder[i], customLabel);
                    GUI.Label(new Rect(Screen.width * 0.31f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "" + rathäuser[i] + " (" + Rathaustatistik[i] + ")", customLabel);
                    GUI.Label(new Rect(Screen.width * 0.4f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "" + Kasernen[i] + " (" + KasernenStatistik[i] + ")", customLabel);
                    GUI.Label(new Rect(Screen.width * 0.485f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "" + Straßen[i] + " (" + StraßenStatistik[i] + ")", customLabel);
                    GUI.Label(new Rect(Screen.width * 0.57f, Screen.height * 0.2f + Screen.height * 0.1f * i, Screen.height * 1f, Screen.width * 1f), "(" + NietenStatistik[i] + ")", customLabel);
                }
            }
        }
    }
}
