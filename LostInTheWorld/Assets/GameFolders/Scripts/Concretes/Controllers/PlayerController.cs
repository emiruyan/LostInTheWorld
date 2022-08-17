using System;
using System.Collections;
using System.Collections.Generic;
using LostInTheWorld.Animations;
using LostInTheWorld.Managers;
using LostInTheWorld.Movements;
using UnityEngine;

namespace LostInTheWorld.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] AnimationController _animationController;
        [SerializeField] float _turnSpeed = 10f;
        [SerializeField] float _force = 55f;
        [SerializeField] Transform _minXy, _maxXy;
        
        // Ragdoll kullanılmadığında etkinleştirilmesi gereken Colliderlar
        public Collider[] _colliderToEnable;
        // Ragdoll kullanırken etkinleştirilen tüm Colliderları array olarak verdik
        Collider[] _allCollider;
        // Ragdoll tarafından kullanılan tüm itemları list ile verdik
        List<Rigidbody> _ragdollRigidBodies=new List<Rigidbody>();

        Mover _mover; //Mover class'ımıza eriştik.
        DefaultInput _input; //Input System'a eriştik.
        Rotator _rotator;
        FireParticleEffect _fireParticleEffect;

        bool _canRobotMove;
        bool _isRobotUp;
        float _robotRotator;    


        public float TurnSpeed => _turnSpeed;
        public float Force => _force;
        public bool CanRobotMove => _canRobotMove;

        private void Awake() //Component'lar ve cashlemeler
        {
            _input = new DefaultInput();
            _mover = new Mover(this);
            _rotator = new Rotator(this);
            _fireParticleEffect = GetComponent<FireParticleEffect>();
            Init();
            EnableRagdoll(false);
        }

        private void Start()
        {
            _canRobotMove = true;
          
        }

        private void OnEnable() //Etkinleştirildiğinde
        {
            GameManager.Instance.OnGameOver += HandleOnEventTriggered;
        }

        private void OnDisable() //Devre Dışı bırakıldığında
        {
            GameManager.Instance.OnGameOver -= HandleOnEventTriggered;
        }

        private void Update() //Input'umuzu Update'den alıyoruz.
        {
            if (!_canRobotMove) //Player hareket edemiyorsa return et.
            {
                return;
            }

            if (_input.IsRobotUp &&
                !_fireParticleEffect.IsEmpty) //Robotumuz kalkışa geçtiğinde ve fireParticle boş olduğunda.
            {
                _isRobotUp = true;
                _animationController.FlyIncrease(true);
            }
            else
            {
                _isRobotUp = false;
                _fireParticleEffect.FireIncrease(0.01f); //Fire artışı
            }

            _robotRotator = _input.RobotRotator;
        }


        private void FixedUpdate() //Fixed Update'de fizik işlemlerimizi yapacağız.
        {
            if (!_canRobotMove || _mover.rigidbody.isKinematic)
            {
                return;
            }

            if (_isRobotUp)
            {
                _mover.FixedTick();
                _fireParticleEffect.FireDecrease(0.2f); //Fire düşüşü
            }

            _rotator.FixedTick(_robotRotator);

            PlayerBoundaries();
        }

        private void HandleOnEventTriggered() //Tetiklenecek yapılar
        {
            _canRobotMove = false; //Player öldüyse hareket edemeyecek
            _isRobotUp = false; //Player öldüyse Yukarı güç uygulayamayacak.
            _robotRotator = 0f; //Player öldüyse sağa sola hareket edemeyecek.
            _fireParticleEffect.FireIncrease(0f); //Player öldüyse FireParticleEffect çalışmayacak.
        }

        void PlayerBoundaries()
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minXy.position.x, _maxXy.position.x),
                Mathf.Clamp(transform.position.y, _minXy.position.y, _maxXy.position.y), 0);
        }

        public void PlayerOnFinishFloor()
        {
            _mover.rigidbody.isKinematic = true; //Player Finish Floor üzerine geldiğinde bütün hareketini durduruyoruz.
        }

        public void PlayerDeath()
        {
            _animationController.PlayerDeath();
            EnableRagdoll(true);
        }
        

        private void Init()
        {
            _allCollider = GetComponentsInChildren<Collider>(); // Bu diziye bağlı olan bütün colliderları alıyoruz
            foreach (var collider in _allCollider)
            {
                if (collider.transform != transform) // Eğer bu parentin Transformu değilse
                {
                    var rag_rb = collider.GetComponent<Rigidbody>(); // Eklediğimiz itemı al
                    if (rag_rb)
                    {
                        _ragdollRigidBodies.Add(rag_rb); // Listeye ekle
                    }
                }
            }
        }
        public void EnableRagdoll(bool enableRagdoll) {
            GetComponent<Animator>().enabled = !enableRagdoll;
            foreach(Collider item in _allCollider) {
                item.enabled = enableRagdoll; // Ragdoll etkin olarak ayarlanmışsa tüm Colliderları etkinleştir
            }

            foreach(var ragdollRigidBody in _ragdollRigidBodies) {
                ragdollRigidBody.useGravity = enableRagdoll; //Ragdoll devredeyse gravity'i etkinleştir
                ragdollRigidBody.isKinematic = !enableRagdoll; // Ragdoll devre değilse isKinematic etkinleştir
            }

            foreach(Collider item in _colliderToEnable) {
                item.enabled = !enableRagdoll; // Normal Colliderları aktif duruma çevir
            }

            GetComponent<Rigidbody>().useGravity = !enableRagdoll;
        }
    }
}