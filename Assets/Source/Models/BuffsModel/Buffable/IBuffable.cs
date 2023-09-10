using System;

public interface IBuffable
{
    public void ApplyBuff(Buff buffConfig);

    public void EndBuff(Buff buffConfig);

    public bool CheckType(Buff type);
}