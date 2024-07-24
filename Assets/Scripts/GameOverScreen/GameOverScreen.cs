using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameOverScreen
{
    public class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private Button restart;
        [SerializeField] private Button quit;

        private void Start()
        {
            restart.onClick.AddListener(() =>
            {
                SceneManager.LoadScene("SampleScene");
            });
        
            quit.onClick.AddListener(Application.Quit);
        }

        private void OnDestroy()
        {
            restart.onClick.RemoveAllListeners();
            quit.onClick.RemoveAllListeners();
        }
    }
}
