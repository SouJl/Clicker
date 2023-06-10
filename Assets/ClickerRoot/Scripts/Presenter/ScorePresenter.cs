using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using System;
using ClickerRoot.Scripts.Interfaces;
using ClickerRoot.Scripts.Utils.ServiceLocator;

namespace ClickerRoot.Scripts.Presenter
{
    public  class ScorePresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;

        private IScore _scoreModel;

        private void Start()
        {
            _scoreModel 
                = ServiceLocator.Current.Get<IScore>() 
                ?? throw new ArgumentNullException(nameof(IScore));

            EventBus.Instance.Subscrive<ScoreChangeSignal>(ChangeScore);
        }

        private void ChangeScore(ScoreChangeSignal score)
        {
            _scoreModel.ChangeScore(score.Value);

            _scoreText.text = $"Score : {_scoreModel.CurrentScore}";
        }
    }
}
