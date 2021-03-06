# IO.Swagger.Api.ScoreApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiScoreByIdDelete**](ScoreApi.md#apiscorebyiddelete) | **DELETE** /api/Score/{id} | 
[**ApiScoreByIdGet**](ScoreApi.md#apiscorebyidget) | **GET** /api/Score/{id} | 
[**ApiScoreByIdPatch**](ScoreApi.md#apiscorebyidpatch) | **PATCH** /api/Score/{id} | 
[**ApiScoreHistoryGet**](ScoreApi.md#apiscorehistoryget) | **GET** /api/Score/history | 
[**ApiScorePost**](ScoreApi.md#apiscorepost) | **POST** /api/Score | 
[**ApiScoreTopByGameGet**](ScoreApi.md#apiscoretopbygameget) | **GET** /api/Score/top/{game} | 


<a name="apiscorebyiddelete"></a>
# **ApiScoreByIdDelete**
> void ApiScoreByIdDelete (string id, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByIdDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var id = id_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiScoreByIdDelete(id, authorization);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByIdDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorebyidget"></a>
# **ApiScoreByIdGet**
> ScoreItem ApiScoreByIdGet (string id, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByIdGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var id = id_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                ScoreItem result = apiInstance.ApiScoreByIdGet(id, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByIdGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

[**ScoreItem**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorebyidpatch"></a>
# **ApiScoreByIdPatch**
> void ApiScoreByIdPatch (string id, string authorization = null, ScoreItem item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByIdPatchExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var id = id_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 
            var item = new ScoreItem(); // ScoreItem |  (optional) 

            try
            {
                apiInstance.ApiScoreByIdPatch(id, authorization, item);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByIdPatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 
 **authorization** | **string**|  | [optional] 
 **item** | [**ScoreItem**](ScoreItem.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorehistoryget"></a>
# **ApiScoreHistoryGet**
> List<ScoreItem> ApiScoreHistoryGet (string authorization = null, string game = null, string param = null, string version = null, string user = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreHistoryGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var authorization = authorization_example;  // string |  (optional) 
            var game = game_example;  // string |  (optional) 
            var param = param_example;  // string |  (optional) 
            var version = version_example;  // string |  (optional) 
            var user = user_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreHistoryGet(authorization, game, param, version, user);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreHistoryGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 
 **game** | **string**|  | [optional] 
 **param** | **string**|  | [optional] 
 **version** | **string**|  | [optional] 
 **user** | **string**|  | [optional] 

### Return type

[**List<ScoreItem>**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorepost"></a>
# **ApiScorePost**
> ScoreItem ApiScorePost (string authorization = null, ScoreItem item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScorePostExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var authorization = authorization_example;  // string |  (optional) 
            var item = new ScoreItem(); // ScoreItem |  (optional) 

            try
            {
                ScoreItem result = apiInstance.ApiScorePost(authorization, item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScorePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 
 **item** | [**ScoreItem**](ScoreItem.md)|  | [optional] 

### Return type

[**ScoreItem**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscoretopbygameget"></a>
# **ApiScoreTopByGameGet**
> List<ScoreItem> ApiScoreTopByGameGet (string game, string authorization = null, int? max = null, string param = null, string version = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreTopByGameGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var game = game_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 
            var max = 56;  // int? |  (optional) 
            var param = param_example;  // string |  (optional) 
            var version = version_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreTopByGameGet(game, authorization, max, param, version);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreTopByGameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **game** | **string**|  | 
 **authorization** | **string**|  | [optional] 
 **max** | **int?**|  | [optional] 
 **param** | **string**|  | [optional] 
 **version** | **string**|  | [optional] 

### Return type

[**List<ScoreItem>**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

