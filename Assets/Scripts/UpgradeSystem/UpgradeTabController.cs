using UnityEngine;
using UnityEngine.UI;

public class UpgradeTabController : MonoBehaviour
{
    [SerializeField] private Image[] tabImages;
    [SerializeField] private GameObject[] pages;

    private void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int tabIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        
        pages[tabIndex].SetActive(true);
        tabImages[tabIndex].color = Color.white;
    }
}
