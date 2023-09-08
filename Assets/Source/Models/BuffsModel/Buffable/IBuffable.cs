using System;

public interface IBuffable
{
    public Type BuffableType { get; }
    
    public void ApplyBuff(Buff buffConfig);

    public void EndBuff(Buff buffConfig);
}