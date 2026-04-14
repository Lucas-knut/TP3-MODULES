using Hotel.Housekeeping.Contracts;

namespace Hotel.Housekeeping;

public static class CleaningPolicyFactory
{
    public static ICleaningPolicy CreateStandard() => new StandardCleaningPolicy();
    public static ICleaningPolicy CreateVip() => new VipCleaningPolicy();
}
