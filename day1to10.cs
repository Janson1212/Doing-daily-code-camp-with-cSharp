using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

public class Non_static_functions
{
    public string[] avoid_words = {"and", "for", "an", "and", "by", "of"};
    public string[] file_size_unit = {"B", "KB", "MB", "GB","TB"};

    public string Build_acronym(string input)
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

    public int num_of_files_allow(float inp_file_size, string inp_file_size_unit, float GB_capcity)
    {   
        string unit = inp_file_size_unit.ToUpper();
        if (!file_size_unit.Contains(unit)) 
        {
            Console.WriteLine(inp_file_size_unit + "is not a given file size unit");
            return 0;
        } 
        else
        {   
            int index = System.Array.IndexOf(file_size_unit, inp_file_size_unit);
            while (unit != "GB")
            {   
                inp_file_size /= 1000;
                ++index;
                unit = file_size_unit[index];
            }
            return (int)( GB_capcity / inp_file_size);
        }
    }
    public int number_of_videos(float video_size,string video_unit,float drive_size,string drive_unit)
    {
        if (!file_size_unit.Contains(video_unit)) 
        {
            Console.WriteLine(video_unit + "is not a given file size unit");
            return 0;
        } 
        else if (!file_size_unit.Contains(drive_unit)) 
        {
            Console.WriteLine(drive_unit + "is not a given file size unit");
            return 0;
        } 
        else
        {
            int video_index = System.Array.IndexOf(file_size_unit, video_unit);
            int drive_index = System.Array.IndexOf(file_size_unit, drive_unit);
            if (video_index > drive_index)
            {
                Console.WriteLine("file is too large for the drive");
                return 0;
            }
            else if (video_index == drive_index && video_size > drive_size)
            {
                Console.WriteLine("file is too large for the drive");
                return 0;
            }
            else 
            {
                while (video_index != drive_index)
                {
                    --drive_index;
                    drive_size *= 1000; 
                }
                return (int)(drive_size / video_size);
            }
            
        }
    }
}



public class Main_loop
{
    public bool All_unique(string input)
    {   
        List<char> exist_chara = new List<char>();
        for (int i = 0; i < input.Length; i++)
        {
            if (exist_chara.Contains(input[i])) return false;
            exist_chara.Add(input[i]);
        }
        return true;
    }

    public string Build_slug(string input)
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

    public string Fill_gallon_price(decimal max_size, decimal current_size, decimal price_per_unit)
    {
        decimal missing_size = max_size - current_size;
        decimal final_price = Math.Round(missing_size * price_per_unit, 2);
        string output_price = "$" + final_price.ToString();
        return output_price;
    }
}