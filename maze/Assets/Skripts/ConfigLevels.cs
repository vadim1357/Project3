using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ConfigLevels : MonoBehaviour
{
    List<string> fileLines = new List<string>();
    private void Awake()
    {
        fileLines.AddRange( File.ReadLines("Config.txt"));
        
    }
    
   public string PathLevel(int i)
    {
        
        return fileLines[i%fileLines.Count];
    }
}
