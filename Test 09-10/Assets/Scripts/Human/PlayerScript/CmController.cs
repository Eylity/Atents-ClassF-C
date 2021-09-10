using Cinemachine;
using UnityEngine;

namespace Human.PlayerScript
{
    public class CmController : CinemachineExtension
    {
        private const float PPU = 32f;
    
        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage == CinemachineCore.Stage.Body)
            {
                Vector3 pos = state.FinalPosition;

                Vector3 pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);

                state.PositionCorrection += pos2 - pos;
            }

            float Round(float x)
            {
                return Mathf.Round(x * PPU) / PPU;
            }
        }
    }
}