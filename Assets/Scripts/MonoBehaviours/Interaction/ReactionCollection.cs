using UnityEngine;

// This script acts as a collection for all the
// individual Reactions that happen as a result
// of an interaction.
public class ReactionCollection : MonoBehaviour
{
    public Reaction[] reactions = new Reaction[0];      // Array of all the Reactions to play when React is called.

    private void Start ()
    {
        // Go through all the Reactions and call their Init function.
        for (int i = 0; i < reactions.Length; i++)
        {
            reactions[i].Init ();
        }
    }


    public void React ()
    {
        // Go through all the Reactions and call their React function.
        for (int i = 0; i < reactions.Length; i++)
        {
            reactions[i].React (this);
        }
    }
}
