using System.ComponentModel.DataAnnotations;

namespace Blazor.Project.Common.Extensions;

public static class StringExtensions
{
    public static bool ValidEmail(this string email)
    {
        return new EmailAddressAttribute().IsValid(email);
    }
}