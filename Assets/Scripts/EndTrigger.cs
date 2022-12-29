using UnityEngine;

public class EndTrigger : MonoBehaviour
{
	public GameManager GameManager = null;
	private void OnTriggerEnter()
	{
		GameManager.CompleteLevel();
	}
}
