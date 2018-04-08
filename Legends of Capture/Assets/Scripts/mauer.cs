using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mauer : MonoBehaviour {
    public bool gebaut;
    public int land;
    public int spieler;
    public GameObject mainCamera;
    private mainScript a;
    bool einmal;
    // Use this for initialization
    void Start () {
        gebaut = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(mainCamera != null)
        {
            a = mainCamera.GetComponent<mainScript>();
            if(a.spielerLand[land] != spieler)
            {
                Destroy(this.gameObject);
                a.mauerLand[land] = 0;
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "StraßenDouble(Clone)" && !einmal)
        {
            einmal = true;
            Debug.Log("asad");
            a.Straßen[a.spielerLand[collision.gameObject.GetComponent<straße>().land1]]--;
            Destroy(collision.gameObject);
        }
        else
        {
            einmal = false;
        }
    }
}
