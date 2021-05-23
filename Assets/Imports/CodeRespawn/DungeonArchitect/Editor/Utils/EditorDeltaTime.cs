using UnityEditor;

namespace DungeonArchitect.Editors
{
    public class EditorDeltaTime
    {
        private double lastUpdateTimestamp = EditorApplication.timeSinceStartup;
        public float DeltaTime { get; set; } = 0;
        
        public void Tick()
        {
            double currentTime = EditorApplication.timeSinceStartup;
            DeltaTime = (float)(currentTime - lastUpdateTimestamp);
            lastUpdateTimestamp = currentTime;
        }
    }
}