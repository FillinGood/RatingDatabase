using System.IO;
using System.Runtime.CompilerServices;

namespace RatingDatabase;
public static class Util {
    public static string CurrentSourcePath { get; } = GetCurrentSourcePath();

    public static int Clamp(int x, int min, int max) {
        return x < min ? min : x > max ? max : x;
    }

    private static string GetCurrentSourcePath([CallerFilePath] string path = "") {
        return Path.GetDirectoryName(path) ?? ".";
    }
}
