using UnityEngine;
using UnityEngine.Rendering;

namespace CustomRP.Runtime
{
    public class CameraRenderer
    {
        private Camera _camera;
        private ScriptableRenderContext _context;

        public void Render(ScriptableRenderContext context, Camera camera)
        {
            _camera = camera;
            _context = context;
            
            DrawVisibleGeometry();
            
        }

        private void DrawVisibleGeometry()
        {
            _context.DrawSkybox(_camera);
        }
    }
}