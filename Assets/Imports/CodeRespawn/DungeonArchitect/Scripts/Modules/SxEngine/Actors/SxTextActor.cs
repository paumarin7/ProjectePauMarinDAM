namespace DungeonArchitect.SxEngine
{
    public class SxTextActor : SxActor
    {
        public SxTextComponent TextComponent;

        public SxTextActor()
        {
            TextComponent = AddComponent<SxTextComponent>();
        }
    }
}