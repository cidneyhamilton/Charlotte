EXTERNAL is_wounded()

VAR current_scene = "Next Day"

-> rest

=== rest ===
Narrator: { is_wounded(): "You recover from your wounds overnight.} Next morning...

-> rest.next_morning

= next_morning
Guard: Have you made a choice when to go to the cave?
* I'll go now, empty it, and wait for Charlotte.
    TODO: different version of the cave!
    ~ current_scene = "Cave"
    -> DONE
* I'll go immediately, after noon.
    TODO: different version of the cave!
    ~ current_scene = "Cave"
    -> DONE
    
=== function is_wounded() ===
~ return false