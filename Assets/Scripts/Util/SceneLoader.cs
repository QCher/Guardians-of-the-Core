using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace VContainer.Util
{
    public class GameInstaller : IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            Debug.Log("Game Installer");
        }
    }
    public class SceneLoader
    {
        private readonly LoadingScreen _loadingScreen;

        public SceneLoader(LoadingScreen screen)
        {
            _loadingScreen = screen;
        }
        public async UniTask LoadScene(string sceneName)
        {
            _loadingScreen.gameObject.SetActive(true);
            await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await UniTask.Delay(1500);
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}