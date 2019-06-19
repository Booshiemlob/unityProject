using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        /*  This is the battle logic for my game
            Basically I times the level of the dancer by 3, then add one to ensure that the range matches the maximum number so that instead of between 1 - 3 
            (which would be 2) it's 1 - 4 which means there is a chance to roll more than 1 number. Then I added on the Rhythm and Style stats as flat modifiers.
            with luck, I wanted to times it by a random range between the luck stat and 1 adding on 1 to compensate for the range limitations.
         */
        // This is the bot's battle logic.
        int botlvl = data.npc.level * 3 + 1 + data.npc.rhythm + data.npc.style + ((data.npc.luck) * Random.Range(1, (data.npc.luck+1)));
        // This is the player's battle logic.
        int playerlvl = data.player.level * 3 + 1 + data.player.rhythm + data.player.style + ((data.player.luck) * Random.Range(1, (data.player.luck+1)));

        // So here I am calculating the actual dice roll to determine who wins.
        int bot = Random.Range(1, botlvl);
        int player = Random.Range(1, playerlvl); 

        // I am initialising the outcome variable to use it later on.
        float outcome;
        // So if the player's dice roll is higher than the bot's; the player wins.
        if (player > bot)
        {
            outcome = 1;

        }
        // If not, the player loses.
        else
        {
            outcome = -1;
        }

        // This is for debug purposes so that I can see the dice rolls.
        Debug.Log("Player" + player);
        Debug.Log("Bot" + bot);

        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
