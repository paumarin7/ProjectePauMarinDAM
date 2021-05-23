namespace DungeonArchitect
{
    public interface ISGFLayoutNodeCategoryConstraint
    {
        string[] GetModuleCategoriesAtNode(int currentPathPosition, int pathLength);
    }
}