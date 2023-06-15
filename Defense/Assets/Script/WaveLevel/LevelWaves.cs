
using System;
using UnityEngine;

public class LevelWaves : MonoBehaviour
{
    public string[,] evel;

    public LevelWaves(int row, int columns) 
    {
        evel = new string[row, columns];
    }

    public virtual void FillArray(params string[][] strings)
    {
        Console.WriteLine("Filling array with default values.");
        for (int i = 0; i < evel.GetLength(0); i++)
        {
            for (int j = 0; j < evel.GetLength(1); j++)
            {
              
                evel[i, j] = strings[i][j];
            }
        }
    }

}
