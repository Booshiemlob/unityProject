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
        //This executes if the player wins the battle.
        if (data.outcome == 1)
        {
            //I want to give the player exp based on their level times 10.
            data.player.XP += data.player.level *10;
            //When the NPC loses they still gain a small amount of exp based on their level times 4.
            data.npc.XP += data.npc.level * 4;


        }
        //This executes if the player loses the battle
        else
        {
            data.player.XP += data.player.level * 4;
            //I want the NPC to gain exp at a slower rate to ensure that it's not too unfair.
            data.npc.XP += data.npc.level * 8;

               
            }
        
        //This levels the player up if their exp exceeds 100 times their present level plus 50, this then goes on to give the player additional stats for levelling up.
        if (data.player.XP >= 100 * data.player.level+50)
        {
                data.player.XP = 0;
                data.player.level += 1;
                data.player.luck += 1;
                data.player.style += 1;
                data.player.rhythm += 1;
                //This is just a string that displays a level up message when the player levels up.
                Debug.Log("Congratulations, you have reached level " + data.player.level);

        }

        //This is the same as above but it applies to the NPC.
        if (data.npc.XP >= 100 * data.npc.level + 50)
        {
                data.npc.XP = 0;
                data.npc.level += 1;
                data.npc.luck += 1;
                data.npc.style += 1;
                data.npc.rhythm += 1;
         
        }
    }
}
