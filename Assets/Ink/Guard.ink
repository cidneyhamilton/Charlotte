VAR current_scene = "Entrance to City"

Guard: State your name, stranger.
* Give your name
Guard: We're not expecting anyone by that name. 
Guard: By order of His Majesty King Henry, nobody may enter. 
Guard: We don't want more bandits here. -> not_a_bandit

=== not_a_bandit ===
* I'm looking for work as a traveling adventurer.
    Guard: You can't help us. -> not_a_bandit
* Those bandits just tried to kill me on the road!
    Guard: But you made it? Good, it means the road is safe for you, now turn back. -> not_a_bandit
* -> have_information
    
=== have_information ===
* I have information about these bandits. 
-> what_could_you_know

=== what_could_you_know ===
Guard: What could you possibly know? 
* If it's useful, will you let me in?
    Guard: What is it?
    * * I know when the gang is transferring hostages.
        Narrator: The guards reads C's note to Alexander.
        Guard: You killed Alexander? Great, come on in.
        TODO: Remove guard.
-> END