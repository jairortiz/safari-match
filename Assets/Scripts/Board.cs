using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Board : MonoBehaviour
{
    public int width;
    public int height;

    public float cameraSizeOffset;
    public float cameraVerticalOffset;

    public GameObject tileObject;

    public GameObject[] availablePices;
    void Start()
    {
        SetupBoard();
        PositionCamera();
        SetupPieces();
    }

    private void PositionCamera()
    {
        float offSet = 0.5f;
        float posX = (float)width / 2f - offSet;
        float posY = (float)height / 2f - offSet;
        Camera.main.transform.position = new Vector3(posX, posY + cameraVerticalOffset, -10f);

        float horizontal = width + 1;
        float vertical = (height / 2 ) + 1;

        Camera.main.orthographicSize = horizontal > vertical ? horizontal + cameraSizeOffset : vertical;
    }

    private void SetupBoard()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tileObject, new Vector3(x, y, 0), Quaternion.identity);
                tile.transform.parent = transform;                
                tile.GetComponent<Tile>()?.Setup(x, y, this);
                //tile.name = $"Tile {x},{y}";
            }
        }
    }

    private void SetupPieces()
    {
        System.Random rand = new System.Random();
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var selectedPiece = availablePices[rand.Next(availablePices.Length)];
                GameObject pieceObject = Instantiate(selectedPiece, new Vector3(x, y, 0), Quaternion.identity);
                pieceObject.transform.parent = transform;                
                pieceObject.GetComponent<Piece>()?.Setup(x, y, this);
                //pieceObject.name = $"Piece {x},{y}";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
