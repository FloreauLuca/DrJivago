using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerDownHandler
{
	private PlayerMovement myPlayer;

	void Start()
	{
		myPlayer = FindObjectOfType<PlayerMovement>();
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		myPlayer.MoveLeft();
	}

	public void StopLeft()
	{
		myPlayer.StopMoveLeft();
	}
}
