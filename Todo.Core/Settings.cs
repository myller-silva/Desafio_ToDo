using Microsoft.Extensions.DependencyInjection;

namespace Todo.Core;

public static class Settings
{
    public static string Issuer = "http://localhost:5162";
    public static string Audience = "http://localhost:5162";
    public static string Secret = "fedaasdafd7dda8d8as63b4hf8je1r9v7xcbbvcn92r8tg7vvcd492b708e";
    public static int ExpiracaoToken = 1;
 
}