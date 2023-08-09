using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    private Animator animator;

    [SerializeField] GameObject particleVFX;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Called when the mouse enters the GUIElement or Collider.
    /// </summary>
    void OnMouseEnter()
    {
        StartCoroutine(ExampleCoroutine());
    }
    private IEnumerator ExampleCoroutine()
    {
        animator.SetTrigger("Rotate");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);

        GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].circles.Remove(this);
        GameObject explosion = Instantiate(particleVFX, transform.position, transform.rotation);
        Destroy(explosion, .75f);
        Destroy(gameObject);
    }
}