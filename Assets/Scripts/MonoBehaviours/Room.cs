using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;

using Cyborg.Scenes;

public class Room : MonoBehaviour {

	// The json compiled ink story
    public TextAsset OnEnteredStory;

    // The ink runtime story object
    private Story story;

	void OnEnable() {
		SceneController.AfterSceneLoad += EnterRoom;
	}

	void OnDisable() {
		SceneController.AfterSceneLoad -= EnterRoom;
	}

    void EnterRoom() {
        if (OnEnteredStory) {
            story = new Story(OnEnteredStory.text);
            // story.ChoosePathString("Entered");
            DialogManager.Instance.BeginStory(story);
        }

    }

}
