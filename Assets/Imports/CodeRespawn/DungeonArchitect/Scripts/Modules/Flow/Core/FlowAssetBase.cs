using DungeonArchitect.Flow.Exec;
using UnityEngine;

namespace DungeonArchitect.Flow
{
    [System.Serializable]
    public class FlowAssetBase : ScriptableObject
    {
        [HideInInspector]
        [SerializeField]
        public FlowExecGraph execGraph;
    }
}