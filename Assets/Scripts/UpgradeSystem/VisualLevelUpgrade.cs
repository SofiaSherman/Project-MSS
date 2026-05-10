using UnityEngine;

public class VisualLevelUpgrade : MonoBehaviour
{
    [SerializeField] private GameObject[] playerSpeedLevel;
    [SerializeField] private GameObject[] playerHealthLevel;
    [SerializeField] private GameObject[] revolverAmmoLevel;
    [SerializeField] private GameObject[] revolverDamageLevel;
    [SerializeField] private GameObject[] rifleAmmoLevel;
    [SerializeField] private GameObject[] rifleDamageLevel;
    [SerializeField] private GameObject[] shotgunAmmoLevel;
    [SerializeField] private GameObject[] shotgunDamageLevel;
    [SerializeField] private GameObject[] dynamiteAmmoLevel;
    [SerializeField] private GameObject[] dynamiteDamageLevel;


    public void VisualUpgrade(int currentLevel, int switchCase)
    {
        s
        for (int i = 0; i < currentLevel; i++)
        {
            rifleAmmoLevel[i].SetActive(false);
        }
    }
}
