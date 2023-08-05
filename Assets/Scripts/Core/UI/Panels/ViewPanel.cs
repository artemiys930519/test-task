using System;
using UnityEngine;

namespace Core.UI.Panels
{
    [Serializable]
    [RequireComponent(typeof(CanvasGroup))]
    public class ViewPanel : MonoBehaviour
    {
        #region Inspector

        public CanvasGroup CanvasGroup;

        #endregion
        
        private void Awake()
        {
            if (CanvasGroup == null)
                CanvasGroup = GetComponent<CanvasGroup>();

            HidePanel();
        }

        public virtual void ShowPanel()
        {
            if (ReferenceEquals(CanvasGroup, null)) return;

            CanvasGroup.alpha = 1;
            CanvasGroup.blocksRaycasts = true;
            CanvasGroup.interactable = true;
        }

        public virtual void HidePanel()
        {
            if (ReferenceEquals(CanvasGroup, null)) return;

            CanvasGroup.alpha = 0;
            CanvasGroup.blocksRaycasts = false;
            CanvasGroup.interactable = false;
        }
    }
}