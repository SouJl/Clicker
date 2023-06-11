namespace ClickerRoot.Scripts.Utils.Signals
{
    public enum ItemType
    {
        ClickLevel,
    }

    public class ChangeLevelSignal : AbstractSignal<ItemType>
    {
        public ChangeLevelSignal(ItemType value) : base(value)
        {
        }
    }
}
