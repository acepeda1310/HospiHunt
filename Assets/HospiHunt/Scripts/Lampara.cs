using UnityEngine;
using System.Collections;

public class Lampara : MonoBehaviour {

    private bool enciende;
    private bool parpadea;
    private int parpadeosPorMinuto;
    private float duracionParpadeo;

	// Use this for initialization
	void Start () {
        
        enciende = Random.Range(0, 1)==1;
        if (enciende)
        {
            parpadea = Random.Range(0, 1) == 1;
            if (parpadea)
            {
                parpadeosPorMinuto = Random.Range(0, 30);
                duracionParpadeo = Random.Range(0.01f, (60 / parpadeosPorMinuto) / 2);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (enciende)
        {
            if (parpadea)
            {

            }
            else
            {

            }
        }
	}
}
