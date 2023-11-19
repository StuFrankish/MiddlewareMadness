namespace ApiMiddleware.Constants;

public static class MyMiddlewareConstants
{
    public static class EndpointNames
    {
        public const string Info = "Info";
        public const string UI = "UI";
    }

    public static class EndpointPaths
    {
        public const string PathPrefix = "api";

        public const string Info = PathPrefix + "/info";
        public const string UI = PathPrefix + "/ui";
    }
}
