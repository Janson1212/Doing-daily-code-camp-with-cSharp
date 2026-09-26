using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class part2
{
    public static List<float> speed_check(List<float> cars_speed, float max_speed )
    {   
        float total_exceed = 0;
        int num_exceed = 0;
        for (int i = 0; i < cars_speed.Count; i++)
        {
            if (cars_speed[i] > max_speed)
            {
                total_exceed += (cars_speed[i] - max_speed);
                num_exceed += 1;
            }
        }
        if (num_exceed == 0) return (new List<float> {num_exceed, 0});
        else return (new List<float> {num_exceed, total_exceed / num_exceed});
    }
}