using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UICONTROLLER : MonoBehaviour
{
    public static bool first = true;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("SampleScene");
            }
        }

    public void playGame(){
        SceneManager.LoadScene("SampleScene");
        MouseLook.allowed = true;
		PlayerMovement.allowed = true;
    }
    public void quitGame(){
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
    }
}
