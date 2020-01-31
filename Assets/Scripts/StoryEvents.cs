using Ink.Runtime;

namespace Charlotte {
    
    public class StoryEvents
    {
	public delegate void OnBeginStoryDelegate(Story story);
	public static OnBeginStoryDelegate OnBeginStory;

	public delegate void OnChooseDelegate(int choiceIndex);
	public static OnChooseDelegate OnChoose;

	public delegate void OnSayTextDelegate(string text);
	public static OnSayTextDelegate OnSay;

	public delegate void OnAddDialogueDelegate(string[] messages, string speakerName);
	public static OnAddDialogueDelegate OnAddDialogue;
	
	public static void BeginStory(Story story) {
	    if (OnBeginStory != null) {
		OnBeginStory(story);
	    }
	}

	public static void Choose(int choiceIndex) {
	    if (OnChoose != null) {
		OnChoose(choiceIndex);
	    }
	}

	public static void Say(string text) {
	    if (OnSay != null) {
		OnSay(text);
	    }
	}

	public static void AddDialogue(string[] messages, string speakerName) {
	    if (OnAddDialogue != null) {
		OnAddDialogue(messages, speakerName);
	    }
	}
    }
}
