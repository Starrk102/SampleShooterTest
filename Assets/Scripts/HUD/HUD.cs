using Player;
using TMPro;
using UniRx;
using UnityEngine;
using VContainer;

namespace HUD
{
    public class HUD : MonoBehaviour
    {
        public TMP_Text text;

        private PlayerController playerController;
    
        [Inject]
        public void Container(PlayerController playerController)
        {
            this.playerController = playerController;
        }

        private void Start()
        {
            //text.text = playerController.health.Value.ToString();

            playerController.health.Subscribe(currentHealth =>
            {
                text.text = currentHealth.ToString();
            }).AddTo(this);
        }
    }
}
