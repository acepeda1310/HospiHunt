using UnityEngine;
using System.Collections;

public class GestorJuego : MonoBehaviour {
    /*
    Bloque[,] escenario;
    GameObject personaje;
    GameObject[] zombies;
    GameObject[] items;
    GameObject[] baterias;
	*/

    public GameObject zombie, item, bateria;

    Bloque[,] escenario;
    GameObject personaje;

	int longitudBloque=20;

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
        int posInicial = this.longitudBloque*(this.escenario.Length / 2)-(this.longitudBloque / 2);
        for(int i=0;  i<this.escenario.Length; i++)
        {
            for(int j=0; j<this.escenario.Length; j++)
            {
                Instantiate(this.escenario[i, j].getGameObject(), new Vector3(this.longitudBloque * i - posInicial, this.longitudBloque * j - posInicial, 0), Quaternion.identity);
            }
        }
    }

    private void InstanciarZombies()
    {
        int posInicial = this.longitudBloque * (this.escenario.Length / 2) - (this.longitudBloque / 2);
        for(int i=0; i<this.escenario.Length; i++)
        {
            for(int j=0; j<this.escenario.Length; j++)
            {
                if (this.escenario[i, j].isTieneZombie() && ! (i > (this.escenario.Length / 2) - 2 && i < (this.escenario.Length / 2) + 2 && j > (this.escenario.Length / 2) - 2 && j < (this.escenario.Length / 2) + 2))
                {
                    Instantiate(this.zombie, new Vector3(this.longitudBloque * i - posInicial, this.longitudBloque * j - posInicial, 0), Quaternion.identity);
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
        int posInicial = this.longitudBloque * (this.escenario.Length / 2) - (this.longitudBloque / 2);
        for (int i = 0; i < this.escenario.Length; i++)
        {
            for (int j = 0; j < this.escenario.Length; j++)
            {
                if (this.escenario[i, j].isTieneBateria())
                {
                    Instantiate(this.bateria, new Vector3(this.longitudBloque * i - posInicial, this.longitudBloque - j * posInicial, 0), Quaternion.identity);
                }
            }
        }
    }

    //Todavía por hacer
    private void InstanciarItem()
    {
        int posX = Random.Range(0, this.escenario.Length);
        int posY = Random.Range(0, this.escenario.Length);
        int posXJugador = ((int)this.personaje.transform.position.x) / this.longitudBloque + (this.escenario.Length / 2) + (longitudBloque / 2);
        int posYJugador = ((int)this.personaje.transform.position.z) / this.longitudBloque + (this.escenario.Length / 2) + (longitudBloque / 2);
        if (!(posXJugador + 2 > posX && posXJugador - 2 < posX && posYJugador + 2 > posY && posYJugador - 2 < posY))
        {
            int posInicial = this.longitudBloque * (this.escenario.Length / 2) - (this.longitudBloque / 2);
            Instantiate(this.item, new Vector3(this.longitudBloque * posX - posInicial, this.longitudBloque * posY - posInicial, 1), Quaternion.identity);
        }
        else
        {
            InstanciarItem();
        }
    }

}
