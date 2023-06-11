using ClickerRoot.Scripts.Interfaces;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;

namespace ClickerRoot.Scripts.Model
{
    public class ScoreModel : IScore
    {
        private ulong _currentScore = 0;

        public ulong CurrentScore 
        {
            get => _currentScore;
            private set 
            {
                if(value <= 0)
                {
                    _currentScore = 0;
                }
                else
                {
                    _currentScore = value;
                }
            }
        }

        public ScoreModel() { }


        public void IncreaseScore(ulong amount)
        {
            CurrentScore += amount;
            ScoreChanged();
        }

        public void DecreaseScore(ulong amount)
        {
            CurrentScore -= amount;
            ScoreChanged();
        }

        private void ScoreChanged()
        {
            EventBus.Instance?.Invoke<ScoreChangeSignal>(new ScoreChangeSignal(CurrentScore));
        }
    }
}
