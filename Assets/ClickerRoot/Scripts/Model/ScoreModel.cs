using ClickerRoot.Scripts.Interfaces;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;

namespace ClickerRoot.Scripts.Model
{
    public class ScoreModel : IScore
    {
        private  int _currentScore = 0;

        public int CurrentScore 
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


        public void IncreaseScore(int amount)
        {
            CurrentScore += amount;
            ScoreChanged();
        }

        public void DecreaseScore(int amount)
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
