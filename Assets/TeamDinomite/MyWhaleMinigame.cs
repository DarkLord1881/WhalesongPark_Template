using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWhaleMinigame : MinigameBase
{
    [Header("Game Specific variables")]

    [SerializeField] private PlayerController[] m_Players;
    int[] m_Scores;
    /// <summary>
    /// This function is called at the end of the game so that it knows what to display on the score screen.
    /// You give it information about what each players score was, how much time they earned individually, and also how much time they've earned together
    /// </summary>
    /// <returns>A class that contains all the necessary information to display the score page</returns>
    public override GameScoreData GetScoreData()
    {
        //Here's an example of how you might generate scores
        int teamTime = 0;
        GameScoreData gsd = new GameScoreData();
        for (int i = 0; i < 4; i++)
        {
            if (PlayerUtilities.GetPlayerState(i) == Player.PlayerState.ACTIVE)
            {
                gsd.PlayerScores[i] = m_Scores[i];                        //Each player scored one point
                gsd.PlayerTimes[i] = gsd.PlayerScores[i] * 2;   //Each player gets two seconds per point scored
                teamTime += gsd.PlayerTimes[i];                 //Keep a running total of the total time scored by all players
            }
        }
        gsd.ScoreSuffix = " points";    //This lets you write something after the player's score.
        gsd.TeamTime = teamTime;
        return gsd;
    }

    /// <summary>
    /// How do you want to handle input from the four directional buttons?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    /// <param name="direction">Which direction(s) are they pressing</param>
    public override void OnDirectionalInput(int playerIndex, Vector2 direction)
    {
        m_Players[playerIndex].HandleDirectionalInput(direction);
    }
    /// <summary>
    /// What should happen when the player presses the left hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnPrimaryFire(int playerIndex)
    {
    }

    /// <summary>
    /// What should happen when the player presses the right hand button?
    /// </summary>
    /// <param name="playerIndex">Which player (0-3) pressed the button</param>
    public override void OnSecondaryFire(int playerIndex)
    {
       
    }

    public override void TimeUp()
    {
        //Do you want to do something when the minigame timer runs out?
        //This is where you do that!
    }

    protected override void OnResetGame()
    {
        //Is there any cleanup you have to do when the game gets totally reset?
        //This might just be empty!

    }

    private void FixedUpdate()
    {
        
    }
}
