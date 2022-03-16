namespace RatingDatabase;
public static class Util {
    public static int Clamp(int x, int min, int max) {
        return x < min ? min : x > max ? max : x;
    }
}
