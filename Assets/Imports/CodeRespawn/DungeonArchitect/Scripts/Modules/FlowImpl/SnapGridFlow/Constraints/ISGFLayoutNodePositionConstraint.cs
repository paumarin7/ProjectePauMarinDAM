using UnityEngine;

namespace DungeonArchitect
{
    public interface ISGFLayoutNodePositionConstraint
    {
        bool CanCreateNodeAt(int currentPathPosition, int totalPathLength, Vector3Int nodeCoord, Vector3Int gridSize);
    }
}