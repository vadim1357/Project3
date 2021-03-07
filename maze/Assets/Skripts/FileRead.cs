using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class FileRead : MonoBehaviour
{
    public CellScript[,] helper;
    public CellScript prefab;
    public MeshRenderer road;
    int playerPosX = 0;
    int playerPosZ = 0;
    List<int> pointPositionI = new List<int>();
    List<int> pointPositionJ = new List<int>();




    void Start()
    {
       
        var fileLines = File.ReadLines("C:\\MyPrograms/GitHub/Project3/maze/maze.txt");
        var fileLinesArray = fileLines.ToArray();
        var sizeLine = fileLinesArray[0].Split(' ');
        var v = int.Parse(sizeLine[0]);
        var h = int.Parse(sizeLine[1]);
        helper = new CellScript[v, h];

        
        for (var i = 0; i < v; i++)
        {
            var line = fileLinesArray[i + 1];
            for (var j = 0; j < h; j++)
            {
                helper[i, j] = Instantiate(prefab, transform);
                helper[i, j].transform.position = new Vector3(i, 0, j);

                helper[i, j].Create(line[j] - '0');
                if (line[j] - '0' == 2)
                {
                    playerPosX = i;
                    playerPosZ = j;
                }
            }
        }

        //Queue(playerPosX, playerPosZ);
    }


    private void Update()
    {
        Queue((int)PlayerSkript.Self.transform.position.x, (int)PlayerSkript.Self.transform.position.z);
    }


    public void Queue(int i, int j)
    {
        
        if (TheWayHome(i, j))
        {
            
            
            for (int a = pointPositionI.Count - 1; a >= 0; a--)
            {
                helper[pointPositionI[a], pointPositionJ[a]].PaveTheWay();
            }
        }
        ClearMarks();
        
    }


    public bool EnterRoad(int i, int j)
    {
        if (OutOfBorder(i, j) || helper[i, j].IsMarked() || helper[i, j].Wall())
        {
            return false;
        }
        Vector3 posRoad = new Vector3(i, 0, j);
        MeshRenderer newRoad = Instantiate(road);
        newRoad.transform.position = posRoad;
        helper[i, j].SetMark();

        EnterRoad(i + 1, j);
        EnterRoad(i - 1, j);
        EnterRoad(i, j + 1);
        EnterRoad(i, j - 1);
        return true;
    }


    public bool TheWayHome(int i, int j)
    {
        if (OutOfBorder(i, j))
        {
            return false;
        }
        if (helper[i, j].Wall())
        {
            return false;
        }
        if (helper[i, j].IsMarked2())
        {
            return false;
        }

        helper[i, j].SetMark2();

        if (helper[i, j].Finish())
        {
            return true;
        }

        if (TheWayHome(i + 1, j) ||
        TheWayHome(i - 1, j) ||
        TheWayHome(i, j + 1) ||
        TheWayHome(i, j - 1))
        {

            pointPositionI.Add(i);
            pointPositionJ.Add(j);
            return true;
        }
        return false;
    }

    private bool OutOfBorder(int i, int j)
    {
        if (i < 0 || i == helper.GetLength(0) || j < 0 || j == helper.GetLength(1))
        {
            return true;
        }
        return false;
    }
    public void ClearMarks()
    {
        for (int i = 0; i < helper.GetLength(0); i++)
        {
            for (int j = 0; j < helper.GetLength(1); j++)
            {
                helper[i, j].SetMark(false);
                helper[i, j].SetMark2(false);
            }
        }
    }
    public void Clear()
    {

    }
}


