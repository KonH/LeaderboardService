﻿/* 
 * API V1
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: v1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace IO.Swagger.Test
{
    /// <summary>
    ///  Class for testing ScoreApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class ScoreApiTests
    {
        private ScoreApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new ScoreApi(Common.DefaultConfig);
			Common.Prepare();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {
			Common.Cleanup();
        }

        /// <summary>
        /// Test an instance of ScoreApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            Assert.IsInstanceOf(typeof(ScoreApi), instance, "instance is a ScoreApi");
        }

        
        /// <summary>
        /// Test ApiScoreByIdDelete
        /// </summary>
        [Test]
        public void ApiScoreByIdDeleteTestWithRights()
        {
			string checkAuthorization = Common.AdminAuth;
			string id = instance.ApiScoreHistoryGet(checkAuthorization).First().Key;
            string authorization = Common.AdminAuth;

			instance.ApiScoreByIdDelete(id, authorization);

			var ex = Assert.Catch(() => instance.ApiScoreByIdGet(checkAuthorization, id)) as ApiException;
			Assert.AreEqual(Common.NotFoundCode, ex.ErrorCode);
        }

		/// <summary>
		/// Test ApiScoreByIdDelete
		/// </summary>
		[Test]
		public void ApiScoreByIdDeleteTestWithNoRights()
		{
			string checkAuthorization = Common.AdminAuth;
			string id = instance.ApiScoreHistoryGet(checkAuthorization).First().Key;
			string authorization = Common.UserAuth;

			var ex = Assert.Catch(() => instance.ApiScoreByIdDelete(id, authorization)) as ApiException;
			Assert.AreEqual(Common.ForbiddenCode, ex.ErrorCode);

			Assert.IsNotNull(instance.ApiScoreByIdGet(id, checkAuthorization));
		}

		/// <summary>
		/// Test ApiScoreByIdDelete
		/// </summary>
		[Test]
		public void ApiScoreByIdDeleteTestWithBadRights()
		{
			string checkAuthorization = Common.AdminAuth;
			string id = instance.ApiScoreHistoryGet(checkAuthorization).First().Key;
			string authorization = Common.OtherAuth;

			var ex = Assert.Catch(() => instance.ApiScoreByIdDelete(id, authorization)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);

			Assert.IsNotNull(instance.ApiScoreByIdGet(id, checkAuthorization));
		}

		/// <summary>
		/// Test ApiScoreByIdGet
		/// </summary>
		[Test]
        public void ApiScoreByIdGetTestWithRights()
        {
			string checkAuthorization = Common.AdminAuth;
			string id = instance.ApiScoreHistoryGet(checkAuthorization).First().Key;
			string authorization = Common.AdminAuth;

			Assert.IsNotNull(instance.ApiScoreByIdGet(id, authorization));
		}

		/// <summary>
		/// Test ApiScoreByIdGet
		/// </summary>
		[Test]
		public void ApiScoreByIdGetTestWithBadRights()
		{
			string checkAuthorization = Common.AdminAuth;
			string id = instance.ApiScoreHistoryGet(checkAuthorization).First().Key;
			string authorization = Common.OtherAuth;

			var ex = Assert.Catch(() => instance.ApiScoreByIdGet(id, authorization)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreByIdPatch
		/// </summary>
		[Test]
        public void ApiScoreByIdPatchTestWithRights()
        {
			string checkAuthorization = Common.AdminAuth;
			ScoreItem item = instance.ApiScoreHistoryGet(checkAuthorization).First();
            string authorization = Common.AdminAuth;
			item.Game = Common.GameName;

			instance.ApiScoreByIdPatch(item.Key, authorization, item);
        }

		/// <summary>
		/// Test ApiScoreByIdPatch
		/// </summary>
		[Test]
		public void ApiScoreByIdPatchTestWithNoRights()
		{
			string checkAuthorization = Common.AdminAuth;
			ScoreItem item = instance.ApiScoreHistoryGet(checkAuthorization).First();
			string authorization = Common.UserAuth;
			item.Game = Common.GameName;

			var ex = Assert.Catch(() => instance.ApiScoreByIdPatch(item.Key, authorization, item)) as ApiException;
			Assert.AreEqual(Common.ForbiddenCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreByIdPatch
		/// </summary>
		[Test]
		public void ApiScoreByIdPatchTestWithBadRights()
		{
			string checkAuthorization = Common.AdminAuth;
			ScoreItem item = instance.ApiScoreHistoryGet(checkAuthorization).First();
			string authorization = Common.OtherAuth;
			item.Game = Common.GameName;

			var ex = Assert.Catch(() => instance.ApiScoreByIdPatch(item.Key, authorization, item)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
        public void ApiScorePostTestNormalWithRights()
        {
			string checkAuthorization = Common.AdminAuth;
            string authorization = Common.AdminAuth;
            ScoreItem item = new ScoreItem(null, Common.GameName, null, null, 100, Common.UserName);

			var result = instance.ApiScorePost(authorization, item);

			Assert.IsNotNull(instance.ApiScoreHistoryGet(checkAuthorization).Select(obj => obj.Key == result.Key));
        }

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestNormalWithNoRights()
		{
			string userName = "userWithoutRights";
			UserApi api = new UserApi(Common.DefaultConfig);
			api.ApiUserPost(Common.AdminAuth, new User(userName, userName, new List<UserRole>()));
			string authorization = Common.GetAuthHeader(userName, userName);
			ScoreItem item = new ScoreItem(null, Common.GameName, null, null, 100, Common.UserName);

			var ex = Assert.Catch(() => instance.ApiScorePost(authorization, item)) as ApiException;
			Assert.AreEqual(Common.ForbiddenCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestNormalWithBadRights()
		{
			string authorization = Common.OtherAuth;
			ScoreItem item = new ScoreItem(null, Common.GameName, null, null, 100, Common.UserName);

			var ex = Assert.Catch(() => instance.ApiScorePost(authorization, item)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestMassiveSequence() {
			int itemsToSend = 100;

			string checkAuthorization = Common.AdminAuth;
			string authorization = Common.AdminAuth;
			ScoreItem item = new ScoreItem(null, Common.GameName, null, null, 100, Common.UserName);

			for ( int i = 0; i < itemsToSend; i++ ) {
				var result = instance.ApiScorePost(authorization, item);
				Assert.IsNotNull(instance.ApiScoreHistoryGet(checkAuthorization).Select(obj => obj.Key == result.Key));
			}
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestMassiveParallel()
		{
			int itemsToSend = 100;

			var threads = new List<Thread>();
			for ( int i = 0; i < itemsToSend; i++ ) 
			{
				var thread = new Thread(() => { ApiScorePostTestMassiveParallelSubTest(); });
				thread.Start();
				threads.Add(thread);
			}
			while ( threads.Count > 0 )
			{
				for(int i = 0; i < threads.Count; i++ )
				{
					if(threads[i].ThreadState == ThreadState.Stopped)
					{
						threads.RemoveAt(i);
						break;
					}
				}
			}
		}

		void ApiScorePostTestMassiveParallelSubTest()
		{
			string checkAuthorization = Common.AdminAuth;
			string authorization = Common.AdminAuth;
			ScoreItem item = new ScoreItem(null, Common.GameName, null, null, 100, Common.UserName);
			var result = instance.ApiScorePost(authorization, item);
			Assert.IsNotNull(instance.ApiScoreHistoryGet(checkAuthorization).Select(obj => obj.Key == result.Key));
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestBadGameName()
		{
			string authorization = Common.AdminAuth;
			ScoreItem item = new ScoreItem(null, Guid.NewGuid().ToString(), null, null, 100, Common.UserName);

			var ex1 = Assert.Catch(() => instance.ApiScorePost(authorization, item)) as ApiException;
			Assert.AreEqual(Common.BadRequestCode, ex1.ErrorCode);
		}

		/// <summary>
		/// Test ApiScorePost
		/// </summary>
		[Test]
		public void ApiScorePostTestBadUserName()
		{
			string authorization = Common.AdminAuth;
			ScoreItem item = new ScoreItem(null, Guid.NewGuid().ToString(), null, null, 100, Guid.NewGuid().ToString());

			var ex1 = Assert.Catch(() => instance.ApiScorePost(authorization, item)) as ApiException;
			Assert.AreEqual(Common.BadRequestCode, ex1.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestParam()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			string newParam = Guid.NewGuid().ToString();
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, newParam, 1000, user));

			var items = instance.ApiScoreTopByGameGet(game, authorization, int.MaxValue, newParam).ToArray();
			Assert.IsNotEmpty(items);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestVersion()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			string newVersion = Guid.NewGuid().ToString();
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, newVersion, null, 1000, user));

			var items = instance.ApiScoreTopByGameGet(game, authorization, int.MaxValue, null, newVersion).ToArray();
			Assert.IsNotEmpty(items);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestTime()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 1000, user));
			var firstResult = instance.ApiScoreTopByGameGet(game, authorization).Where(u => u.User == user).First();

			Thread.Sleep(100);

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 1100, user));
			var secondResult = instance.ApiScoreTopByGameGet(game, authorization).Where(u => u.User == user).First();

			Assert.IsTrue(secondResult.Date > firstResult.Date);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestMax()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 200, user));

			var rawItems = instance.ApiScoreTopByGameGet(game, authorization).ToArray();
			var limitItems = instance.ApiScoreTopByGameGet(game, authorization, 1).ToArray();

			Assert.IsTrue(limitItems.Length < rawItems.Length);
			Assert.IsTrue(limitItems.Length == 1);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestBadGame()
		{
			string authorization = Common.AdminAuth;
			Assert.IsEmpty(instance.ApiScoreTopByGameGet(Guid.NewGuid().ToString(), authorization));
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestOneElementPerUser()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 200, user));
			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 300, user));

			var userItems = instance.ApiScoreTopByGameGet(game, authorization).Where(item => item.User == user).ToArray();

			Assert.IsTrue(userItems.Length == 1);
			Assert.IsTrue(userItems[0].Score == 300);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestWithRights()
		{
			string authorization = Common.AdminAuth;
			string game = Common.GameName;
			Assert.IsNotEmpty(instance.ApiScoreTopByGameGet(game, authorization));
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestWithNoRights()
		{
			string userName = "userWithoutRights";
			UserApi api = new UserApi(Common.DefaultConfig);
			api.ApiUserPost(Common.AdminAuth, new User(userName, userName, new List<UserRole>()));
			string authorization = Common.GetAuthHeader(userName, userName);
			string game = Common.GameName;
			var ex = Assert.Catch(() => instance.ApiScoreTopByGameGet(game, authorization)) as ApiException;
			Assert.AreEqual(Common.ForbiddenCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreTop
		/// </summary>
		[Test]
		public void ApiScoreTopTestWithBadRights()
		{
			string authorization = Common.OtherAuth;
			string game = Common.GameName;
			var ex = Assert.Catch(() => instance.ApiScoreTopByGameGet(game, authorization)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestForGame()
		{
			string authorization = Common.AdminAuth;
			string user = Common.UserName;

			var prevHistory = instance.ApiScoreHistoryGet(authorization, Common.GameName).ToArray();

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 100, user));

			var history = instance.ApiScoreHistoryGet(authorization, Common.GameName).ToArray();
			Assert.IsTrue(history.Length > prevHistory.Length);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestForVersion()
		{
			string authorization = Common.AdminAuth;

			var newVersion = Guid.NewGuid().ToString();

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, newVersion, null, 100, Common.UserName));

			var history = instance.ApiScoreHistoryGet(authorization, null, null, newVersion).ToArray();
			Assert.IsNotEmpty(history);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestForParam()
		{
			string authorization = Common.AdminAuth;

			var newParam = Guid.NewGuid().ToString();

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, newParam, 100, Common.UserName));

			var history = instance.ApiScoreHistoryGet(authorization, null, newParam).ToArray();
			Assert.IsNotEmpty(history);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestSeveralElementsForUser()
		{
			string authorization = Common.AdminAuth;
			string user = Common.UserName;

			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 100, user));
			instance.ApiScorePost(authorization, new ScoreItem(null, Common.GameName, null, null, 100, user));

			var history = instance.ApiScoreHistoryGet(authorization).Where(item => item.User == user).ToArray();
			Assert.IsTrue(history.Length > 1);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestWithRights()
		{
			string authorization = Common.AdminAuth;
			Assert.IsNotEmpty(instance.ApiScoreHistoryGet(authorization));
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestWithNoRights()
		{
			string authorization = Common.UserAuth;
			var ex = Assert.Catch(() => instance.ApiScoreHistoryGet(authorization)) as ApiException;
			Assert.AreEqual(Common.ForbiddenCode, ex.ErrorCode);
		}

		/// <summary>
		/// Test ApiScoreHistory
		/// </summary>
		[Test]
		public void ApiScoreHistoryTestWithBadRights()
		{
			string authorization = Common.OtherAuth;
			var ex = Assert.Catch(() => instance.ApiScoreHistoryGet(authorization)) as ApiException;
			Assert.AreEqual(Common.NeedAuthCode, ex.ErrorCode);
		}
	}

}
