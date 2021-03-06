﻿using Crawl.Models;
using System.Diagnostics;

namespace Crawl.GameEngine
{
    class AutoBattleEngine
    {
        public BattleEngine BattleEngine = new BattleEngine();

        public bool RunAutoBattle()
        {
            // Auto Battle, does all the steps that a human would do.

            // Picks 6 Characters
            if (BattleEngine.AddCharactersToBattle() == false)
            {
                // Error, so exit...
                return false;
            }

            // Start
            BattleEngine.StartBattle(true);

            Debug.WriteLine("Battle Start" + " Characters :" + BattleEngine.CharacterList.Count);

            // Initialize the Rounds
            BattleEngine.StartRound();

            RoundEnum RoundResult;

            // Fight Loop. Continue until Game is Over...
            do
            {
                // Do the turn...
                RoundResult = BattleEngine.RoundNextTurn();

                // If the round is over start a new one...
                if (RoundResult == RoundEnum.NewRound)
                {
                    BattleEngine.NewRound();
                    Debug.WriteLine("New Round :" + BattleEngine.BattleScore.RoundCount);
                }

            } while (RoundResult != RoundEnum.GameOver);

            BattleEngine.EndBattle();

            return true;
        }

        /// <summary>
        /// Returns the Score from the current Battle Instance
        /// </summary>
        /// <returns>the score value</returns>
        public int GetScoreValue()
        {
            return BattleEngine.BattleScore.ScoreTotal;
        }

        /// <summary>
        /// Returns the current Score Object
        /// </summary>
        /// <returns>Current Score Object</returns>
        public Score GetScoreObject()
        {
            return BattleEngine.BattleScore;
        }

        /// <summary>
        /// Returns the number of Rounds in the battle
        /// </summary>
        /// <returns>the count of rounds</returns>
        public int GetRoundsValue()
        {
            return BattleEngine.BattleScore.RoundCount;
        }

        /// <summary>
        /// Retruns a formated String of the Results of the Battle
        /// </summary>
        /// <returns></returns>
        public string GetResultsOutput()
        {
            string myResult = ""+
                    " Battle Ended" + BattleEngine.BattleScore.ScoreTotal +
                    " Total Score :" + BattleEngine.BattleScore.ExperienceGainedTotal +
                    " Total Experience :" + BattleEngine.BattleScore.ExperienceGainedTotal +
                    " Rounds :" + BattleEngine.BattleScore.RoundCount +
                    " Turns :" + BattleEngine.BattleScore.TurnCount +
                    " Monster Kills :" + BattleEngine.BattleScore.MonstersKilledList;

            Debug.WriteLine(myResult);

            return myResult;
        }
    }
}
