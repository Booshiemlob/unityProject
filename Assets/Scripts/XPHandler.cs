using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>



public class XPHandler : MonoBehaviour
{
    string lvlup = "Congratulations you have levelled up!";


    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        if (data.outcome == 1)
        {
            data.player.XP += data.player.level *10;
            data.npc.XP += data.npc.level * 4;


        }
        else
        {
            data.player.XP += data.player.level * 4;
            data.npc.XP += data.npc.level * 10;

               
            }
    
                if (data.player.XP >= 200)
            {
                data.player.XP = 0;
                data.player.level += 1;
                data.player.luck += 1;
                data.player.style += 1;
                data.player.rhythm += 1;
                Debug.Log(lvlup);

            }
            if (data.npc.XP >= 200)
            {
                data.npc.XP = 0;
                data.npc.level += 1;
                data.npc.luck += 1;
                data.npc.style += 1;
                data.npc.rhythm += 1;
         
            }
    }
}
