namespace DungeonArchitect.Flow.Domains
{
    public interface IFlowDomain
    {
        System.Type[] SupportedTasks { get; }
        string DisplayName { get; }
    }
}