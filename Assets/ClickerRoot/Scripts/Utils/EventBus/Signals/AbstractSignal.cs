namespace ClickerRoot.Scripts.Utils.Signals
{
    public interface ISignal<T>
    {
        T Value { get; }
    }

    public abstract class AbstractSignal<T> : ISignal<T>
    {
        public T Value { get; private set; }

        public AbstractSignal(T value) 
        {
            Value = value;
        }
    }
}
