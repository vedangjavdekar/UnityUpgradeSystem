
public interface IUpgradeItemMethods
{
    bool canUpgrade { get; }
    bool reachedMaxLevel { get; }
    void Upgrade();
}
