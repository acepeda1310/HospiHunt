using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotonesMenuPrincipal : MonoBehaviour {

	public boolean juego=true;

    void OnMouseDown()
    {
        Camera.main.GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().Play();
        Invoke("AccionarBoton", GetComponent<AudioSource>().clip.length);
    }

    void AccionarBoton()
    {
		if(juego)
		{
			SceneManager.LoadScene(nombreEscenaParaCargar);
		} 
		else
		{
			#if UNITY_EDITOR 
			EditorApplication.isPlaying = false;
			#else 
			Application.Quit();
			#endif
		}
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
