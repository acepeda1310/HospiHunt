using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public int velocidad=3;

    void Awake()
    {
        this.Invoke("Jugador", 5);
    }


    void FixedUpdate()
    {
        if (this.player != null)
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z;
            float distanciaX = this.player.position.x - x;
            float distanciaZ = this.player.position.z - z;
            float distanciaTotal = (float)System.Math.Sqrt(System.Math.Pow((double)distanciaX, 2) + System.Math.Pow((double)distanciaZ, 2));
            Vector3 vector = new Vector3((distanciaX/distanciaTotal)/100, 0, (distanciaZ/distanciaTotal)/100);
            this.transform.Translate(vector * this.velocidad);
        }
    }

    void Jugador()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
