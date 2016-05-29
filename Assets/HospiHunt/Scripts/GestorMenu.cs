using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void cargarJuego()
    {
        SceneManager.LoadScene("Juego");
    }

    public void salir()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }
}
