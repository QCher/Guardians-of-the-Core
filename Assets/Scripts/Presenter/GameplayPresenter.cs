using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using VContainer.Util;

namespace Gameplay
{
    public class GameplayPresenter : IInitializable, IDisposable
    {
        private readonly GameplayScreen _gameplayScreen;
        private readonly SceneLoader _sceneLoader;
        private readonly LifetimeScope _scope;
        private readonly string _sceneName;
        public GameplayPresenter(GameplayScreen gameplayScreen, SceneLoader sceneLoader, LifetimeScope scope, string sceneName)
        {
            _gameplayScreen = gameplayScreen;
            _sceneLoader = sceneLoader;
            _scope = scope;
            _sceneName = sceneName;
        }
        public void Initialize()
        {
            _gameplayScreen.LeaveButton.onClick.AddListener(OnLeavePressedHandler);
        }
        
        public void Dispose()
        {
            _gameplayScreen.LeaveButton.onClick.RemoveListener(OnLeavePressedHandler);
        }
        
        private async void OnLeavePressedHandler()
        {
            await _sceneLoader.LoadScene(_sceneName, _scope.Parent);
            await SceneManager.UnloadSceneAsync("Gameplay");
        }
    }
}