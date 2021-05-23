using UnityEngine;

namespace DungeonArchitect
{
    public interface IGridFlowLayoutNodePositionConstraint
    {
        bool CanCreateNodeAt(int currentPathPosition, int totalPathLength, Vector2Int nodeCoord, Vector2Int gridSize);
    }
}