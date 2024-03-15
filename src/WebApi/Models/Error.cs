namespace CleanArchitecture.WebApi.Models;
 
/// <summary>
/// Error Result
/// </summary>
public class Error
{
    /// <summary>
    /// Get Error Status Code
    /// </summary>
    public int StatusCode { get; set; }

    /// <summary>
    /// Get Error Title
    /// </summary>
    public string Title { get; set; } = null!;

    /// <summary>
    /// Get Error Description
    /// </summary>
    public string? Description { get; set; }
}
