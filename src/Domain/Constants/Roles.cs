namespace CleanArchitecture.Domain.Constants;

public abstract class Roles
{
    public const string Admin = nameof(Admin);
}

public abstract class Sessions
{
    public const string SESSION_KEY_CATEGORIES = nameof(SESSION_KEY_CATEGORIES);
    public const string SESSION_KEY_PRODUCTS = nameof(SESSION_KEY_PRODUCTS);
}

public abstract class Cookies
{
    public const string COOKIE_KEY_CATEGORIES = nameof(COOKIE_KEY_CATEGORIES);
    public const string COOKIE_KEY_PRODUCTS = nameof(COOKIE_KEY_PRODUCTS);
}
