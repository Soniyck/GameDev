using UnityEngine;
using System.Collections;
using AppConfiguration;

public class Master{

    public bool RollDice(int difficulty)
    {
        System.Random rand = new System.Random();
        // Base probability
        int spawnProbability = 20;

        // Added value
        spawnProbability += (100 - spawnProbability) / (HardConfiguration.MaxDifficulty) * difficulty;


        if(spawnProbability < rand.Next(1, 101))
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
