using Core.Enums;
using Core.UI.Panels;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Units.Enemy.UI
{
    public class EnemyUI : ViewPanel
    {
        #region Inspector

        [SerializeField] private ViewPanel _proccessPanel;
        [SerializeField] private ViewPanel _resultPanel;
        [SerializeField] private Image _interactProccessImage;
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
                _proccessPanel.HidePanel();
                return;
            }

            if (enemyUIPanel == Enumenators.EnemyUIPanel.ProccessPanel)
            {
                _proccessPanel.ShowPanel();
                _resultPanel.HidePanel();
            }
            else
            {
                _proccessPanel.HidePanel();
                _resultPanel.ShowPanel();
            }
        }

        public void InteractProccess(float currentValue, float maxValue)
        {
            float valueInPersent = currentValue / maxValue;

            _interactProccessImage.fillAmount = valueInPersent;
        }

        public void SetDescriptionText(string tittle)
        {
            _descriptionText.text = tittle;
        }
    }
}