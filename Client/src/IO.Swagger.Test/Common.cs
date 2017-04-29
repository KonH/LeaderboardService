using System;
using System.Text;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace IO.Swagger.Test {
	static class Common {
		public const string AdminAuth = "Basic YWRtaW46YWRtaW4=";
		public const string UserAuth = "Basic dXNlcjp1c2Vy";
		public const string OtherAuth = "Basic YWRtaW5qcDtqazphZG1pbg==";
		public const int NeedAuthCode = 401;
		public const int ForbiddenCode = 403;
		public const string UserName = "user";
		public const string AdminName = "admin";
		public const string GameName = "Game";

		public static Configuration DefaultConfig
		{
			get {
				return new Configuration(new ApiClient("http://127.0.0.1:8080"));
			}
		}

		public static void Prepare()
		{
			var testApi = new TestApi(DefaultConfig);
			testApi.ApiTestPreparePost();
		}

		public static void Cleanup()
		{
			var testApi = new TestApi(DefaultConfig);
			testApi.ApiTestCleanupPost();
		}

		public static string GetAuthHeader(string username, string password)
		{
			return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
		}
	}
}
