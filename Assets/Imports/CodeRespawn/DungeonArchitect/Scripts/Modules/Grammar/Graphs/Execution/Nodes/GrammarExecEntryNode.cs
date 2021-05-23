﻿using DungeonArchitect.Graphs;


namespace DungeonArchitect.Grammar
{
    public class GrammarExecEntryNode : GrammarExecNodeBase
    {
        public override void Initialize(string id, Graph graph)
        {
            base.Initialize(id, graph);
            canBeDeleted = false;
            caption = "Entry";
        }
    }
}
