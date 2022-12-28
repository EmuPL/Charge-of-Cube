using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
public Transform Player;
public TextMeshProUGUI ScoreText;
    void Update() 
    {
        ScoreText.text = Player.position.z.ToString("0");
    }
}
