//$ Copyright 2016, Code Respawn Technologies Pvt Ltd - All Rights Reserved $//

using UnityEngine;
using DungeonArchitect.Builders.Mario;
using DungeonArchitect.SpatialConstraints;

namespace DungeonArchitect.Builders.Grid.SpatialConstraints
{
    public class MarioDungeonSpatialConstraints : SpatialConstraintProcessor
    {
        public override SpatialConstraintRuleDomain GetDomain(SpatialConstraintProcessorContext context)
        {
            var gridConfig = context.config as MarioDungeonConfig;

            var domain = base.GetDomain(context);
            domain.gridSize = (gridConfig != null) ? gridConfig.gridSize : Vector3.one;
            return domain;
        }
    }
}
