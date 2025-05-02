using UnityEngine;
using UnityEngine.Rendering;

namespace CustomRP.Runtime
{
    public class CameraRenderer
    {
        const string _commandBufferName = "RenderCamera";
        CommandBuffer _commandBuffer = new ()
        {
            name = _commandBufferName,
        };
        private Camera _camera;
        private ScriptableRenderContext _context;
        CullingResults _cullingResults;

        public void Render(ScriptableRenderContext context, Camera camera)
        {
            _camera = camera;
            _context = context;

            if (!Cull())
            {
                return;
            }
            
            Setup();
            DrawVisibleGeometry();
            Submit();
            
        }

        private void DrawVisibleGeometry()
        {
            _context.DrawSkybox(_camera);
        }
        void Setup () {
            _context.SetupCameraProperties(_camera);
            _commandBuffer.ClearRenderTarget(true, true, Color.clear);
            _commandBuffer.BeginSample(_commandBufferName);
            ExecuteBuffer();

        }
        
        private void Submit()
        {
            _commandBuffer.EndSample(_commandBufferName);
            ExecuteBuffer();
            _context.Submit();
        }

        private bool Cull()
        {
            if (_camera.TryGetCullingParameters(out var parameters))
            {
                _cullingResults = _context.Cull(ref parameters);
                return true;
            }

            return false;
        }

        void ExecuteBuffer()
        {
            _context.ExecuteCommandBuffer(_commandBuffer);
            _commandBuffer.Clear();
        }
        
        
    }
}