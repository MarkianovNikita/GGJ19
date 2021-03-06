﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _attackDistance;
    [SerializeField]
    private EnemyController _enemyController;
    [SerializeField]
    private Animator _animator;

    private Player _player;

    public void SetPlayer(Player player)
    {
        _player = player;
        _enemyController.SetTargetToFollow(_player.transform);
    }

    private void Update()
    {
        if (_player == null) return;

        if (Vector3.Distance(_player.transform.position, transform.position) < _attackDistance)
        {
            _animator.SetTrigger("Attack");
            _enemyController.Wait = true;
        }
    }

    public void Attack()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < _attackDistance)
        {
            _player.GetComponent<PlayerHealth>().Damage();
        }
        _enemyController.Wait = false;
    }
}
