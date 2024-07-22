using TMPro;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class SC_PlayerPowerView : ConcreteUIElementView
{
    public SC_PlayerPowerView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIUpdate(int amount)
    {
        _ =UpdatePower(amount);
    }

    public override void UIDec(int amount,int damage)
    {
        _ = DecPower(amount, damage);

    }

    private async Task DecPower(int amount,int to_dec)
    {
        string _power = string.Empty;
        for (int i = 0; i < (amount- to_dec); i++,--amount) {
            for (int j = 0; j < i; j++)
            {
                _power += "I";
                text_element.text = _power;
                await Task.Delay(100);
            }
        }

    }
    private async Task UpdatePower(int amount)
    {
        string _power = string.Empty;
        for (int i = 0; i < amount; i++)
        {
            _power += "I";
            text_element.text = _power;
            await Task.Delay(100);
        }
    }
}
