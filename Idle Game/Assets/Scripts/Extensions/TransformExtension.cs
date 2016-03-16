﻿using UnityEngine;
using System.Collections;

public static class TransformExtension
{
    public static void ResetTransform(this Transform transform)
    {
        transform.position = Camera.main.transform.position;
        transform.localRotation = Quaternion.identity;
        transform.localScale = new Vector3(1, 1, 1);
    }

    public static void FollowCursorPosition(this Transform transform, float distanceFromMainCamera)
    {
        Vector3 position = Input.mousePosition;
        position.z = distanceFromMainCamera;
        transform.position = Camera.main.ScreenToWorldPoint(position);
    }

    public static void FollowCursorPositionWithDefinedHeight(this Transform transform, float definedHeight)
    {
        Vector3 position = Input.mousePosition;
       // position.y = definedHeight;
        transform.position = Camera.main.ScreenToWorldPoint(position);
        //Vector3 transformPosition = transform.position;
        //transform.position = new Vector3(transformPosition.x, definedHeight, transformPosition.z);
    }
}
