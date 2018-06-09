using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TextReaction))]
public class TextReactionEditor : ReactionEditor
{
    private SerializedProperty messageProperty;         // Represents the string field which is the message to be displayed.

    private const float messageGUILines = 3f;           // How many lines tall the GUI for the message field should be.
    private const float areaWidthOffset = 19f;          // Offset to account for the message GUI being made of two GUI calls.  It makes the GUI line up.
    private const string textReactionPropMessageName = "message";
                                                        // The name of the field which is the message to be written to the screen.

    protected override void Init ()
    {
        // Cache all the SerializedProperties.
        messageProperty = serializedObject.FindProperty (textReactionPropMessageName);
    }


    protected override void DrawReaction ()
    {
        EditorGUILayout.BeginHorizontal ();
        
        // Display a label whose width is offset such that the TextArea lines up with the rest of the GUI.
        EditorGUILayout.LabelField ("Message", GUILayout.Width (EditorGUIUtility.labelWidth - areaWidthOffset));

        // Display an interactable GUI element for the text of the message to be displayed over several lines.
        messageProperty.stringValue = EditorGUILayout.TextArea (messageProperty.stringValue, GUILayout.Height (EditorGUIUtility.singleLineHeight * messageGUILines));
        EditorGUILayout.EndHorizontal ();

    }


    protected override string GetFoldoutLabel ()
    {
        return "Text Reaction";
    }
}
