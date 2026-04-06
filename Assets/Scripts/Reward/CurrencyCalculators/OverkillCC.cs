using UnityEngine;
public class OverkillCC : CurrencyCalculator
{
    public override int CalculateCurrency()
    {
        int? overkillHealthNullable = GameHandler.Instance.GetOpponentCurrentHealth();
        if (overkillHealthNullable.HasValue)
        {
            int overkillHealth = Mathf.Abs(overkillHealthNullable.GetValueOrDefault());
            return 5 + (overkillHealth / 5);
        }
        else return 0;
    }

    public override string GetExplanationText()
    {
        return "From your Overkill payout: (Overkill:" + (Mathf.Abs(GameHandler.Instance.GetOpponentCurrentHealth().GetValueOrDefault())).ToString() + " hp) = ";

    }
}
