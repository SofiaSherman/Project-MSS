using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerManager  _playerManager;
    private GunManager _gunManager;
    private Guns _guns;
    private Shotgun _shotgun;
    private Revolver _revolver;
    
    private Animator _animator;
    private AnimatorClipInfo[] m_CurrentClipInfo;
    private float m_CurrentClipLength;
    
    private bool isReloading = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _animator = GetComponent<Animator>();
        
        _playerMovement =  GetComponent<PlayerMovement>();
        _playerManager  = GetComponent<PlayerManager>();
        _gunManager = GetComponent<GunManager>();
        _guns = GetComponent<Guns>();
        _shotgun = GetComponent<Shotgun>();
        _revolver = GetComponent<Revolver>();
    }

    // Update is called once per frame
    void Update()
    {
        //check death
        if (_playerManager.Health <= 0)
        {
            _animator.SetTrigger("Death");
        }
        
        MovementAnimations();

        WeaponAnimations();
        

        CurrentWeaponHeldAnimation();

    }

    private void CurrentWeaponHeldAnimation()
    {
        //check currently held weapon
        if (_gunManager.currentGun == GunStash.Revolver)
        {
            _animator.SetBool("IsHoldingRevolver", true);
            _animator.SetBool("IsHoldingRifle", false);
            _animator.SetBool("IsHoldingDynamite", false);
        }
        else if (_gunManager.currentGun == GunStash.Shotgun)
        {
            _animator.SetBool("IsHoldingRevolver", false);
            _animator.SetBool("IsHoldingRifle", true);
            _animator.SetBool("IsHoldingDynamite", false);
        }
        else if (_gunManager.currentGun == GunStash.Rifle)
        {
            _animator.SetBool("IsHoldingRevolver", false);
            _animator.SetBool("IsHoldingRifle", true);
            _animator.SetBool("IsHoldingDynamite", false);
        }
        else if (_gunManager.currentGun == GunStash.Dynamite)
        {
            _animator.SetBool("IsHoldingRevolver", false);
            _animator.SetBool("IsHoldingRifle", false);
            _animator.SetBool("IsHoldingDynamite", true);
        }
    }
    private void MovementAnimations()
    {
        //check velocity
        _animator.SetFloat("VelocityY", _playerMovement.VelocityY, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", _playerMovement.VelocityX, 0.1f, Time.deltaTime);
        
        //check if running
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    private void WeaponAnimations()
    {
        //check rifle shoot & reload
        //if(_revolver.AmmoCount <= 0) return;
        if (_gunManager.currentGun == GunStash.Revolver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _animator.SetTrigger("Reload_Revolver");
                isReloading = true;
            }
            else if (Input.GetMouseButtonDown(0) && _revolver.AmmoCount > 0 && !isReloading)
            {
                _animator.SetTrigger("Shoot_Revolver");
            }
        }
        else if (_gunManager.currentGun == GunStash.Shotgun)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _animator.SetTrigger("Reload_Rifle");
            }
            else if (Input.GetMouseButtonDown(0) && _shotgun.AmmoCount > 0)
            {
                _animator.SetTrigger("Shoot_Rifle");
            }
        }
        else if (_gunManager.currentGun == GunStash.Rifle)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                _animator.SetTrigger("Reload_Rifle");
            }
            else if (Input.GetMouseButtonDown(0)) //&& _rifle.AmmoCount > 0)
            {
                _animator.SetTrigger("Shoot_Rifle");
            }
        }
        else if (_gunManager.currentGun == GunStash.Dynamite)
        {
            if (Input.GetMouseButtonDown(0)) //&& _dynamite.AmmoCount > 0)
            {
                _animator.SetTrigger("ThrowDynamite");
            }
        }
    }

    private void CollectClipData()
    {
        m_CurrentClipInfo = this._animator.GetCurrentAnimatorClipInfo(0);
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
    }

    public void ReloadComplete()
    {
        isReloading = false;
        Debug.Log("Reload Complete");
    }
}
