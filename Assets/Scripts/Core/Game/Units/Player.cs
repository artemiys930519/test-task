using Core.Game.Systems;
using Core.Services.InputService;
using Core.Services.InteractionService;
using Core.Services.InteractService;
using Core.Services.PauseService;
using UnityEngine;
using Zenject;

namespace Core.Game.Units
{
    public class Player : MonoBehaviour, IPauseService
    {
        #region Inspector

        [SerializeField] private MovementSystem _movementSystem;

        #endregion

        private IInputService _inputService;
        private IInteractionService _interactionService;
        private IInteractService _currentInteract;

        private bool _isStopped = false;

        [Inject]
        private void Construct(IInputService inputService, IInteractionService interactionService)
        {
            _inputService = inputService;
            _interactionService = interactionService;
        }

        private void Update()
        {
            if (_isStopped)
                return;

            _movementSystem.Move(_inputService.GetMovementValue());
            _movementSystem.Rotate(_inputService.GetRotationValue());
            TryInteract();
        }

        public void Pause()
        {
            _isStopped = true;
        }

        public void Resume()
        {
            _isStopped = false;
        }

        private void TryInteract()
        {
            if (_interactionService.TryGetInteractObject(out IInteractService interact))
            {
                if (_currentInteract != null && _currentInteract != interact)
                {
                    _currentInteract.EndInteract();
                    _currentInteract = null;
                }

                if (_currentInteract == null)
                {
                    _currentInteract = interact;
                    _currentInteract.StartInteract();
                }
            }
            else
            {
                if (_currentInteract != null)
                {
                    _currentInteract.EndInteract();
                    _currentInteract = null;
                }
            }
        }
    }
}