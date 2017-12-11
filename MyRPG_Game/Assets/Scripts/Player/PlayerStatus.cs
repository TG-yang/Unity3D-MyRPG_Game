using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour
{

    public int grade = 1;
    public int hp = 100;
    public int mp = 100;//魔法值
    public int coin = 200;

    public int attack = 20;
    public int attackPlus = 0;
    public int def = 20;
    public int defPlus = 0;
    public int speed = 20;
    public int speedPlus = 0;

    public int pointRemain = 30;
         

    public void GetCoint(int count)
    {
        coin += count;
    }

    public bool GetPoint(int point = 1)
    {
        if (pointRemain>=point)
        {
            pointRemain -= point;
            return true;
        }
        return false;
    }

   
}
