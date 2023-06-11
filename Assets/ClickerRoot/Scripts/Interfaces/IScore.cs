using ClickerRoot.Scripts.Utils.ServiceLocator;

namespace ClickerRoot.Scripts.Interfaces
{
    public interface IScore : IService
    {
        ulong CurrentScore { get; }

        void IncreaseScore(ulong amount);
        void DecreaseScore(ulong amount);
    }
}
