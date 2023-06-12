using UnityEngine;
using TMPro;
using ClickerRoot.Scripts.Utils.EventBus;
using ClickerRoot.Scripts.Utils.Signals;
using System;
using ClickerRoot.Scripts.Utils;

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
            if (score >= Const.Quadrillion) return "1P";

            if (score < 10 * Const.Thousand) return score.ToString();
            if (score >= 10 * Const.Thousand && score < Const.Million) return $"{(int)(score / Const.Thousand)}K";
            if (score >= Const.Million && score < Const.Billion) return $"{(int)(score / Const.Million)}M";
            if (score >= Const.Billion && score < Const.Trillion) return $"{(int)(score / Const.Billion)}G";
            if (score >= Const.Trillion && score < Const.Quadrillion) return $"{(int)(score / Const.Trillion)}T";

            throw new ArgumentOutOfRangeException(nameof(score));
        }
    }
}
