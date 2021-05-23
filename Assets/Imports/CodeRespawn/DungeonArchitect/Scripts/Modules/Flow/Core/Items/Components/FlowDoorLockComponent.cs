using UnityEngine;

namespace DungeonArchitect.Flow.Items
{
    public class FlowDoorLockComponent : MonoBehaviour
    {
        public string lockId;
        public string[] validKeyIds = new string[0];
        public FlowDoorKeyComponent[] validKeyRefs = new FlowDoorKeyComponent[0];
    }
}
