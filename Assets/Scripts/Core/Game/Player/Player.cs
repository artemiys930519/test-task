using System;
using Core.Game.Systems;
using Core.Services.InputService;
using Core.Services.InteractionService;
using UnityEngine;
using Zenject;

namespace Core.Game.Player
{
    public class Player : MonoBehaviour
    {
        #region Inspector

        [SerializeField] private MovementSystem _movementSystem;

        #endregion

        private IInputService _inputService;
        private IInteractionService _interactionService;

        [Inject]
        private void Construct(IInputService inputService, IInteractionService interactionService)
        {
            _inputService = inputService;
            _interactionService = interactionService;
        }

        private void Update()
        {
            _movementSystem.Move(_inputService.GetMovementValue());
            _movementSystem.Rotate(_inputService.GetRotationValue());
            _interactionService.TryInteract();
        }
    }
}