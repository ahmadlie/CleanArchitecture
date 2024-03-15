namespace CleanArchitecture.WebApi.Infrastructure;
public static class VersionHelper
{
    public static string GetVersion(this object type)
    {
        string[] nameSpaces = null;
        if (type is Delegate instance)
        {
            nameSpaces = instance.Target.GetType().Namespace.Split(".");
        }
        else
        {
            nameSpaces = type.GetType().Namespace.Split(".");

        }


        string version = nameSpaces.LastOrDefault(p => p.StartsWith("v") || p.StartsWith("V"));
        return version;
    }
}
