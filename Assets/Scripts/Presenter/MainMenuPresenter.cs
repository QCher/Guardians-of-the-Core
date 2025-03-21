using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;
using VContainer.Util;

namespace MainMenu
{
    public class MainMenuPresenter : IInitializable, IDisposable
    {
        private readonly MainMenuScreen _mainMenuScreen;
        private readonly SceneLoader _sceneLoader;
        private readonly string _sceneName;
        public MainMenuPresenter(MainMenuScreen mainMenuScreen, SceneLoader sceneLoader, string sceneName)
        {
            _mainMenuScreen = mainMenuScreen;
            _sceneLoader = sceneLoader;
            _sceneName = sceneName;
        }
        public void Initialize()
        {
            _mainMenuScreen.PlayButton.onClick.AddListener(OnPlayPressedHandler);
        }
        
        public void Dispose()
        {
            _mainMenuScreen.PlayButton.onClick.RemoveListener(OnPlayPressedHandler);
        }
        
        private async void OnPlayPressedHandler()
        {
            await _sceneLoader.LoadScene(_sceneName);
            await SceneManager.UnloadSceneAsync("MainMenu");
        }
    }
}