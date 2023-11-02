using System.Diagnostics.CodeAnalysis;

namespace Test.Raizen.Application.Base.Error
{
    [ExcludeFromCodeCoverage]
    public static class ErrorCatalog
    {
        [ExcludeFromCodeCoverage]
        public static class Value
        {

            #region Base

            public static ErrorCatalogEntry BaseInvalidRequest =>
                ("TEMPLATE-STANDAR-01", "Invalid request");

            #endregion Base

            #region Get

            public static ErrorCatalogEntry GetCodeIsNullOrEmpty =>
                ("TEMPLATE-GET-01", "[code] parameter cant be null or empty");

            #endregion Get

            #region GetById

            public static ErrorCatalogEntry GetByIdNotFound =>
                ("TEMPLATE-GETBYID-01", "[id] not found");

            #endregion Get

            #region Craete

            public static ErrorCatalogEntry CraeteCodeIsNullOrEmpty =>
                ("TEMPLATE-CREATE-01", "[code] parameter cant be null or empty");

            public static ErrorCatalogEntry CraeteDescriptionIsNullOrEmpty =>
                ("TEMPLATE-CREATE-02", "[description] parameter cant be null or empty");

            public static ErrorCatalogEntry CodeCanBeNegativeNumber =>
                ("TEMPLATE-CREATE-03", "[code] parameter cant be -1");

            #endregion Create
        }
    }
}
