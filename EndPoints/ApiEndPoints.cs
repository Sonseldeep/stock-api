namespace API.EndPoints;
public static class ApiEndPoints
{
    private const string ApiBase = "api";

  
    public static class Stocks
    {
        private const string Base = $"{ApiBase}/stocks";
        public const string GetAll = Base;
        public const string Create = Base;
        public const string GetById = $"{Base}/{{id:int}}";
        public const string Update = $"{Base}/{{id:int}}";
        public const string Delete = $"{Base}/{{id:int}}";
    }

   
    public static class Comments
    {
        private const string Base = $"{ApiBase}/comments";
        public const string GetAll = Base;
        public const string Create = $"{Base}/{{stockId:int}}";
        public const string GetById = $"{Base}/{{id:int}}";
        public const string Update = $"{Base}/{{id:int}}";
        public const string Delete = $"{Base}/{{id:int}}";
    }
}
