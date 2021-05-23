using UnityEngine;

namespace DungeonArchitect.Flow.Items
{
    public class FlowDoorKeyComponent : MonoBehaviour
    {
        public string keyId;
        public string[] validLockIds = new string[0];

        public FlowDoorLockComponent[] lockRefs;
    }
}
