﻿using UnityEngine;
using UnityEngine.UI;

// Taken from http://answers.unity3d.com/answers/981558/view.html to get non-square colliders working for our mouse button
// Martha and Elizabeth worked on it

[RequireComponent (typeof (RectTransform), typeof (Collider2D))]
public class Collider2DRaycastFilter : MonoBehaviour, ICanvasRaycastFilter 
{
	Collider2D myCollider;
	RectTransform rectTransform;
	
	void Awake () 
	{
		myCollider = GetComponent<Collider2D>();
		rectTransform = GetComponent<RectTransform>();
	}
	
	#region ICanvasRaycastFilter implementation
	public bool IsRaycastLocationValid (Vector2 screenPos, Camera eventCamera)
	{
		var worldPoint = Vector3.zero;
		var isInside = RectTransformUtility.ScreenPointToWorldPointInRectangle(
			rectTransform,
			screenPos,
			eventCamera,
			out worldPoint
			);
		if (isInside)
			isInside = myCollider.OverlapPoint(worldPoint);
		return isInside;
	}
	#endregion
}
