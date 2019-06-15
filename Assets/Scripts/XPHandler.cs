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
    public void UpdateXp(int xp, Stats stats)
    {
        stats.XP += xp;

        int curlvl =(int)(0.1f * Mathf.Sqrt(xp));

        if(curlvl != stats.level)
        {
            stats.level = curlvl;
            Debug.Log("Congratz on reaching a new level!");
        }

        int xpnextlevel = 100 + (stats.level + 1) * (stats.level + 1);
        int diffxp = xpnextlevel - stats.XP;

        int totalDiff = xpnextlevel - (100 * stats.level * stats.level);

    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    public void GainXP(BattleResultEventData data)
    {
    }
}
