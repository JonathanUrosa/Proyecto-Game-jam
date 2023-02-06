using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] TextMeshPro textMeshPro;
    [SerializeField] bool followTarget;

    public void SetTarget(Transform transform, string nickName)
    {
        target = transform;
        textMeshPro.text = nickName;
        followTarget = true;    
    }

    private void Update()
    {
        if (followTarget)
        {
            if(target != null)
            {
                transform.position = target.position + offset;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
