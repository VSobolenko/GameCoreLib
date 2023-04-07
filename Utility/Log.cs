namespace Game
{
public static class Log
{
    private static string InfoType => "[info]";
    private static string WarningType => "[warning]";
    private static string ErrorType => "[error]";
    private static string ExceptionType => "[exception]";
    private static string DebugType => "[debug]";
    private static string CriticalType => "[critical]";
    private static string AnalyticsType => "[analytics]";

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Write(string text)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log(text);
#endif
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Info(string text)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"{LogType(InfoType, Green)} " + text);
#endif
    }
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Warning(string text)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"{LogType(WarningType, Orange)} " + text);
#endif
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Error(string text)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"{LogType(ErrorType, Red)} " + text);
#endif
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void Exception(string text)
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"{LogType(ExceptionType, Pink)} " + text);
#endif
    }
    
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void InternalError()
    {
#if ENABLE_LOG
        UnityEngine.Debug.Log($"{LogType(CriticalType, Blue)} " + "Internal error");
#endif
    }

    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    private static string LogType(string type, string color)
    {
#if UNITY_EDITOR
        return string.Format(color, type);
#else
        return string.Concat($"[{UnityEngine.Application.identifier}]", string.Format(color, type));
#endif
    }

    #region Colors

    private static string NonColor => "{0}";
    private static string Green => "<color=#00FF00>{0}</color>";
    private static string Orange => "<color=#FF8000>{0}</color>";
    private static string Red => "<color=#FF5151>{0}</color>";
    private static string Blue => "<color=#0000FF>{0}</color>";
    private static string Cyan => "<color=#00FFFF>{0}</color>";
    private static string Yellow => "<color=#FFFF00>{0}</color>";
    private static string Violet => "<color=#8F00FF>{0}</color>";
    private static string Pink => "<color=#FFC0CB>{0}</color>";

    #endregion
}
}