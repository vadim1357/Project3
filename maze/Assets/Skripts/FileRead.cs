using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class FileRead : MonoBehaviour
{

    public GameObject wall; // 1
    public GameObject player; //2
    public GameObject finish; //3


    void Start()
    {
        var fileLines = File.ReadLines("D:\\VS/input.txt");
        var fileLinesArray = fileLines.ToArray();
        var sizeLine = fileLinesArray[0].Split(' ');
        var v = int.Parse(sizeLine[0]);
        var h = int.Parse(sizeLine[1]);


        for (var i = 0; i < h; i++)
        {
            var line = fileLinesArray[i + 1];
            for (var j = 0; j < v; j++)
            {

                int curElem = line[j]-'0';
                Debug.Log(curElem);
 
                Vector3 pos = new Vector3(i, 0, j);

               switch (curElem)
                {

                    case 1:
                        GameObject newWall = Instantiate(wall);
                        newWall.transform.position = pos;
                        break;


                    case 2:

                        GameObject newPlayer = Instantiate(player);
                        newPlayer.transform.position = pos;
                        break;


                    case 3:

                        GameObject newFinish = Instantiate(finish);
                        newFinish.transform.position = pos;
                        break;

                }



            }
        }









    }
}
