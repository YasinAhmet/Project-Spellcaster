using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    public int perTick = 10;
    public bool loop = true;
    int tickCounter = 0;
    public bool finished = false;

    public bool Tick()
    {
        if (finished) return false;
        tickCounter++;

        if (tickCounter >= perTick)
        {
            if (!loop) finished = true;
            return true;
        }

        return false;
    }

    public void ResetTimer()
    {
        finished = false;
        tickCounter = 0;
    }
}
