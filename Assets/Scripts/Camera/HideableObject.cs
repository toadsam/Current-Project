using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HideableObject : MonoBehaviour
{
    private HideableObject hideObject;
    private static Dictionary<Collider, HideableObject> hideableObjectsMap = new Dictionary<Collider, HideableObject>();

    [SerializeField]
    public GameObject Renderers;
    public Collider Collider = null;

    private void Start()
    {
        InitHideObject();
    }

    //저장된 정보 초기화
    public static void InitHideObject()
    {
        //이전 정보가 있다면 오브젝트를 다시 보이게 해주고 초기화
        foreach(var obj in hideableObjectsMap.Values)
        {
            if(obj != null && obj.Collider != null)
            {
                obj.SetVisible(true);
                obj.hideObject = null;
            }
        }

        hideableObjectsMap.Clear();

        foreach (var obj in FindObjectsOfType<HideableObject>())
        {
            if(obj.Collider != null)
                hideableObjectsMap[obj.Collider] = obj;
        }
    }

    //지정해준 콜라이더를 확인한 후 오브젝트가 있다면 카메라쪽으로 오브젝트를 넣어줌
    //콜라이더 확인
    public static HideableObject GetRootHideableCollider(Collider collider)
    {
        HideableObject obj;

        if(hideableObjectsMap.TryGetValue(collider, out obj))
            return GetRoot(obj);
        else
            return null;
    }

    //확인할 오브젝트
    private static HideableObject GetRoot(HideableObject obj)
    {
        if(obj.hideObject == null)
            return obj;
        else
            return GetRoot(obj.hideObject);
    }

    //카메라에서 오브젝트를 보이게할지 숨길지
    public void SetVisible(bool visible)
    {
        Renderer rend = Renderers.GetComponent<Renderer>();

        if(rend != null && rend.gameObject.activeInHierarchy && hideableObjectsMap.ContainsKey(rend.GetComponent<Collider>()))
            rend.shadowCastingMode = visible ? ShadowCastingMode.On : ShadowCastingMode.ShadowsOnly;
    }
}
