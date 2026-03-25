using UnityEngine;

    public enum GunStash
    {
        Revolver,
        Shotgun,
        Rifle,
        Dynamite
    }

[RequireComponent(typeof(Revolver), typeof(Shotgun))]

public class GunManager : MonoBehaviour
{
    private Revolver m_Revolver;
    private Shotgun m_Shotgun;

    [SerializeField] public GunStash currentGun;
    [SerializeField] public Guns[] currentGuns;

    private KeyCode keys;
    private void Start()
    {
        m_Revolver = GetComponent<Revolver>();
        m_Shotgun = GetComponent<Shotgun>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeGun(GunStash.Revolver);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeGun(GunStash.Shotgun);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeGun(GunStash.Rifle);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            ChangeGun(GunStash.Dynamite);
        }
    }

    private void ChangeGun(GunStash newGun)
    {
        currentGun = newGun;
        for(int i = 0; i < currentGuns.Length; i++)
        {
            currentGuns[i].enabled = i == (int)currentGun;
        }
    }
}
