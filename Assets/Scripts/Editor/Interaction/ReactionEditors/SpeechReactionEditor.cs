using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpeechReaction))]
public class SpeechReactionEditor : ReactionEditor {

    private SerializedProperty messagesProperty;  
    private SerializedProperty speakerProperty;  

    private const float messageGUILines = 3f;           // How many lines tall the GUI for the message field should be.
    private const float areaWidthOffset = 19f;          // Offset to account for the message GUI being made of two GUI calls.  It makes the GUI line up.
    private const string speechReactionPropMessagesName = "messages";
    private const string speechReactionPropSpeakerName = "speakerName";


	protected override void Init ()
    {
        // Cache all the SerializedProperties.
        messagesProperty = serializedObject.FindProperty (speechReactionPropMessagesName);
        speakerProperty = serializedObject.FindProperty (speechReactionPropSpeakerName);
    }


    protected override void DrawReaction ()
    {
        EditorGUILayout.BeginHorizontal ();
        
        // Display a label whose width is offset such that the TextArea lines up with the rest of the GUI.
        EditorGUILayout.LabelField ("Speaker Name", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));

        // Display an interactable GUI element for the text of the message to be displayed over several lines.
        speakerProperty.stringValue = EditorGUILayout.TextArea (speakerProperty.stringValue, GUILayout.Height (EditorGUIUtility.singleLineHeight));
        EditorGUILayout.EndHorizontal ();

        EditorGUILayout.PropertyField(messagesProperty, new GUIContent("Dialogue Lines"), true);
        // EditorGUILayout.BeginHorizontal ();

        // // Display a label whose width is offset such that the TextArea lines up with the rest of the GUI.
        // EditorGUILayout.LabelField ("Message", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));

        // // Display an interactable GUI element for the text of the message to be displayed over several lines.
        // messagesProperty.stringValue = EditorGUILayout.TextArea (messagesProperty.stringValue, GUILayout.Height (EditorGUIUtility.singleLineHeight * messageGUILines));
        // EditorGUILayout.EndHorizontal ();

    }


    protected override string GetFoldoutLabel ()
    {
        return "Speech Reaction";
    }

}
