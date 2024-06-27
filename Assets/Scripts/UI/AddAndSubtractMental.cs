using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAndSubtractMental : Singleton<AddAndSubtractMental>
{
    public void AddMental()
    {
        PlayerData.Instance.AddMentalHealth(5);
    }
    public void SubtractMental()
    {
        PlayerData.Instance.AddMentalHealth(-5);
    }

    public void AddOrSubMental(int x)
    {
        PlayerData.Instance.AddMentalHealth(x);
    }
}
