using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. 배경 생성
/// 2. 보드 생성
/// 3. 타일 배치 - 보드
/// 4. 점수 기록
/// 5. 게임시간 체크
/// 6. 타일 재생성 - 랜덤
/// 7. 
/// </summary>

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    // Start is called before the first frame update
    public GameObject m_BG;
    public int m_BGScaleX;
    public int m_BGScaleY;

    private GameObject m_PrivateBG;
    void Start()
    {
        Instance = GetComponent<Manager>();

        m_PrivateBG = m_BG;
        m_PrivateBG.transform.localScale = new Vector3(m_BGScaleX, m_BGScaleY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        m_PrivateBG.transform.localScale.Set(m_BGScaleX, m_BGScaleY, 0);

    }
}
