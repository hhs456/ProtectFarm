using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {
    private string nextScene;
    public void SetNextScene(string sceneName) {
        GetComponent<Animator>().Play("Exit");
        nextScene = sceneName;
    }

    public void LoadScene() {
        SceneManager.LoadScene(nextScene);
    }
}
