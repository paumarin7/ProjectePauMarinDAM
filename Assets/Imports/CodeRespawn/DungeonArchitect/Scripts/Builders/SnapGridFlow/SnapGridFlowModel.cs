using DungeonArchitect.Flow.Domains.Layout;
using DungeonArchitect.Flow.Impl.SnapGridFlow;

namespace DungeonArchitect.Builders.SnapGridFlow
{
    public class SnapGridFlowModel : DungeonModel
    {
        public FlowLayoutGraph layoutGraph;
        public SgfModuleNode[] snapModules;
        
        public override void ResetModel()
        {
            layoutGraph = null;
            snapModules = new SgfModuleNode[0];
        }
    }
}