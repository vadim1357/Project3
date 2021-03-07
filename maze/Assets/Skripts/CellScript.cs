using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool finishFound = false;
    int gameValue;
    bool mark;
    bool mark2;
    MeshRenderer spawnRoad;
    
    public MeshRenderer roadToFinish;
    public MeshRenderer wall; // 1
    public MeshRenderer player; //2
    public MeshRenderer finish; //3
    public MeshRenderer road;
    
    public void Create(int i)
    {
        gameValue = i;
        
        mark = false;
        mark2 = false;
        switch (gameValue)
        {
            case 1:
                MeshRenderer newWall = Instantiate(wall,transform);
                break;
            case 2:

                MeshRenderer newPlayer = Instantiate(player,transform);

                break;

            case 3:

                MeshRenderer newFinish = Instantiate(finish,transform);

                break;
        }
    }

    public bool Wall()
    {
        if (gameValue == 1)
        {
            return true;
        }
        return false;
    }

    public bool Finish()
    {

        if (gameValue == 3)
        {
            finishFound = true;
            return true;
        }
        return false;
    }
    public bool IsMarked()
    {
        if (mark)
        {
            return true;
        }
        return false;
    }
    public bool IsMarked2()
    {
        if (mark2)
        {
            return true;
        }
        return false;
    }
    public void SetMark(bool state = true)
    {
        mark = state;
    }
    public void SetMark2(bool state = true)
    {
        mark2 = state;
    }
    public void PaveTheWay()
    {

        MeshRenderer newRoad = Instantiate(roadToFinish, transform);
        spawnRoad = newRoad;

    }
    public void ClearWay()
    {
        if(spawnRoad!= null)
        {
            Destroy(spawnRoad.gameObject);
        }
        
    }

}
