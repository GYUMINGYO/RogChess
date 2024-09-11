using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChessPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPiece;
    [SerializeField] private LayerMask _whatIsGround;

    private GameObject currentPiece = null;
    public Tilemap _chessboardTileMap;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitInfo;
            Vector3 cameraPos = Camera.main.transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (currentPiece != null)
            {
                Vector3Int cellPos = _chessboardTileMap.WorldToCell(mousePos);
                TileBase tile = _chessboardTileMap.GetTile(cellPos);
                
                if (tile != null)
                {
                    Debug.Log("땅");
                    currentPiece.transform.position = _chessboardTileMap.GetCellCenterLocal(cellPos);
                }
                else
                    currentPiece = null;
            }
            else
            {
                hitInfo = Physics2D.Raycast(
                    cameraPos,
                    mousePos,
                    Mathf.Infinity,
                    _whatIsPiece);
                
                if (hitInfo)
                {
                    Debug.Log("기물");
                    currentPiece = hitInfo.transform.gameObject;
                }
            }
        }
    }
}
