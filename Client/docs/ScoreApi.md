# IO.Swagger.Api.ScoreApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiScoreByGameByParamByVersionGet**](ScoreApi.md#apiscorebygamebyparambyversionget) | **GET** /api/Score/{game}/{param}/{version} | 
[**ApiScoreByGameByParamGet**](ScoreApi.md#apiscorebygamebyparamget) | **GET** /api/Score/{game}/{param} | 
[**ApiScoreByGameGet**](ScoreApi.md#apiscorebygameget) | **GET** /api/Score/{game} | 
[**ApiScoreByIdDelete**](ScoreApi.md#apiscorebyiddelete) | **DELETE** /api/Score/{id} | 
[**ApiScoreByIdGet**](ScoreApi.md#apiscorebyidget) | **GET** /api/Score/{id} | 
[**ApiScoreByIdPatch**](ScoreApi.md#apiscorebyidpatch) | **PATCH** /api/Score/{id} | 
[**ApiScoreGet**](ScoreApi.md#apiscoreget) | **GET** /api/Score | 
[**ApiScorePost**](ScoreApi.md#apiscorepost) | **POST** /api/Score | 


<a name="apiscorebygamebyparambyversionget"></a>
# **ApiScoreByGameByParamByVersionGet**
> List<ScoreItem> ApiScoreByGameByParamByVersionGet (string game, string param, string version, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByGameByParamByVersionGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var game = game_example;  // string | 
            var param = param_example;  // string | 
            var version = version_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreByGameByParamByVersionGet(game, param, version, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByGameByParamByVersionGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **game** | **string**|  | 
 **param** | **string**|  | 
 **version** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

[**List<ScoreItem>**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorebygamebyparamget"></a>
# **ApiScoreByGameByParamGet**
> List<ScoreItem> ApiScoreByGameByParamGet (string game, string param, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByGameByParamGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var game = game_example;  // string | 
            var param = param_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreByGameByParamGet(game, param, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByGameByParamGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **game** | **string**|  | 
 **param** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

[**List<ScoreItem>**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apiscorebygameget"></a>
# **ApiScoreByGameGet**
> List<ScoreItem> ApiScoreByGameGet (string game, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreByGameGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var game = game_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreByGameGet(game, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreByGameGet: " + e.Message );
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

### Return type

[**List<ScoreItem>**](ScoreItem.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

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
> void ApiScoreByIdGet (string id, string authorization = null)



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
                apiInstance.ApiScoreByIdGet(id, authorization);
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

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

<a name="apiscoreget"></a>
# **ApiScoreGet**
> List<ScoreItem> ApiScoreGet (string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiScoreGetExample
    {
        public void main()
        {
            
            var apiInstance = new ScoreApi();
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;ScoreItem&gt; result = apiInstance.ApiScoreGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScoreApi.ApiScoreGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 

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
> void ApiScorePost (string authorization = null, ScoreItem item = null)



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
                apiInstance.ApiScorePost(authorization, item);
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

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

