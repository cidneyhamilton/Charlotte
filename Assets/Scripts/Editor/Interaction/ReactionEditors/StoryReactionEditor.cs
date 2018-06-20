using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StoryReaction))]
public class StoryReactionEditor : ReactionEditor {

    private SerializedProperty storyJSONProperty;  

    private const string storyJSONPropName = "storyJSON";

    protected override void Init ()
    {
        // Cache all the SerializedProperties.
        storyJSONProperty = serializedObject.FindProperty (storyJSONPropName);
    }

    protected override void DrawReaction ()
    {
        EditorGUILayout.BeginHorizontal ();
        
        EditorGUILayout.PropertyField(storyJSONProperty, new GUIContent("Story JSON"), true);

        EditorGUILayout.EndHorizontal ();
    }

    protected override string GetFoldoutLabel ()
    {
        return "Story Reaction";
    }

}
