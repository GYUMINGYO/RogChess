using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChessAI : MonoBehaviour
{
    private const int mapSize = 8; // 8x8
    
    // 적 기물
    [SerializeField] private List<GameObject> _enemyPieceList;
    // 플레이어 기물
    [SerializeField] private List<GameObject> _playerPieceList;
    
    // 기본 정보
    // 희귀도(가치), 등등 정보
    
    // 하나가 아닌 전반적인 애들이 봐야 하지 않나?
    // 지금 무슨 상황인지 알아야지
    
    private Dictionary<string, Vector3Int> _chessboard;
    
    public GameObject target;
    public Tilemap _chessboardTileMap;
    
    private void Initialized()
    {
        _chessboard = new Dictionary<string, Vector3Int>();
        
        InitChessboard();
    }
    
    private void Awake()
    {
        Initialized();
    }

    /// <summary>
    /// Initialized Chessboard square
    /// </summary>
    private void InitChessboard()
    {
        BoundsInt bounds = _chessboardTileMap.cellBounds;
        Vector3Int start = bounds.position;

        int numberingIndex = 1; // vertical
        int letteringIndex = 0; // horizontal
        
        for (int y = start.y; y < bounds.size.y; ++y)
        {
            letteringIndex = 0;
            for (int x = start.x; x < bounds.size.x; ++x)
            {
                Vector3Int position = new Vector3Int(x, y, 0);
                if(_chessboardTileMap.GetTile(position) == null)
                    continue;

                char lettering = (char)('a' + letteringIndex);
                string square = $"{lettering}{numberingIndex}";
                _chessboard.Add(square, new Vector3Int(x, y, 0));
                letteringIndex++;
            }
            numberingIndex++;
        }
    }

    public void PieceMove(Vector3 pos)
    {
        
    }
}
