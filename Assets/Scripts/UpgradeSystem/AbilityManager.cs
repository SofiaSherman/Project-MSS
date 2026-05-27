using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private int scoreToUpgradeRevolver;
    [SerializeField] private int  scoreToUpgradeRifle;
    [SerializeField] private int  scoreToUpgradeShotgun;
    [SerializeField] private int  scoreToUpgradeDynamite;
    
    [SerializeField] private GameObject revolverButton;
    [SerializeField] private GameObject rifleButton;
    [SerializeField] private GameObject shotgunButton;
    [SerializeField] private GameObject dynamiteButton;


    private ScoreManager scoreManager;
    void Start()
    {
        scoreManager = GameObject.FindWithTag("GameManager").GetComponent<ScoreManager>();
        
        GameObject playerObj = GameObject.Find("Player");
    }

    void Update()
    {
        
    }

    public void UpgradeRevolver()
    {
        if (scoreManager.score >= scoreToUpgradeRevolver)
        {
            scoreManager.score -= scoreToUpgradeRevolver;
            revolverButton.SetActive(false);
        }
    }
    public void UpgradeRifle()
    {
        if (scoreManager.score >= scoreToUpgradeRifle)
        {
            scoreManager.score -= scoreToUpgradeRifle;
            rifleButton.SetActive(false);
        }
    }
    public void UpgradeShotgun()
    {
        if (scoreManager.score >= scoreToUpgradeShotgun)
        {
            scoreManager.score -= scoreToUpgradeShotgun;
            shotgunButton.SetActive(false);
        }
    }
    public void UpgradeDynamite()
    {
        if (scoreManager.score >= scoreToUpgradeDynamite)
        {
            scoreManager.score -= scoreToUpgradeDynamite;
            dynamiteButton.SetActive(false);
        }
    }
}
