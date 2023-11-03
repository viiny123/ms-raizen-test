using System.Diagnostics.CodeAnalysis;

namespace Test.Raizen.Application.Base.Error;

[ExcludeFromCodeCoverage]
public static class ErrorCatalog
{
    [ExcludeFromCodeCoverage]
    public static class TestError
    {

        #region Base

        public static ErrorCatalogEntry BaseInvalidRequest =>
            ("RAIZEN-STANDAR-01", "Invalid request");

        #endregion Base


        #region GetById

        public static ErrorCatalogEntry GetByIdNotFound =>
            ("RAIZEN-GETBYID-01", "[id] not found");

        #endregion

        #region Get
        public static ErrorCatalogEntry GetByPostalCodeIsNullOrEmpty =>
            ("RAIZEN-GET-01", "[postalCode] parameter cant be null or empty");
        #endregion

        #region Craete

        public static ErrorCatalogEntry CreateNameIsNullOrEmpty =>
            ("RAIZEN-CREATE-01", "[name] parameter cant be null or empty");

        public static ErrorCatalogEntry CreateEmailIsNullOrEmpty =>
            ("RAIZEN-CREATE-02", "[email] parameter cant be null or empty");

        public static ErrorCatalogEntry CreateBirthDayIsNull =>
            ("RAIZEN-CREATE-03", "[code] parameter cant be null");

        public static ErrorCatalogEntry CreatePostalCodeIsNullOrEmpty =>
            ("RAIZEN-CREATE-04", "[postalCode] parameter cant be null or empty");

        #endregion

        #region Delete
        public static ErrorCatalogEntry DeleteIdIsNullOrEmpty =>
            ("RAIZEN-DELETE-01", "[id] parameter cant be null or empty");
        #endregion
    }
}
