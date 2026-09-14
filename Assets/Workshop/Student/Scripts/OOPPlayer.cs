using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPPlayer : Character
    {
        public Inventory inventory;

        private InputAction moveAction;

        void Awake()
        {
            moveAction = InputSystem.actions.FindAction("Move");
        }

        public void Start()
        {
            PrintInfo();
            GetRemainEnergy();
            inventory = GetComponent<Inventory>();
        }

        public void Update()
        {
            var dir = moveAction.ReadValue<Vector2>();
            if (dir != Vector2.zero && moveAction.triggered)
            {
                Move(dir);
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.TakeDamage(AttackPoint);
        }
        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }

    }

}