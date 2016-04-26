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

    //It generates a Bloque matrix and return it to the game gestor.
    //Generamos una matriz de bloques para retornarlo al gestor del juego.
    public Bloque[,] Generar(int lado)
    {
        Bloque[,] escenario = new Bloque[lado, lado];
        //Iterate to all escenario items
        //Recorremos la matriz escenario
        for(int i=0; i<lado; i++)
        {
            for(int j=0; j<lado; j++)
            {
                //Generate the Bloque and its properties
                //Generamos el bloque y sus propiedades
                Bloque bloque = new Bloque();
                bloque.setGameObject(tipos[Random.Range(0, tipos.Length)]);
                bloque.setOrientacion(Random.Range(0, 4) * 90);
                escenario[i, j] = bloque;
            }
        }
        return escenario;
    }
}
