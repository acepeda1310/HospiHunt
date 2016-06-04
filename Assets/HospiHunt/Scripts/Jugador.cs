using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Jugador : MonoBehaviour {

    public int vida=100, bateria =100;
    public float timer = 0f;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

    // Use this for initialization
    void Start () {
        this.Invoke("AumentarVida", 30);
        this.Invoke("DisminuirBateria", 10);
    }
	
	// Update is called once per frame
	void Update () {

        this.timer += Time.deltaTime;
        if (this.vida > 100)
            this.vida = 100;
        else if (vida <= 0)
            SceneManager.LoadScene("GameOver");
        if (this.bateria <= 0)
        {
            this.fpc.setWalkSpeed(this.fpc.getWalkSpeed() * 2 / 3);
        }
	}

    void OnCollisionEnter(Collision colision)
    {
        Debug.Log(colision.gameObject.tag);
        if (colision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Victoria");
        }
        else if (colision.gameObject.tag == "item")
        {
            this.vida += 5;
            GameObject.Destroy(colision.gameObject);
        }
        else if (colision.gameObject.tag == "bateria")
        {
            this.bateria += 10;
            GameObject.Destroy(colision.gameObject);
        }
    }

    public void quitarVida()
    {
        Debug.Log("123");

        if (this.timer >= 2)
        {
            this.vida -= 10;
            this.timer = 0f;
        }
    }

    void AumentarVida()
    {
        this.vida++;
        this.Invoke("AumentarVida", 30);
    }

    void DisminuirBateria()
    {
        this.bateria--;
        this.Invoke("DisminuirBateria", 10);
    }
}
