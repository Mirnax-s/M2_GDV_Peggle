
using System;   //nodig voor Action
using UnityEngine;
public class BumperHit : MonoBehaviour
{
    [SerializeField] private int scoreValue = 10;
    public static event Action<string, int> onBumperHit;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball")) {
            onBumperHit?.Invoke(gameObject.tag, scoreValue);//bericht versturen dat er een bumper geraakt is. De tag en waarde sturen we mee

        }
    }
}