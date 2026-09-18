using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class AcronymBuilder
{
    public string[] avoid_words = {"and", "for", "an", "and", "by", "of"};

    public string build_acronym(string input)
    {
        string[] split_input = input.Split(' ');
        string acro = "";
        for (int i = 0; i < split_input.Length; i++)
        {
            if (i == 0) acro += split_input[i][0].ToString().ToUpper();
            else if (!avoid_words.Contains(split_input[i]))
            {
                acro += split_input[i][0].ToString().ToUpper();
            }
        }
        return acro;
    }
}



public class Main_loop
{
    bool All_unique(string input)
    {   
        List<char> exist_chara = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (exist_chara.Contains(input[i])) return false;
            exist_chara.Add(input[i]);
        }
        return true;
    }

    string Build_slug(string input)
    {
        string clean_input = Regex.Replace(input.ToLower(), @"[^a-z0-9 ]", "");
        string[] split_input = clean_input.Split();
        string final_string = "";
        string past_string = "";
        for (int w = 0; w < split_input.Length; w++)
        {   
            if (past_string != "" && split_input[w] != "") final_string += "%20";
            final_string += split_input[w];
            past_string = split_input[w];
        }
        return final_string;
    }   

    string Fill_gallon_price(decimal max_size, decimal current_size, decimal price_per_unit)
    {
        decimal missing_size = max_size - current_size;
        decimal final_price = Math.Round(missing_size * price_per_unit, 2);
        string output_price = "$" + final_price.ToString();
        return output_price;
    }

    static void Main(string[] args)
    {   
        Main_loop static_functions = new Main_loop();
        /*
        AcronymBuilder acro_builder = new AcronymBuilder();
        string test1 = acro_builder.build_acronym("National Aeronautics and Space Administration");
        Console.WriteLine(test1);
        bool test2 = static_functions.All_unique("!@#*$%^&*()aA");
        Console.WriteLine(test2);
        string test3 = static_functions.Build_slug("  ?H^3-1*1]0! W[0%R#1]D  ");
        Console.WriteLine(test3);
        */
        string test4 = static_functions.Fill_gallon_price(15M, 9.5M, 3.98M);
        Console.WriteLine(test4);
    }
}