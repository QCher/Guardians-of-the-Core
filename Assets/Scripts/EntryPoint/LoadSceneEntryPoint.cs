using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using VContainer.Unity;
using VContainer.Util;

namespace VContainer
{
    public class LoadSceneEntryPoint : IAsyncStartable
    {
        private readonly SceneLoader _sceneLoader;
        private readonly LifetimeScope _parent;
        private readonly LoadingScreen _loadingScreen;
        private readonly string _sceneName;

        [Inject][UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
        public LoadSceneEntryPoint(SceneLoader sceneLoader, LifetimeScope parent, LoadingScreen loadingScreen,string sceneName)
        {
            _sceneLoader = sceneLoader;
            _parent = parent;
            _loadingScreen = loadingScreen;
            _sceneName = sceneName;
        }
        

        async UniTask IAsyncStartable.StartAsync(CancellationToken cancellation = new())
        {
            await _sceneLoader.LoadScene(_sceneName, _parent);
        }
    }
}