public static class XephMath
{
    public static float Lerp(float start, float end, float t)
    {
        return (end - start) * t + start;
    }

    public static float QuadLerp(float start, float end, float weight, float t)
    {
        return Lerp(Lerp(start, weight, t), Lerp(weight, end, t), t);
    }

    public static float CubicLerp(float start, float end, float weight1, float weight2, float t)
    {
        float a = Lerp(start, weight1, t);
        float b = Lerp(weight1, weight2, t);
        float c = Lerp(weight2, end, t);

        return Lerp(Lerp(a, b, t), Lerp(b, c, t), t);
    }
}