using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Count_tools : MonoBehaviour
{
    public static int metal_all_sources;
    public static int wood_all_sources;
    public static int other_all_sources;
    public static int rocks_all_sources;
    string[] fields;

    public void LoadFile()
    {
        StreamReader sourceFile = new StreamReader("Resource.txt");
        while (!sourceFile.EndOfStream)
        {
            fields = sourceFile.ReadLine().Split(',');
            other_all_sources = int.Parse(fields[0]);
            metal_all_sources = int.Parse(fields[1]);
            wood_all_sources = int.Parse(fields[2]);
            rocks_all_sources = int.Parse(fields[3]);
        }
        sourceFile.Close();
    }

    public void WriteFile(int tools, int metal, int wood, int rocks)
    {
        
        StreamWriter writeFile = new StreamWriter("Resource.txt");
        string str = tools.ToString() + "," + metal.ToString() + "," + wood.ToString() + "," + rocks.ToString();
        writeFile.WriteLine(str);
        writeFile.Close();
    }


}
