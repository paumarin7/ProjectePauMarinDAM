﻿using UnityEngine;

namespace DungeonArchitect.Builders.Maze
{
	public enum MazeTileState {
		Empty,
        Blocked
	}

	public class MazeDungeonModel : DungeonModel {

		[HideInInspector]
		public MazeDungeonConfig Config;

		[HideInInspector]
		public MazeTileState[,] tileStates;
    }
}
