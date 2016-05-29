using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BotonesMenuPrincipal : MonoBehaviour {

	public bool juego=true;

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
			SceneManager.LoadScene("Juego");
		} 
		else
		{
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
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
