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

    public Bloque[,] Generar(int lado)
    {
        Bloque[,] escenario = new Bloque[lado, lado];
        for(int i=0; i<lado; i++)
        {
            for(int j=0; j<lado; j++)
            {
                Bloque bloque = new Bloque();
                bloque.setGameObject(tipos[Random.Range(0, tipos.Length)]);
                bloque.setOrientacion(Random.Range(0, 4) * 90);
                escenario[i, j] = bloque;
            }
        }
        return escenario;
    }
}
