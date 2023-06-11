namespace ClickerRoot.Scripts.Utils.Signals
{
    public class ScoreChangeSignal : AbstractSignal<ulong>
    {
        public ScoreChangeSignal(ulong value) : base(value) { }
    }
}
