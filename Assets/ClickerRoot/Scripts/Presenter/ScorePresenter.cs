using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using System;

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
            _scoreText.text = $"Score : {TextFormat(score.Value)}";
        }


        private string TextFormat(ulong score)
        {
            if (score < 0) return "0";
            if (score >= 1000000000000000) return "1P";

            if (score < 10000) return score.ToString();
            if (score >= 10000 && score < 1000000) return $"{(int)(score / 1000)}K";
            if (score >= 1000000 && score < 1000000000) return $"{(int)(score / 1000000)}M";
            if (score >= 1000000000 && score < 1000000000000) return $"{(int)(score / 1000000000)}G";
            if (score >= 1000000000000 && score < 1000000000000000) return $"{(int)(score / 1000000000000)}T";

            throw new ArgumentOutOfRangeException(nameof(score));
        }
    }
}
