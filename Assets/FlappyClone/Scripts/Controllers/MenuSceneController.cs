using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyClone.Scripts.Controllers
{
    public class MenuSceneController : MonoBehaviour
    {
        [SerializeField] private MainMenuScreen mainMenuScreen;

        private void Awake()
        {
            mainMenuScreen.PlayClicked += MainMenuScreenOnPlayClicked;
        }

        private void MainMenuScreenOnPlayClicked()
        {
            SceneManager.LoadScene(1);
        }

        private void OnDestroy()
        {
            mainMenuScreen.PlayClicked -= MainMenuScreenOnPlayClicked;
        }
    }
}