using UnityEngine;
using System.Collections;

public class GeneradorEscenario : MonoBehaviour {

    public GameObject[] tipos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject[,] Generar(int lado)
    {
        GameObject[,] escenario = new GameObject[lado,lado];
        for(int i=0; i<lado; i++)
        {
            for(int j=0; j<lado; j++)
            {
                escenario[i, j] = tipos[Random.Range(0, tipos.Length-1)];
            }
        }
        return escenario;
    }

    public int[,] GenerarOrientaciones(int lado)
    {
        int[,] orientaciones = new int[lado, lado];
        for(int i=0; i<lado; i++)
        {
            for(int j=0; j<lado; j++)
            {
                orientaciones[i, j] = Random.Range(0, 3) * 90;
            }
        }
        return orientaciones;
    }
}
