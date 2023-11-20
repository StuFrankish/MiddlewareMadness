namespace ApiMiddleware.Constants;

public static class MyMiddlewareConstants
{
    public static class EndpointNames
    {
        public const string Info = "Info";
        public const string UI = "UI";
        public const string Resource = "Resource";
    }

    public static class EndpointPaths
    {
        public const string PathPrefix = "api";

        public const string Info = PathPrefix + "/info";
        public const string UI = PathPrefix + "/ui";
        public const string Resource = PathPrefix + "/resource";
    }

    public static class ResourceFileNames
    {
        public const string ResourceFileBaseName = "ApiMiddleware.MiddlewareResources";
    }
}
