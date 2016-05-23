using UnityEngine;
using System.Collections;

public class GestorJuego : MonoBehaviour {

    Bloque[,] escenario;
    GameObject personaje;
    GameObject[] zombies;
    GameObject[] items;
    GameObject[] baterias;

	// Use this for initialization
	void Start () {
        this.escenario = GeneradorEscenario.GenerarBaterias(GeneradorEscenario.GenerarZombies(GeneradorEscenario.Generar(5)));
        this.InstanciarEscenario();
        this.InstanciarZombies();
        this.InstanciarJugador();
        this.InstanciarBaterias();
	}
	
	// Update is called once per frame
	void Update () {
        this.Invoke("InstanciarItem", 90);
	}

    private void InstanciarEscenario()
    {
        int posInicial = 8*(this.escenario.Length / 2)-4;
        for(int i=0;  i<this.escenario.Length; i++)
        {
            for(int j=0; j<this.escenario.Length; j++)
            {
                Instantiate(this.escenario[i, j].getGameObject(), new Vector3(8 * i - posInicial, 8 * j - posInicial, 0), Quaternion.identity);
            }
        }
    }

    private void InstanciarZombies()
    {
        int posInicial = 8 * (this.escenario.Length / 2) - 4;
        int colocados = 0;
        for(int i=0; i<this.escenario.Length; i++)
        {
            for(int j=0; j<this.escenario.Length; j++)
            {
                if (this.escenario[i, j].isTieneZombie())
                {
                    Instantiate(this.zombies[colocados], new Vector3(8 * i - posInicial, 8 - j * posInicial, 0), Quaternion.identity);
                    colocados++;
                }
            }
        }
    }

    private void InstanciarJugador()
    {
        this.personaje.transform.position = new Vector3(0,0,0);
    }

    private void InstanciarBaterias()
    {
        int posInicial = 8 * (this.escenario.Length / 2) - 4;
        int colocadas = 0;
        for (int i = 0; i < this.escenario.Length; i++)
        {
            for (int j = 0; j < this.escenario.Length; j++)
            {
                if (this.escenario[i, j].isTieneBateria())
                {
                    Instantiate(this.baterias[colocadas], new Vector3(8 * i - posInicial, 8 - j * posInicial, 0), Quaternion.identity);
                    colocadas++;
                }
            }
        }
    }

    //Todavía por hacer
    private void InstanciarItem()
    {

    }

}
