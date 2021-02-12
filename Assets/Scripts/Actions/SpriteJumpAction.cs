using UnityEngine;

public class SpriteJumpAction : MonoBehaviour, IPressable
{
    [SerializeField] Animator acSprite;
    public void Press()
    {
        acSprite.Play("Jump");
    }
}
