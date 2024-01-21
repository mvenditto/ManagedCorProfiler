namespace Windows.Win32.Foundation;

public unsafe readonly partial struct PWSTR
{
    /// <summary>
    /// Returns a <see langword="string"/> with a copy of this character array, up to the specified <paramref name="length"/>
    /// </summary>
    /// <param name="length">The previously known length of this null-terminated string.</param>
    /// <returns>A <see langword="string"/>, or <see langword="null"/> if <see cref="Value"/> is <see langword="null"/>.</returns>
    public string? CopyToString(int length)
    {
        return Value == null ? null : new string(Value, 0, length);
    }
}