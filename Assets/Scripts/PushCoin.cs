using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushCoin : MonoBehaviour
{
	const float kSpeedPerSec = 1.5f;

	bool isPushForward = true;

	float curOffset, minOffset, maxOffset;
	float maxOffsetDefault = 3.0f;

	Vector3 zeroOffset;

	void Start()
	{
		zeroOffset = new Vector3(0.0f, 0.2f, -5.0f);

		minOffset = 0.1f;
		maxOffset = maxOffsetDefault;

		curOffset = minOffset;
	}

	void Update()
	{
		if (isPushForward)
		{
			curOffset += Time.deltaTime * kSpeedPerSec;

			if (curOffset >= maxOffset)
			{
				curOffset = maxOffset;
				isPushForward = false;
			}
		}
		else
		{
			curOffset -= Time.deltaTime * kSpeedPerSec;

			if (curOffset <= minOffset)
			{
				curOffset = minOffset;
				maxOffset = maxOffsetDefault;
				isPushForward = true;
			}
		}

		this.GetComponent<Rigidbody>().MovePosition(zeroOffset + new Vector3(0, 0, curOffset));
	}
}
