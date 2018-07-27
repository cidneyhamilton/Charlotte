// Conditions
EXTERNAL has_item(s)

// Variables to observe
VAR current_scene = "Cave"

-> Cage

=== Cage ===
This cage was obviously meant to contain hostages.
* { !has_item("key") } [Open Cage]
    It's locked, and you don't have the key. 
    -> Cage
* { has_item("key") } [Unlock Cage]
    Congratulations, you've rescued the hostages!
    ~ current_scene = "Throne Room"
    -> DONE
+ Leave
    -> DONE


 === function has_item(s) ===
// Usually external functions can only return placeholder
// results, otherwise they'd be defined in ink!
~ return false

