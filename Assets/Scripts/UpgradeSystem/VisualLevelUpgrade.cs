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
        switch (switchCase)
        {
            case 1:
                for (int i = 0; i < currentLevel; i++)
                {
                    playerHealthLevel[i].SetActive(false);
                }
                break;
            case 2:
                for (int i = 0; i < currentLevel; i++)
                {
                    revolverAmmoLevel[i].SetActive(false);
                }
                break;
            case 3:
                for (int i = 0; i < currentLevel; i++)
                {
                    revolverDamageLevel[i].SetActive(false);
                }
                break;
            case 4:
                for (int i = 0; i < currentLevel; i++)
                {
                    rifleAmmoLevel[i].SetActive(false);
                }
                break;
            case 5:
                for (int i = 0; i < currentLevel; i++)
                {
                    rifleDamageLevel[i].SetActive(false);
                }
                break;
            case 6:
                for (int i = 0; i < currentLevel; i++)
                {
                    shotgunAmmoLevel[i].SetActive(false);
                }
                break;
            case 7:
                for (int i = 0; i < currentLevel; i++)
                {
                    shotgunDamageLevel[i].SetActive(false);
                }
                break;
            case 8:
                for (int i = 0; i < currentLevel; i++)
                {
                    dynamiteAmmoLevel[i].SetActive(false);
                }
                break;
            case 9:
                for (int i = 0; i < currentLevel; i++)
                {
                    dynamiteDamageLevel[i].SetActive(false);
                }
                break;
        }
            
    }
}
