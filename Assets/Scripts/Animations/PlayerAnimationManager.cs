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
        MovementAnimations();

        WeaponAnimations();
        
        //check death
        if (_playerManager.Health <= 0)
        {
            _animator.SetTrigger("Death");
        }
        
        if (_gunManager.currentGun == GunStash.Revolver)
        {
            //Debug.Log("Revolver");
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            _animator.SetTrigger("Reload_Rifle");
        }
        else if (Input.GetMouseButtonDown(0) && _revolver.AmmoCount > 0)
        {
            _animator.SetTrigger("Shoot_Rifle");
            Debug.Log(_revolver.AmmoCount);
        }
    }
}
