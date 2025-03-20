using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace VContainer.Util
{
    public class SceneLoader
    {
        public async UniTask LoadScene(string sceneName, LifetimeScope parent)
        {
            using (LifetimeScope.EnqueueParent(parent))
            { 
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }
    }
}