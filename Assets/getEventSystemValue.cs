using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public   class getEventSystemValue : StandaloneInputModule
{
    public static  getEventSystemValue _getEventSystemValue;
 public    GraphicRaycaster gra;
    protected override void Start()
    {
        base.Start();
        _getEventSystemValue = this;
    }
    public void  Update()
    {
      
        if (m_PointerData.Count > 0)
        {
            if (m_PointerData[-1].pointerCurrentRaycast.gameObject != null)
            {
              // Debug.Log("-1:" + m_PointerData[-1].pointerCurrentRaycast.gameObject.name);
                //List<RaycastResult> results = new List<RaycastResult>();

                //gra.Raycast(m_PointerData[-1], results);
                //for (int i = 0 ; i < results.Count  ; i++)
                //{
                //    Debug.Log(results[i].gameObject.name);
                //}
            }
        }
        if (input.GetMouseButton(1))
        {
            List<RaycastResult> myressult = new List<RaycastResult>();
            EventSystem.current.RaycastAll(m_PointerData[-1], myressult);
            for (int i = 0 ; i < myressult.Count ; i++)
            {
                Debug.Log(myressult[i].gameObject.name);
            }

        }
        if (input .GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ;
            RaycastHit rayhit;
          if (  Physics.Raycast(ray, out rayhit, Mathf.Infinity))
            {
                Debug.Log(rayhit.transform.gameObject.name);
            }
        }
       
    }

    //获取鼠标打到第一个物体
    public GameObject getvalue()
    {
        return m_PointerData[-1].pointerCurrentRaycast.gameObject;
    }
    //获取鼠标打到所有物体
    public List<GameObject > getvalue1()
    {
        List<RaycastResult> myressult = new List<RaycastResult>();
        List<GameObject > myGameobject = new List<GameObject>();
        EventSystem.current.RaycastAll(m_PointerData[-1], myressult);
        for (int i = 0 ; i < myressult.Count ; i++)
        {
            Debug.Log(myressult[i].gameObject.name);
            myGameobject.Add( myressult[i].gameObject);
    }
        return myGameobject;
    }
}
