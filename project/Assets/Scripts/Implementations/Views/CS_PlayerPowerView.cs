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

        Color original = ChangeTextColor(Color.red);
        string _power = string.Empty;
        --amount;
        for (int i = 0;
            i < to_dec;
            i++,--amount, _power = string.Empty)
        {
            for (int j = 0; j < amount; j++)
            {
                _power += "I";
            }
            text_element.text = _power;
            await Task.Delay(700);
        }
        ChangeTextColor(original);
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

   private Color ChangeTextColor(Color dest_color)
    {
        //returns buttom left gradiant color before changing

        Color original = text_element.colorGradient.bottomLeft;
        VertexGradient vertexGradient = text_element.colorGradient;
        vertexGradient.bottomLeft = dest_color;
        text_element.colorGradient = vertexGradient;
        return original;
    }
}
