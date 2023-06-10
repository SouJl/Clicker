namespace ClickerRoot.Scripts.Utils.Signals
{
    public class ScoreChangeSignal : AbstractSignal<int>
    {
        public ScoreChangeSignal(int value) : base(value) { }
    }
}
