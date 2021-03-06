using UnityEngine;
using System.Collections;

public class ApplicationManager : MonoBehaviour {
	public GameObject go;
	public Camera FrontViewCamera;
	public void Play(){
		go.SetActive(false);
		HealthController.current_love_health = 100f;
		MouseLook.allowed = true;
		PlayerMovement.allowed = true;
		Destroy(FrontViewCamera);
	}

	void Start(){
		go.SetActive(false);
		Destroy(FrontViewCamera);
	}
	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

	void Update (){
		if(Input.GetKeyDown(KeyCode.Q)){
			go.SetActive(true);
		}
	}

	

}
