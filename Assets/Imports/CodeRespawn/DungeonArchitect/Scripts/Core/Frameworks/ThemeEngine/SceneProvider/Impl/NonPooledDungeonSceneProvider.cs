namespace DungeonArchitect
{
    public class NonPooledDungeonSceneProvider : PooledDungeonSceneProvider
    {
        public override void OnDungeonBuildStart()
        {
            // Disable pooling by not collecting or destroying pooled objects
            Initialize();
        }

        public override void OnDungeonBuildStop()
        {
            
        }
    }
}