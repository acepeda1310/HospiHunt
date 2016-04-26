using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

    //Private attributes
    GameObject gameObject;
    int orientacion;
    bool girado = false;

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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
