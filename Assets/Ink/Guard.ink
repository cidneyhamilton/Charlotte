State your name, stranger.
* Give your name
We're not expecting anyone by that name. 
By order of His Majesty King Henry, nobody may enter. 
We don't want more bandits here. -> not_a_bandit

=== not_a_bandit ===
* I'm looking for work as a traveling adventurer.
    You can't help us. -> not_a_bandit
* Those bandits just tried to kill me on the road!
    But you made it? Good, it means the road is safe for you, now turn back. -> not_a_bandit
* -> have_information
    
=== have_information ===
* I have information about these bandits. 
-> what_could_you_know

=== what_could_you_know ===
What could you possibly know? 
* If it's useful, will you let me in?
    What is it?
    * * I know when the gang is transferring hostages.
        The guards reads C's note to Alexander.
        You killed Alexander? Great, come on in.
        TODO: Remove guard.
-> END