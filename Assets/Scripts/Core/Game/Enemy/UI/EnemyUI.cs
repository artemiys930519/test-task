using Core.UI.Panels;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Game.Player.UI
{
    public class EnemyUI : ViewPanel
    {
        #region Inspector

        [SerializeField] private Image _interactProccessImage;

        #endregion


        public void InteractProccess(float currentValue, float maxValue)
        {
            float valueInPersent = currentValue / maxValue;

            _interactProccessImage.fillAmount = valueInPersent;
        }
    }
}