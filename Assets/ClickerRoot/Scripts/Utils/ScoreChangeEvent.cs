namespace ClickerRoot.Scripts.Utils
{
    public class ScoreChangeEvent
    {
        public int Value { get; private set; }

        public ScoreChangeEvent(int value)
        {
            Value = value;
        }
    }
}
