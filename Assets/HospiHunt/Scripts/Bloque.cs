using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

    //Private attributes
    GameObject gameObject;
    int orientacion;
    bool girado = false;
    bool tieneZombie = false;

    //Public getters and setters
    public void setGameObject(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public GameObject getGameObject()
    {
        return this.gameObject;
    }

    public void setOrientacion(int orientacion)
    {
        this.orientacion = orientacion;
    }

    public int getOrientacion()
    {
        return this.orientacion;
    }

    public void setGirado(bool girado)
    {
        this.girado = girado;
    }

    public bool isGirado()
    {
        return this.girado;
    }

    public void setTieneZombie(bool tieneZombie)
    {
        this.tieneZombie = tieneZombie;
    }

    public bool isTieneZombie()
    {
        return tieneZombie;
    }

    //This method rotates the block
    //Este método rota el bloque
    public void girar()
    {
        if (!isGirado())
        {
            gameObject.transform.Rotate(0, orientacion, 0);
            setGirado(true);
        }
    }

	// Use this for initialization
	void Start () {
        girar(); //The block rotates when it's instanciated | El bloque girará cuando haya sido instanciado.
	}
	
	// Update is called once per frame
	void Update () {
        //Generates a random rotation and rotates the block if applies
        //Generamos una rotación aleatoria y la aplicamos si se cumplen las condiciones
        orientacion = Random.Range(0, 4) * 90;
        girar();
	}
}
