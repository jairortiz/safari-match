using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Piece : MonoBehaviour  
{
    public int x;
    public int y;
    public Board board;

    public enum Type
    {
        elephant,
        giraffe,
        hippo,
        monkey,
        panda,
        parrot,
        penguin,
        pig,
        rabbit,
        snake
    }
    public Type type;

    public void Setup(int _x, int _y, Board _board)
    {
        x = _x;
        y = _y;
        board = _board;
    }

    public void Move(int desX, int desY)
    {        
        x = desX;
        y = desY;
        transform.position = new Vector3(desX, desY, 0);
    }
}
