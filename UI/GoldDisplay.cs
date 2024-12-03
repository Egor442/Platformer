using TMPro;
using UnityEngine;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldsCountText;
    [SerializeField] private GoldTextAnimator _goldsAnimator;

    public void PickUp(int golds)
    {
        _goldsCountText.text = golds.ToString();
        _goldsAnimator.PickUp();
    }
}