using Core.Services.InteractService;

namespace Core.Services.InteractionService
{
    public interface IInteractionService
    {
        public void Init();
        public bool TryGetInteractObject(out IInteractService interactService);
    }
}