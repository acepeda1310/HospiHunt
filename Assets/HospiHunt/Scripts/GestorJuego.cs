using UnityEngine;
using System.Collections;

public class GestorJuego : MonoBehaviour {

    Bloque[,] escenario;
    GameObject personaje;
    GameObject[] zombies;

	// Use this for initialization
	void Start () {
        escenario = GeneradorEscenario.GenerarZombies(GeneradorEscenario.Generar(5));
        InstanciarEscenario();
        InstanciarZombies();
        InstanciarJugador();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void InstanciarEscenario()
    {
        int posInicial = 8*(escenario.Length / 2)-4;
        for(int i=0;  i<escenario.Length; i++)
        {
            for(int j=0; j<escenario.Length; j++)
            {
                Instantiate(escenario[i, j].getGameObject(), new Vector3(8 * i - posInicial, 8 * j - posInicial, 0), Quaternion.identity);
            }
        }
    }

    private void InstanciarZombies()
    {
        int posInicial = 8 * (escenario.Length / 2) - 4;
        int colocados = 0;
        for(int i=0; i<escenario.Length; i++)
        {
            for(int j=0; j<escenario.Length; j++)
            {
                if (escenario[i, j].isTieneZombie())
                {
                    Instantiate(zombies[colocados], new Vector3(8 * i - posInicial, 8 - j * posInicial, 0), Quaternion.identity);
                    colocados++;
                }
            }
        }
    }

    private void InstanciarJugador()
    {
        personaje.transform.position = new Vector3(0,0,0);
    }

}
