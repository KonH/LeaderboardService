# IO.Swagger.Api.GameApi

All URIs are relative to *https://localhost/*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ApiGameByNameDelete**](GameApi.md#apigamebynamedelete) | **DELETE** /api/Game/{name} | 
[**ApiGameByNameGet**](GameApi.md#apigamebynameget) | **GET** /api/Game/{name} | 
[**ApiGameByNamePatch**](GameApi.md#apigamebynamepatch) | **PATCH** /api/Game/{name} | 
[**ApiGameGet**](GameApi.md#apigameget) | **GET** /api/Game | 
[**ApiGamePost**](GameApi.md#apigamepost) | **POST** /api/Game | 


<a name="apigamebynamedelete"></a>
# **ApiGameByNameDelete**
> void ApiGameByNameDelete (string name, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiGameByNameDeleteExample
    {
        public void main()
        {
            
            var apiInstance = new GameApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                apiInstance.ApiGameByNameDelete(name, authorization);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.ApiGameByNameDelete: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apigamebynameget"></a>
# **ApiGameByNameGet**
> User ApiGameByNameGet (string name, string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiGameByNameGetExample
    {
        public void main()
        {
            
            var apiInstance = new GameApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                User result = apiInstance.ApiGameByNameGet(name, authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.ApiGameByNameGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apigamebynamepatch"></a>
# **ApiGameByNamePatch**
> void ApiGameByNamePatch (string name, string authorization = null, Game item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiGameByNamePatchExample
    {
        public void main()
        {
            
            var apiInstance = new GameApi();
            var name = name_example;  // string | 
            var authorization = authorization_example;  // string |  (optional) 
            var item = new Game(); // Game |  (optional) 

            try
            {
                apiInstance.ApiGameByNamePatch(name, authorization, item);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.ApiGameByNamePatch: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **name** | **string**|  | 
 **authorization** | **string**|  | [optional] 
 **item** | [**Game**](Game.md)|  | [optional] 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: Not defined

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apigameget"></a>
# **ApiGameGet**
> List<Game> ApiGameGet (string authorization = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiGameGetExample
    {
        public void main()
        {
            
            var apiInstance = new GameApi();
            var authorization = authorization_example;  // string |  (optional) 

            try
            {
                List&lt;Game&gt; result = apiInstance.ApiGameGet(authorization);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.ApiGameGet: " + e.Message );
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

[**List<Game>**](Game.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="apigamepost"></a>
# **ApiGamePost**
> User ApiGamePost (string authorization = null, Game item = null)



### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class ApiGamePostExample
    {
        public void main()
        {
            
            var apiInstance = new GameApi();
            var authorization = authorization_example;  // string |  (optional) 
            var item = new Game(); // Game |  (optional) 

            try
            {
                User result = apiInstance.ApiGamePost(authorization, item);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling GameApi.ApiGamePost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **authorization** | **string**|  | [optional] 
 **item** | [**Game**](Game.md)|  | [optional] 

### Return type

[**User**](User.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/json-patch+json
 - **Accept**: text/plain, application/json, text/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

