using UnityEngine;
using System.Collections;

public class GeneradorEscenario : MonoBehaviour {

    public GameObject[] tipos;
    public GameObject zombie;

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
                bloque.setGameObject(this.tipos[Random.Range(0, this.tipos.Length)]);
                bloque.setOrientacion(Random.Range(0, 4) * 90);
                escenario[i, j] = bloque;
            }
        }
        return escenario;
    }
    
    public Bloque[,] GenerarZombies(Bloque[,] escenario)
    {
        for(int i=Random.Range(0,2); i< System.Math.Sqrt(escenario.Length); i += 2)
        {
            for(int j=Random.Range(0,2); j< System.Math.Sqrt(escenario.Length); j += 2)
            {
                escenario[i, j].setTieneZombie(true);
            }
        }
        return escenario;
    }

    public Bloque[,] GenerarBaterias(Bloque[,] escenario)
    {
        for(int i=Random.Range(0,3); i< System.Math.Sqrt(escenario.Length); i += Random.Range(2, 4))
        {
            for(int j=Random.Range(0,3); j< System.Math.Sqrt(escenario.Length); j += Random.Range(2, 4))
            {
                escenario[i, j].setTieneBateria(true);
                i += Random.Range(0, 3) - 1;
                if (i < 0) i = 0;
            }
        }
        return escenario;
    }
}
