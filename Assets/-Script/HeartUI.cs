using UnityEngine;
using TMPro;

public class HeartUI : MonoBehaviour
{
    public static HeartUI instance;

    public TextMeshProUGUI heartText;
    int hearts = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddHeart()
    {
        hearts++;
        heartText.text = "x " + hearts;
    }
}
