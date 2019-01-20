using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RightButton : MonoBehaviour, IPointerDownHandler
{
	private PlayerMovement myPlayer;

	void Start()
	{
		myPlayer = FindObjectOfType<PlayerMovement>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		myPlayer.MoveRight();
	}

	public void StopRight()
	{
		myPlayer.StopMoveRight();
	}
}
