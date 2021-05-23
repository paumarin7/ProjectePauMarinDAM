﻿using DungeonArchitect.Flow.Domains.Tilemap.Tasks;
using DungeonArchitect.Flow.Exec;

namespace DungeonArchitect.Flow.Impl.GridFlow.Tasks
{

    [FlowExecNodeInfo("Create Tilemap Elevations", "Tilemap/", 2100)]
    public class GridFlowTilemapTaskCreateElevations : TilemapBaseFlowTaskCreateElevations
    {
    }
}
