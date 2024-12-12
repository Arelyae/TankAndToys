using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAppearance : MonoBehaviour
{

    public TankDataRSo TankDataRSo;

    public List<SpriteRenderer> primarColor;
    public List<SpriteRenderer> secondaryColor;


    // Start is called before the first frame update
    void Start()
    {
        PrimaryColorSet();
        SecondaryColorSet();
    }

    public void PrimaryColorSet()
    {
        foreach (SpriteRenderer spriteRenderer in primarColor)
        {
            spriteRenderer.color = TankDataRSo.primarColor;
        }

    }

    public void SecondaryColorSet()
    {
        foreach (SpriteRenderer spriteRenderer in secondaryColor)
        {
            spriteRenderer.color = TankDataRSo.secondColor;
        }

    }
}