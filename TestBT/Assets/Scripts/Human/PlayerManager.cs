using System.Collections;
using XftWeapon;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

        Instance = this;
    }

    #region PlayerEffectManger

    // 플레이어 검기 이펙트
    [FoldoutGroup("Player Trail")] [SerializeField]
    internal XWeaponTrail m_AttackLeftTrail;

    [FoldoutGroup("Player Trail")] [SerializeField]
    internal XWeaponTrail m_AttackRightTrail;

    // 혈흔 이펙트의 갯수
    private const int FirstBloodPrefab = 0;
    private const int LastBloodPrefab = 17;

    // 검기이펙트 스위치
    public void TrailSwitch(bool isActive = true)
    {
        switch (isActive)
        {
            case true:
                m_AttackLeftTrail.Activate();
                m_AttackRightTrail.Activate();
                break;
            case false:
                m_AttackLeftTrail.Deactivate();
                m_AttackRightTrail.Deactivate();
                break;
        }
    }

    // 혈흔 이팩트 호출함수
    public void GetBlood(Vector3 spawnPos, float returnTime, Quaternion rotate)
    {
        // 랜덤값으로 프리팹 번호를 생성해 소환
        var effectIdx = (EBloodPrefabsName) Random.Range(FirstBloodPrefab, LastBloodPrefab);
        var currentParticle = ObjPool.Instance.GetObject(effectIdx);
        currentParticle.transform.position = spawnPos;
        currentParticle.transform.rotation = rotate;

        ObjPool.Instance.ReturnObject(currentParticle, effectIdx, returnTime);
    }

    // 스킬 이펙트 호출함수
    // 이펙트따라서 자식오브젝트로 설정을 해야할수도있고 이펙트의 지속시간을 설정해야 하기때문에
    // Nullable 형태로 지정해서 비교함
    // 기본값으로 activeTime 과 owner 는 Null
    public GameObject GetEffect(Vector3 spawnPos, EPrefabsName effectName, float returnTime,
        float? activeTime = null, GameObject owner = null)
    {
        var currentParticle = ObjPool.Instance.GetObject(effectName);
        currentParticle.transform.position = spawnPos;

        ObjPool.Instance.ReturnObject(currentParticle, effectName, returnTime);

        // 이펙트를 자식으로 설정
        if (owner != null)
        {
            currentParticle.transform.parent = owner.transform;
        }
        
        // 이펙트중에 스크립트를 이용해서 매쉬에 업데이트를 해야하는 이펙트가 있기에 TryGetComponent 함수로 체크
        // 만약 True 값이나오면 메쉬에 업데이트를한다
        if (currentParticle.TryGetComponent<PSMeshRendererUpdater>(out var rendererUpdater))
        {
            rendererUpdater.UpdateMeshEffect(owner);
            
            // 지속시간이 있는 이펙트면 코루틴을 이용해서 지속시간 설정
            if (activeTime != null)
            {
                StartCoroutine(ActiveTime(rendererUpdater, (float) activeTime));
            }
        }
        
        return currentParticle;
    }
    
    // 이펙트를 가져올때 선언한 지속시간만큼 대기후 비활성화
    private IEnumerator ActiveTime(PSMeshRendererUpdater currentEffect, float delay)
    {
        yield return new WaitForSeconds(delay);
        currentEffect.IsActive = false;
    }

    #endregion


    #region AnimEvents

    // 플레이어 무기 콜라이더
    [FoldoutGroup("Player Collider")] [SerializeField]
    private BoxCollider m_AttackLeftCollider;

    [FoldoutGroup("Player Collider")] [SerializeField]
    private BoxCollider m_AttackRightCollider;

    // 플레이어 애니메이션에 맞춰서 콜라이더를 활성화 시켜준다
    // 애니메이션 이벤트에서 스트링값으로 매개변수를 전달하고 애니메이션에 맞춰서 활성화
    private void AttackTrue(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                m_AttackLeftCollider.enabled = true;
                break;
            case "AttackR":
                m_AttackRightCollider.enabled = true;
                break;
            case "LastAttack":
                m_AttackLeftCollider.enabled = true;
                m_AttackRightCollider.enabled = true;
                break;
            case "FullSwing":
                m_AttackLeftCollider.enabled = true;
                m_AttackRightCollider.enabled = true;
                break;
            case "FlyAttack":
                m_AttackRightCollider.enabled = true;
                break;
        }
    }

    // 콜라이더 비활성화
    private void AttackFalse(string animName)
    {
        switch (animName)
        {
            case "AttackL":
                m_AttackLeftCollider.enabled = false;
                break;
            case "AttackR":
                m_AttackRightCollider.enabled = false;
                break;
            case "LastAttack":
                m_AttackLeftCollider.enabled = false;
                m_AttackRightCollider.enabled = false;
                break;
            case "FullSwing":
                m_AttackLeftCollider.enabled = false;
                m_AttackRightCollider.enabled = false;
                break;
            case "FlyAttack":
                m_AttackRightCollider.enabled = false;
                break;
        }
    }

    #endregion
}