using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{
    public Player player;
    public static int hitQuantity;
    private static bool updateScore;

    private void Awake()
    {
        UpdateVariableText();
    }

    private void Update()
    {
        if (updateScore)
        {
            UpdateVariableText();
        }
    }

    public static void UpdateScore()
    {
        updateScore = true;
    }

    private void UpdateVariableText()
    {
        hitQuantity = player.Score;
        GetComponent<Text>().text = "Очки: " + hitQuantity;
        updateScore = false;
    }
}