VAR current_scene = "Entrance to City"

Captain: Do you even know what these hostages are?
* No.
Captain: Gang queen Charlotte kidnapped three merchant families. Fifteen people overall, favorites of His Majesty. 
Captain: Wants us to pay ransom or she executes them.
-> find_out_more

= find_out_more
* Who is Alexander, then? 
-> who_is_alexander
* Where is the cave? 
-> where_is_cave
* -> is_there_a_bounty

= who_is_alexander
{ not where_is_cave: You really don't know anything, do you?}
Captain: Alexander is the lead bandit on the road you came from, one of Charlotte's trusted lieutenants. 
-> find_out_more

= where_is_cave
{not who_is_alexander: You really don't know anything, do you?}
Captain: Alexander's cave is west of the city, it's his hideout.
-> find_out_more


= is_there_a_bounty
* Is there a bounty on these thugs?
    Captain: There is one on Charlotte, but not on Alexander. Good luck!
-
-> about_charlotte

= about_charlotte
* What can you tell me about Charlotte's crew?
    Captain: She's a fearsome warrior, and has ten or twenty people fighting by her side, including several archers.
    -> about_charlotte
* Will there even be anyone still around in the cave?
    Captain: Did you kill everyone on the road here?
    * * Yes.
        Captain: Yes, but just a few people.
        -> about_charlotte
    * * No.
        Captain: They'll be in the cave.
        -> about_charlotte
* Should I go before or after noon?
    Captain: Your call. Do you want to attack them in one large force but then you can retreat, or do you want to first empty the cave and then attack Charlotte?
    -> about_charlotte
* -> goodbye

= goodbye
- Captain: Good luck. If you succeed, His Majesty will look favorably upon you.
~ current_scene = "Next Day"
-> DONE