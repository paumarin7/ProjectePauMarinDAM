using UnityEngine;

namespace DungeonArchitect.Flow.Items
{
    public class FlowItemMetadataComponent : MonoBehaviour
    {
        public FlowGraphItemType itemType;

        public string itemId;

        public string[] referencedItemIds = new string[0];
    }
}
