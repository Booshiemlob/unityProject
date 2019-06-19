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
        int botlvl = data.npc.level*3+1;
        int playerlvl = data.player.level * 3 + 1;

        int bot = Random.Range(1, botlvl);
        int player = Random.Range(1, playerlvl); 

        float outcome;
        if (player > bot)
        {
            outcome = 1;
        }
        else
        {
            outcome = 0;
        }
         
        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);
    }
}
