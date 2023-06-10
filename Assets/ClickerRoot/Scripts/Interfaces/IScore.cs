using ClickerRoot.Scripts.Utils.ServiceLocator;

namespace ClickerRoot.Scripts.Interfaces
{
    public interface IScore : IService
    {
        int CurrentScore { get; }

        void ChangeScore(int amount);
    }
}
