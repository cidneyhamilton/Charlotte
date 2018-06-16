using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StoryReaction : Reaction {

    // The json compiled ink story
    public TextAsset storyJSON;

    // The ink runtime story object
    private Story story;

    void Awake() {
        story = new Story(storyJSON.text);
    }
    
    protected override void ImmediateReaction() {
        DialogManager.Instance.AdvanceStory(story);
    }

}
