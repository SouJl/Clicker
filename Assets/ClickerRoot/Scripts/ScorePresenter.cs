using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils;

namespace ClickerRoot.Scripts
{
    public  class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private int _currentScore;

        private void Start()
        {
            _currentScore = 0;
            EventBus.Instance.Subscrive<ScoreChangeEvent>(ChangeScore);
        }

        private void ChangeScore(ScoreChangeEvent score)
        {
            _currentScore += score.Value;
            _scoreText.text = $"Clicks : {_currentScore}";
        }
    }
}
