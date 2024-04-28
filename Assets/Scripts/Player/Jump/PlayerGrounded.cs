using System.Collections;
using System.Collections.Generic;
using UniRx;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerGrounded : MonoBehaviour
{
    [SerializeField] private float _checkRange;
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private LayerMask _layerMask;

    public BoolReactiveProperty Grounded { get; private set; } = new BoolReactiveProperty();

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_checkPoint.position, _checkRange);
    }

    private void Update()
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(_checkPoint.position, _checkRange, _layerMask);

        if (hitCollider != null)
        {
            Grounded.Value = true;
        }
        else
        {
            Grounded.Value = false;
        }

        Debug.Log(hitCollider + " " + Grounded);
    }
}