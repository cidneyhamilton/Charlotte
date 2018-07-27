// Conditions
EXTERNAL has_item(s)

// Variables to observe
VAR current_scene = "Ravine"

-> Exit

=== Exit ===
Narrator: This way leads north, to King Henry's Castle.
* { has_item("letter") }[Go north]
    ~ current_scene = "Entrance to City"
    -> DONE
+ Turn Back
    -> DONE
    
 === function has_item(s) ===
// Usually external functions can only return placeholder
// results, otherwise they'd be defined in ink!
~ return false

