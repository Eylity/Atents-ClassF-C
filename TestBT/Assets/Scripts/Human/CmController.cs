using Cinemachine;
using UnityEngine;

public class CmController : CinemachineExtension
{
    private const float PPU = 32f;
    
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.FinalPosition;

            var pos2 = new Vector3(Round(pos.x), Round(pos.y), pos.z);

            state.PositionCorrection += pos2 - pos;
        }

        float Round(float x)
        {
            return Mathf.Round(x * PPU) / PPU;
        }
    }
}