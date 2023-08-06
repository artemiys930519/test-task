using System;
using System.Collections.Generic;
using System.Linq;
using Core.Enums;
using Core.Services.SceneRepository;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Core.UI.Panels
{
    public class MainPanel : ViewPanel
    {
        #region Inspector

        [SerializeField] private TMP_Text _resultText;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _restartButton;

        public List<PanelData> _panels = new List<PanelData>();

        #endregion

        private ISceneRepository _sceneRepository;

        private ViewPanel _activeViewPanel;

        [Inject]
        private void Construct(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

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

        public void ResultState(Enumenators.ScenarioEndType state)
        {
            string resultText = string.Empty;

            if (state == Enumenators.ScenarioEndType.Catched)
                resultText = _sceneRepository.ScenarioData.LanguageData.CatchedResult;
            else
                resultText = state == Enumenators.ScenarioEndType.Success 
                    ? _sceneRepository.ScenarioData.LanguageData.SuccesResult 
                    : _sceneRepository.ScenarioData.LanguageData.FailResult;

            _resultText.text = resultText;
        }

        private void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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