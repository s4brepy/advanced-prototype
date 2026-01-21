using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Transform heartsContainer;
    private RawImage[] hearts;
    [SerializeField] private Texture emptyHeart;
    [SerializeField] private Texture halfHeart;
    [SerializeField] private Texture fullHeart;


    private void Awake()
    {
        hearts = new RawImage[heartsContainer.childCount];

        for (int i = 0; i < heartsContainer.childCount; i++)
        {
            hearts[i] = heartsContainer.GetChild(i).GetComponent<RawImage>();

        }
    }
    public void UpdateHearts(int currentHealth)
    {
        float currentHealthf = (float)currentHealth/10;
        for (int i = 0; i < hearts.Length; i++)
        {
            if ((float)i+1f > currentHealthf && (float)i < currentHealthf)
            {
                hearts[hearts.Length-1-i].texture = halfHeart;
            }
            else if ((float)i < currentHealthf)
            {
                hearts[hearts.Length-1-i].texture = fullHeart;
            }
           
            else
            {
                hearts[hearts.Length-1-i].texture = emptyHeart;
            }
            
        }
    }
}
