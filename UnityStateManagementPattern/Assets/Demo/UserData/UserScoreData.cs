using System;

[Serializable]
public class CurrencyDataEntity : IUserDataEntity
{
    public long money;
}

[Serializable]
public class UserCurrencyData : UserDataBase<CurrencyDataEntity>, IMainData
{
    public long Money => entity.money;

    public void EarnMoney(long amount)
    {
        entity.money += amount;
    }
}