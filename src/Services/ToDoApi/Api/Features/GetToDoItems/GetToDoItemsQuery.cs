using System.Globalization;
using FluentResults;

namespace ToDoApi.Features.GetToDoItems
{
    public record GetToDoItemsQuery(int ItemCountOnPage, int PageNumber) : IRequest<Result<GetToDoItemsResponse[]>>, IParsable<GetToDoItemsQuery>
    {
        public static GetToDoItemsQuery Parse(string s, IFormatProvider? provider)
        {
            // Rozdzielamy ciąg wejściowy na dwa elementy, np. "20,2" -> ["20", "2"]
            var parts = s.Split(',');

            if (parts.Length != 2)
            {
                throw new FormatException("Input string does not have the correct format.");
            }

            // Próbujemy sparsować oba elementy
            if (int.TryParse(parts[0], NumberStyles.Integer, provider, out var itemCountOnPage) &&
                int.TryParse(parts[1], NumberStyles.Integer, provider, out var pageNumber))
            {
                return new GetToDoItemsQuery(itemCountOnPage, pageNumber);
            }
            else
            {
                throw new FormatException("Input string could not be parsed into GetToDoItemsQuery.");
            }
        }

        public static bool TryParse([System.Diagnostics.CodeAnalysis.NotNullWhen(true)] string? s, IFormatProvider? provider,
            [System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out GetToDoItemsQuery result)
        {
            result = null;

            // Jeśli s jest null, zwróć false
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            // Rozdzielamy ciąg wejściowy na dwa elementy
            var parts = s.Split(',');

            // Sprawdzamy, czy mamy dokładnie dwa elementy
            if (parts.Length == 2 &&
                int.TryParse(parts[0], NumberStyles.Integer, provider, out var itemCountOnPage) &&
                int.TryParse(parts[1], NumberStyles.Integer, provider, out var pageNumber))
            {
                result = new GetToDoItemsQuery(itemCountOnPage, pageNumber);
                return true;
            }

            return false;
        }
    }
}
