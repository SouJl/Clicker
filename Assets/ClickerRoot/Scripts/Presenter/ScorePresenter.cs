using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;

namespace ClickerRoot.Scripts.Presenter
{
    public  class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private void Start()
        {
            EventBus.Instance.Subscrive<ScoreChangeSignal>(ChangeScore);
        }

        private void ChangeScore(ScoreChangeSignal score)
        {
            _scoreText.text = $"Score : {score.Value}";
        }
    }
}
