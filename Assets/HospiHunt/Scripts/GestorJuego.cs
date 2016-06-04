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

    public GameObject zombie, item, bateria, personaje;

    public int lado;

	public GeneradorEscenario generadorEscenario;
	
    Bloque[,] escenario;

	int longitudBloque=20;

	// Use this for initialization
	void Start () {
        this.escenario = this.generadorEscenario.GenerarBaterias(this.generadorEscenario.GenerarZombies(this.generadorEscenario.Generar(this.lado)));
        this.InstanciarEscenario();
        this.InstanciarZombies();
        this.InstanciarJugador();
        this.InstanciarBaterias();
        this.Invoke("InstanciarItem", 90);
    }
	
	// Update is called once per frame
	void Update () {
        foreach(Bloque bloque in this.escenario)
        {
            var distancia = this.personaje.transform.position - bloque.getGameObject().transform.position;
            float distanciaReal = distancia.magnitude;
            if (distanciaReal > 20)
            {
                bloque.setGirado(false);
            }
        }
	}

    private void InstanciarEscenario()
    {
        Debug.Log(this.escenario.Length);
        int posInicial = this.longitudBloque*(int)(System.Math.Sqrt(this.escenario.Length) / 2)-(this.longitudBloque / 2);
        for(int i=0;  i< System.Math.Sqrt(this.escenario.Length); i++)
        {
            for(int j=0; j< System.Math.Sqrt(this.escenario.Length); j++)
            {
                Instantiate(this.escenario[i, j].getGameObject(), new Vector3(this.longitudBloque * i - posInicial, 0f, this.longitudBloque * j - posInicial), Quaternion.identity);
            }
        }
    }

    private void InstanciarZombies()
    {
        int posInicial = this.longitudBloque * (int)(System.Math.Sqrt(this.escenario.Length) / 2) - (this.longitudBloque / 2);
        for(int i=0; i< System.Math.Sqrt(this.escenario.Length); i++)
        {
            for(int j=0; j< System.Math.Sqrt(this.escenario.Length); j++)
            {
                if (this.escenario[i, j].isTieneZombie() && ! (i > (System.Math.Sqrt(this.escenario.Length) / 2) - 2 && i < (System.Math.Sqrt(this.escenario.Length) / 2) + 2 && j > (System.Math.Sqrt(this.escenario.Length) / 2) - 2 && j < (System.Math.Sqrt(this.escenario.Length) / 2) + 2))
                {
                    Instantiate(this.zombie, new Vector3(this.longitudBloque * i - posInicial, 0.12f, this.longitudBloque * j - posInicial), Quaternion.identity);
                }
            }
        }
    }

    private void InstanciarJugador()
    {
        Instantiate(this.personaje, new Vector3(5, 2, 5), Quaternion.identity);
    }

    private void InstanciarBaterias()
    {
        int posInicial = this.longitudBloque * (int)(System.Math.Sqrt(this.escenario.Length) / 2) - (this.longitudBloque / 2);
        for (int i = 0; i < System.Math.Sqrt(this.escenario.Length); i++)
        {
            for (int j = 0; j < System.Math.Sqrt(this.escenario.Length); j++)
            {
                if (this.escenario[i, j].isTieneBateria())
                {
                    Instantiate(this.bateria, new Vector3(this.longitudBloque * i - posInicial, 1, this.longitudBloque - j * posInicial), Quaternion.identity);
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
            Instantiate(this.item, new Vector3(this.longitudBloque * posX - posInicial, 1, this.longitudBloque * posY - posInicial), Quaternion.identity);
        }
        else
        {
            InstanciarItem();
        }
        this.Invoke("InstanciarItem", 90);
    }

}
