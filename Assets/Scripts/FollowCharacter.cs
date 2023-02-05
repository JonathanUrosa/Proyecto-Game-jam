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

    public void SetTarget(Transform transform, string nickName)
    {
        target = transform;
        textMeshPro.text = nickName;
    }

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
