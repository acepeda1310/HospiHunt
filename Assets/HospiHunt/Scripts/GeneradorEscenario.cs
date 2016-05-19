using UnityEngine;
using System.Collections;

public class GeneradorEscenario : MonoBehaviour {

    public static GameObject[] tipos;
    public static GameObject zombie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //It generates a Bloque matrix and return it to the game gestor.
    //Generamos una matriz de bloques para retornarlo al gestor del juego.
    public static Bloque[,] Generar(int lado)
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
    
    public static Bloque[,] GenerarZombies(Bloque[,] escenario)
    {
        for(int i=Random.Range(0,5); i<escenario.Length; i += 5)
        {
            for(int j=Random.Range(0,5); j<escenario.Length; j += 5)
            {
                escenario[i, j].setTieneZombie(true);
            }
        }
        return escenario;
    }

    public static Bloque[,] GenerarBaterias(Bloque[,] escenario)
    {
        for(int i=Random.Range(0,10); i<escenario.Length; i += Random.Range(5, 10))
        {
            for(int j=Random.Range(0,10); j<escenario.Length; j += Random.Range(5, 10))
            {
                escenario[i, j].setTieneBateria(true);
                i += Random.Range(0, 4) - 2;
                if (i < 0) i = 0;
            }
        }
        return escenario;
    }
}
