using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour {

	// The json compiled ink story
    public TextAsset OnEnteredStory;

    // The ink runtime story object
    private Story story;
    
    const string START = "Start"; // first scene of the game

    private IEnumerator Start() {
         // Bootstrap game from any scene
        if (SceneManager.GetSceneByName(START).IsValid() == false) {
            Debug.Log("Start scene not found; bootstrapping.");
            yield return LoadStartScene();
            SceneController.Instance.onEntered += EnterRoom;
        } else {
            EnterRoom();
        }
    	
    }

    private IEnumerator LoadStartScene() {
        yield return SceneManager.LoadSceneAsync(START, LoadSceneMode.Additive);
    }

    void EnterRoom() {
        if (OnEnteredStory) {
            story = new Story(OnEnteredStory.text);
            // story.ChoosePathString("Entered");
            DialogManager.Instance.BeginStory(story);
        }
        SceneController.Instance.onEntered -= EnterRoom;
    }

}
