namespace ClickerRoot.Scripts.Utils
{
    public class ScoreChangeSignal : AbstractSignal<int>
    {
        public ScoreChangeSignal(int value) : base(value) { }
    }
}
