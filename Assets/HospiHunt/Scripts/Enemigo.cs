using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    public Transform player;
    public int velocidad=3;
    Jugador jugador;
    Animator anim;

    void Awake()
    {
        this.Invoke("Jugador", 5);
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        if (this.player != null)
        {
            float x = this.transform.position.x;
            float z = this.transform.position.z;
            float distanciaX = this.player.position.x - x;
            float distanciaZ = this.player.position.z - z;
            float distanciaTotal = ((this.player.position - this.transform.position).magnitude);
            Vector3 vector = new Vector3((distanciaX/distanciaTotal)/100, 0, (distanciaZ/distanciaTotal)/100);
            this.transform.Translate(vector * this.velocidad);
            this.transform.position = (new Vector3(this.transform.position.x, 0.12f, this.transform.position.z));
            this.transform.LookAt(player);
            this.transform.eulerAngles = new Vector3(0, this.transform.rotation.eulerAngles.y, 0);
        }
    }

    void Jugador()
    {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.jugador = (Jugador) GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
    }

    void OnTriggerEnter(Collider colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            anim.SetBool("atacando", true);
            jugador.quitarVida();
        }
    }

    void OnTriggerStay(Collider colision)
    {
        if (colision.gameObject.tag == "Player")
        {
            jugador.quitarVida();
        }
    }

    void OnTriggerExit(Collider colision)
    {
        anim.SetBool("atacando", false);
    }
}
