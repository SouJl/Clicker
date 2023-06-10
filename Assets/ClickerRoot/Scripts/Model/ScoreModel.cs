using ClickerRoot.Scripts.Interfaces;

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


        public void ChangeScore(int amount)
        {
            CurrentScore = amount;
        }
    }
}
