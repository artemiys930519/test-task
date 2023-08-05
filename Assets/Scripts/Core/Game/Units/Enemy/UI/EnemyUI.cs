using Core.Enums;
using Core.UI.Panels;
using Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Units.Enemy.UI
{
    public class EnemyUI : ViewPanel
    {
        #region Inspector

        [SerializeField] private ViewPanel _processPanel;
        [SerializeField] private ViewPanel _resultPanel;
        [SerializeField] private Image _interactProcessImage;
        [SerializeField] private TMP_Text _descriptionText;
        [SerializeField] private LookAtPlayer _lookAtPlayer;

        #endregion

        private void Start()
        {
            ShowPanel();
        }

        public void SetPlayer(Transform player)
        {
            _lookAtPlayer.SetPlayer(player);
        }

        public void ShowUIPanel(Enumenators.EnemyUIPanel enemyUIPanel)
        {
            if (enemyUIPanel == Enumenators.EnemyUIPanel.Unknown)
            {
                _resultPanel.HidePanel();
                _processPanel.HidePanel();
                return;
            }

            if (enemyUIPanel == Enumenators.EnemyUIPanel.ProcessPanel)
            {
                _processPanel.ShowPanel();
                _resultPanel.HidePanel();
            }
            else
            {
                _processPanel.HidePanel();
                _resultPanel.ShowPanel();
            }
        }

        public void InteractProcess(float currentValue, float maxValue)
        {
            float valueInPersent = currentValue / maxValue;

            _interactProcessImage.fillAmount = valueInPersent;
        }

        public void SetDescriptionText(string tittle)
        {
            _descriptionText.text = tittle;
        }
    }
}