// The SceneReaction is used to change between scenes.
// Though there is a delay while the scene fades out,
// this is done with the SceneController class and so
// this is just a Reaction not a DelayedReaction.
public class SceneReaction : Reaction
{
    public string sceneName;                    // The name of the scene to be loaded.
   
    protected override void ImmediateReaction()
    {
        
        // Start the scene loading process.
        SceneController.Instance.SwitchScene (sceneName);
    }
}