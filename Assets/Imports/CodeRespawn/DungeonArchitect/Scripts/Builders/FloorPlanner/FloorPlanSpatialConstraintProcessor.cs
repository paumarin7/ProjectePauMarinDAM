﻿using DungeonArchitect.SpatialConstraints;

namespace DungeonArchitect.Builders.FloorPlan
{
    public class FloorPlanSpatialConstraintProcessor : SpatialConstraintProcessor
    {
        public override SpatialConstraintRuleDomain GetDomain(SpatialConstraintProcessorContext context)
        {
            var floorPlanConfig = context.config as FloorPlanConfig;

            var domain = base.GetDomain(context);
            domain.gridSize = floorPlanConfig.GridSize;
            return domain;
        }
    }
}