using UnityEngine;
using UnityEngine.Rendering;

namespace CustomRP.Runtime
{
    [CreateAssetMenu(menuName = "Rendering/Custom Render Pipeline")]
    public class CustomRenderPipelineAsset : RenderPipelineAsset<CustomRenderPipeline>
    {
        public CustomRPSettings settings;
        protected override RenderPipeline CreatePipeline()
        {
            return new CustomRenderPipeline(settings);
        }
    }
}
