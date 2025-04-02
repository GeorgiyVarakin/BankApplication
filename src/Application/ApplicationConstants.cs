namespace Src.Application;

public static class ApplicationConstants
{
    public static long MinGuid { get; } = 100000000000; // 12 digits

    public static long MaxGuid { get; } = 999999999999; // 12 digits

    public static int MinPasswordLength { get; } = 10;

    public static int MaxPasswordLength { get; } = 64;
}
