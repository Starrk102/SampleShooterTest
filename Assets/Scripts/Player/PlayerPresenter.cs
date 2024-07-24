using VContainer;
using VContainer.Unity;

namespace Player
{
    public class PlayerPresenter : IStartable
    {
        private readonly PlayerController player;
        private IObjectResolver iObjectResolver;
    
        public PlayerPresenter(PlayerController player, IObjectResolver iObjectResolver)
        {
            this.player = player;
            this.iObjectResolver = iObjectResolver;
        }
    
        public void Start()
        {
        
        }
    }
}
