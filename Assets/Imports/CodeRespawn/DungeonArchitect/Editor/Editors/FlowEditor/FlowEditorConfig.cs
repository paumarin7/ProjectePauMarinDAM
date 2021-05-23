using UnityEngine;

namespace DungeonArchitect.Editors.Flow
{
    public abstract class FlowEditorConfig : ScriptableObject
    {
        public bool randomizeSeed = true;
        public int seed = 0;

        public abstract DungeonBuilder FlowBuilder { get; }
        
    }
}
