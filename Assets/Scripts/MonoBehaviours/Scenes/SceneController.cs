using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController> {

    public string StartingSceneName { get; set; } 

    const string UI_SCENE = "User Interface";

    // Called from triggers between areas when the player wants to switch scenes
    public void SwitchScene(string sceneName) {
        StartCoroutine(SwitchScenes(sceneName));
    }

    private IEnumerator Start ()
    {
        if (StartingSceneName == null) {
            StartingSceneName = "Ravine";   
        }

        yield return StartCoroutine(LoadUI());

        // Load Start Scene
        yield return StartCoroutine (LoadSceneAndSetActive (StartingSceneName));

        // TODO: Fade in, nicely?
    }

    private IEnumerator LoadUI() {
         // Load UI
        yield return SceneManager.LoadSceneAsync(UI_SCENE, LoadSceneMode.Additive);
    }

    private IEnumerator SwitchScenes(string sceneName) {
        // TODO: Fade Out
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);

        yield return LoadSceneAndSetActive(sceneName);

        // TODO: Fade in
    }
    private IEnumerator LoadSceneAndSetActive (string sceneName)
    {
        
        yield return SceneManager.LoadSceneAsync (sceneName, LoadSceneMode.Additive);

        Scene newlyLoadedScene = SceneManager.GetSceneAt (SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene (newlyLoadedScene);
    }
}
