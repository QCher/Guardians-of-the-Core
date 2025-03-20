using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace VContainer.Util
{
    public class SceneLoader
    {
        private readonly LoadingScreen _loadingScreen;

        public SceneLoader(LoadingScreen screen)
        {
            _loadingScreen = screen;
        }
        public async UniTask LoadScene(string sceneName, LifetimeScope parent)
        {
            _loadingScreen.gameObject.SetActive(true);
            using (LifetimeScope.EnqueueParent(parent))
            { 
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            await UniTask.Delay(1500);
            _loadingScreen.gameObject.SetActive(false);
        }
    }
}