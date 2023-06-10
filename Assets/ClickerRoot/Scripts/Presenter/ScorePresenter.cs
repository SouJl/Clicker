using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils;

namespace ClickerRoot.Scripts.Presenter
{
    public  class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private int _currentScore;

        private void Start()
        {
            _currentScore = 0;
            EventBus.Instance.Subscrive<ScoreChangeSignal>(ChangeScore);
        }

        private void ChangeScore(ScoreChangeSignal score)
        {
            _currentScore += score.Value;
            _scoreText.text = $"Score : {_currentScore}";
        }
    }
}
