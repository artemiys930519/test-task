using System;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Core.UI.Panels
{
    public class MainPanel : ViewPanel
    {
        private const string FailResult = "К сожалению вы проиграли";
        private const string SuccesResult = "Вы успешно справились с заданием";

        #region Inspector

        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;

        public List<PanelData> _panels = new List<PanelData>();

        #endregion

        private ViewPanel _activeViewPanel;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(QuitApplication);
            _restartButton.onClick.AddListener(RestartApplication);
        }

        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(QuitApplication);
            _restartButton.onClick.RemoveListener(RestartApplication);
        }

        public void ShowViewPanel(Enumenators.PanelType panelType)
        {
            ViewPanel tempViewPanel = _panels.FirstOrDefault(element => element.PanelType == panelType)?.ViewPanel;

            if (tempViewPanel == null)
                return;

            if (_activeViewPanel != null)
                _activeViewPanel.HidePanel();

            _activeViewPanel = tempViewPanel;
            ShowPanel();
            _activeViewPanel.ShowPanel();
        }

        public void ResultState(bool state)
        {
            _resultText.text = state ? SuccesResult : FailResult;
        }

        private void QuitApplication()
        {
            Application.Quit();
        }

        private void RestartApplication()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }

        #region InnerClass

        [Serializable]
        public class PanelData
        {
            public Enumenators.PanelType PanelType;
            public ViewPanel ViewPanel;
        }

        #endregion
    }
}