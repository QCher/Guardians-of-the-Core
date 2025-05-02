using UnityEngine;
using UnityEngine.Rendering;

namespace CustomRP.Runtime
{
    public class CustomRenderPipeline : RenderPipeline
    {
        private readonly CustomRPSettings _settings;
        private CameraRenderer _renderer = new();

        public CustomRenderPipeline(CustomRPSettings settings)
        {
            _settings = settings;
        }
        
        protected override void Render(ScriptableRenderContext context, Camera[] cameras)
        {
            for (int i = 0; i < cameras.Length; i++)
            {
                _renderer.Render(context, cameras[i]);
            }
        }
    }
}